<Query Kind="Program" />

void Main()
{
	var result = DiscountHelper.GetDiscount(new NoDiscount());
	result.Dump();
	
	var (hasDiscount, discount) = DiscountHelper.GetDiscount(new HasDiscount(25m));
	hasDiscount.Dump();
	discount.Dump();
	
	var result2 = DiscountHelper.SetDiscount(false, 0m);
	result2.Dump();

	result2 = DiscountHelper.SetDiscount(true, 25m);
	result2.Dump();
}

class Customer
{
	public Customer(int id, Discount discount)
	{
		Id = id;
		Discount = discount;
	}
	
	public int Id { get; }
	public Discount Discount { get; }
}

class CustomerDTO
{
	public CustomerDTO(int id, bool hasDiscount, decimal discountAmount)
	{
		Id = id;
		HasDiscount = hasDiscount;
		DiscountAmount = discountAmount;
	}

	public int Id { get; }
	public bool HasDiscount { get; }
	public decimal DiscountAmount { get; }
}

abstract class Discount { }

class NoDiscount : Discount { }

class HasDiscount : Discount 
{
	public HasDiscount(decimal discount)
	{
		Discount = discount;
	}
	
	public decimal Discount { get; }
}

static class DiscountHelper
{
	public static (bool hasDiscount, decimal amount) GetDiscount(Discount discount)
	{
		switch (discount)
		{
			case HasDiscount n:
				return (true, n.Discount);
			case NoDiscount n:
			default:
				return (false, 0m);
		}
	}
	
	public static Discount SetDiscount(bool hasDiscount, decimal amount)
	{
		return hasDiscount ? (Discount)new HasDiscount(amount) : (Discount)new NoDiscount();		
	}
}