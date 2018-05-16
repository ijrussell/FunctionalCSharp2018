using System;

namespace ConsoleApp13
{
    public class Customer
    {
        public Customer(int id, bool isVip, decimal credit, Option<PersonalDetails> personalDetails, Notifications notifications)
        {
            Id = id;
            IsVip = isVip;
            Credit = credit;
            PersonalDetails = personalDetails;
            Notifications = notifications;
        }

        public int Id { get; }
        public bool IsVip { get; }
        public decimal Credit { get; }
        public Option<PersonalDetails> PersonalDetails { get; }
        public Notifications Notifications { get; }

        public override string ToString()
        {
            return $"Id: {Id}, IsVip: {IsVip}, Credit: {Credit}, PersonalDetails: {PersonalDetails.Reduce(new PersonalDetails("", "", DateTime.Today))}, Notifications: {Notifications}";
        }
    }

    public class PersonalDetails
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DateOfBirth { get; }

        public PersonalDetails(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public override string ToString()
        {
            return $"[FirstName: {FirstName}, LastName: {LastName}, DateOfBirth: {DateOfBirth}]";
        }
    }

    public abstract class Notifications { }

    public class NoNotifications : Notifications
    {
        public override string ToString()
        {
            return "NoNotifications";
        }
    }

    public class ReceiveNotifications : Notifications
    {
        public bool ReceiveDeals { get; }
        public bool ReceiveAlerts { get; }

        public ReceiveNotifications(bool receiveDeals, bool receiveAlerts)
        {
            ReceiveDeals = receiveDeals;
            ReceiveAlerts = receiveAlerts;
        }

        public override string ToString()
        {
            return $"Notifications: Deals: {ReceiveDeals}, Alerts: {ReceiveAlerts}";
        }
    }
}