<Query Kind="Program" />

void Main()
{
	var card = new BankCard
	{
		ValidBefore = DateTime.Now.AddSeconds(2),
		Balance = 100m
	};

	var amount = card.GetAvailableAmount(20); // 80
	amount.Dump();
	card.Balance = 10;

	amount = card.GetAvailableAmount(20); // 10
	amount.Dump();
	Thread.Sleep(3000);


	amount = card.GetAvailableAmount(20); // 0
	amount.Dump();
}

class BankCard
{
	public DateTime ValidBefore { get; set; }
	public decimal Balance { get; set; }
	
	public decimal GetAvailableAmount(decimal requested)
	{
		if (DateTime.Now.CompareTo(this.ValidBefore) >= 0)
			return 0m;
		return Math.Min(this.Balance, requested);		
	}
}
