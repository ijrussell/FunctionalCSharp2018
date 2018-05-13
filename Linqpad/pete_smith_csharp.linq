<Query Kind="Program" />

//Pete Smith -> https://gist.github.com/beyond-code-github/8711794c4d516cb6941d47274884b248

void Main()
{
	var calculator = new DiscountCalculator();

	Assert(calculator.Calculate(100.0m, 0, 0), 100.0m).Dump("NotRegistered");
	Assert(calculator.Calculate(100.0m, 1, 1), 98.01m).Dump("SimpleCustomer");
	Assert(calculator.Calculate(100.0m, 2, 6), 92.15m).Dump("ValuableCustomer");
	Assert(calculator.Calculate(100.0m, 3, 1), 94.05m).Dump("MostValuableCustomer");
}

delegate decimal Discount(decimal amount, int yearsAccountHeld);

public static class Discounts
{
	public static decimal NotRegistered(decimal amount, int yearsAccountHeld) => amount;

	public static decimal SimpleCustomer(decimal amount, int yearsAccountHeld) =>
		(amount * 0.99m) * LoyaltyDiscount(yearsAccountHeld);

	public static decimal ValuableCustomer(decimal amount, int yearsAccountHeld) =>
		(amount * 0.97m) * LoyaltyDiscount(yearsAccountHeld);

	public static decimal MostValuableCustomer(decimal amount, int yearsAccountHeld) =>
		(amount * 0.95m) * LoyaltyDiscount(yearsAccountHeld);

	private static decimal LoyaltyDiscount(int yearsAccountHeld) => 1 - (Math.Min(yearsAccountHeld, 5) / 100.0m);
}

public class DiscountCalculator
{
	private Dictionary<int, Discount> applyDiscountFor = new Dictionary<int, Discount>()
		{
			{ 0, Discounts.NotRegistered },
			{ 1, Discounts.SimpleCustomer },
			{ 2, Discounts.ValuableCustomer },
			{ 3, Discounts.MostValuableCustomer }
		};

	public decimal Calculate(decimal amount, int accountType, int yearsAccountHeld) =>
		this.applyDiscountFor[accountType](amount, yearsAccountHeld);
}

private bool Assert(decimal actual, decimal expected)
{
	return actual == expected;
}
