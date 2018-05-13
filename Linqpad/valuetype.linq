<Query Kind="Program" />

void Main()
{
	var currency = Currency.USD;
	var currency2 = Currency.USD;
	
	currency.Equals(currency2).Dump();
}

sealed class Currency : IEquatable<Currency>
{
	public string Symbol { get; }
	
	private Currency(string symbol)
	{
		Symbol = symbol;
	}

	public static Currency GBP => new Currency("GBP");
	public static Currency USD => new Currency("USD");
	public static Currency EUR => new Currency("EUR");

	public bool Equals(Currency other) =>
		other != null && this.Symbol == other.Symbol;

	public override bool Equals(object obj) =>
		this.Equals(obj as Currency);

	public override int GetHashCode() => 
		this.Symbol.GetHashCode(); // Use ^ for adding other properties
		
	public static bool operator ==(Currency a, Currency b) =>
		object.ReferenceEquals(a, null)
			? object.ReferenceEquals(b, null)
			: a.Equals(b);
			
	public static bool operator !=(Currency a, Currency b) => !(a ==b);
		
	public override string ToString() => this.Symbol;
}
