using static ConsoleApp13.Functions;

namespace ConsoleApp13
{
    public static class Service
    {
        public static string GetCustomerInfo(Customer customer)
        {
            var isAdult = customer.IsAdult();
            var receiveAlerts = customer.GetAlert();
            return $"Id: {customer.Id}, IsVip: {customer.IsVip}, Credit: {customer.Credit}, IsAdult: {isAdult}, Alert: {receiveAlerts}";
        }
    }
}