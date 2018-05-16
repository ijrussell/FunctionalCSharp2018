using System;

namespace ConsoleApp13
{
    public static class Functions 
    {
        public static Customer TryToPromoteToVip(this (Customer, decimal) purchases)
        {
            var (customer, amount) = purchases;

            if (amount > 100m) 
                return new CustomerBuilder(customer).WithIsVip(true).Build();

            return customer;
        }

        public static (Customer, decimal) GetPurchases(this Customer customer)
        {
            if (customer.Id % 2 == 0) return (customer, 120m);

            return (customer, 80m);
        }

        public static Customer IncreaseCredit(this Customer customer, Func<Customer, bool> condition)
        {
            var increase = condition(customer) ? 100m : 50m;
            
            return new CustomerBuilder(customer).WithCredit(customer.Credit + increase).Build();
        }

        public static Customer UpgradeCustomer(Customer customer)
        {
            return customer
                .GetPurchases()
                .TryToPromoteToVip()
                .IncreaseCredit(c => c.IsVip);
        }

        public static bool IsAdult(this Customer customer)
        {
            switch (customer.PersonalDetails)
            {
                case Some<PersonalDetails> p:
                    return p.Reduce(new PersonalDetails("", "", DateTime.Today)).DateOfBirth.AddYears(18) <=
                           DateTime.Now.Date;
                default:
                    return false;
            }
        }

        public static string GetAlert(this Customer customer)
        {
            switch (customer.Notifications)
            {
                case ReceiveNotifications n when n.ReceiveAlerts:
                    return "Receive alerts";
                case ReceiveNotifications _:
                        return "No alerts";
                default:
                    return "No notifications";
            }
        }
    }

    public static class NotificationsHelper
    {
        public static (bool deals, bool alerts) GetNotifications(Notifications notifications)
        {
            switch (notifications)
            {
                case ReceiveNotifications n:
                    return (n.ReceiveDeals, n.ReceiveAlerts);
                case NoNotifications n:
                default:
                    return (false, false);
            }
        }

        public static Notifications SetNotifications(bool deals, bool alerts)
        {
            return deals || alerts ? (Notifications)new ReceiveNotifications(deals, alerts) : (Notifications)new NoNotifications();
        }
    }

    internal class CustomerBuilder
    {
        private int _id;
        private bool _isVip;
        private decimal _credit;
        private Option<PersonalDetails> _personalDetails;
        private Notifications _notifications;

        public CustomerBuilder(Customer customer)
        {
            _id = customer.Id;
            _isVip = customer.IsVip;
            _credit = customer.Credit;
            _personalDetails = customer.PersonalDetails;
            _notifications = customer.Notifications;
        }

        public CustomerBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public CustomerBuilder WithIsVip(bool isVip)
        {
            _isVip = isVip;
            return this;
        }

        public CustomerBuilder WithCredit(decimal credit)
        {
            _credit = credit;
            return this;
        }

        public CustomerBuilder WithPersonalDetails(Option<PersonalDetails> personalDetails)
        {
            _personalDetails = personalDetails;
            return this;
        }

        public CustomerBuilder WithNotifications(Notifications notifications)
        {
            _notifications = notifications;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_id, _isVip, _credit, _personalDetails, _notifications);
        }
    }
}