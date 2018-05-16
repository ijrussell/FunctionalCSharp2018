using System;
using static ConsoleApp13.Functions;
using static ConsoleApp13.NotificationsHelper;

namespace ConsoleApp13
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, false, 25m, new PersonalDetails("Ian", "Russell", new DateTime(1966, 5, 25)), SetNotifications(true, false));
            Console.WriteLine(customer);

            var customer2 = new Customer(1, false, 25m, None.Value, SetNotifications(false, false));
            Console.WriteLine(customer2);

            var isAdult = customer.IsAdult();
            Console.WriteLine(isAdult);

            var data = Service.GetCustomerInfo(customer);
            Console.WriteLine(data);

            var purchases = new ValueTuple<Customer, decimal>(customer, 101m);

            //var vipCustomer = purchases.TryToPromoteToVip();

            //Console.WriteLine(vipCustomer);

            //var increase = customer.IncreaseCredit(c => c.IsVip);

            //Console.WriteLine(increase);

            //var composition = UpgradeCustomer(vipCustomer);
            //Console.WriteLine(composition);

            Console.ReadLine();
        }
    }
}
