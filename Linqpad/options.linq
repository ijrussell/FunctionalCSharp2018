<Query Kind="Program" />

void Main()
{
	var customer = new Customer(1, new CustomerName("Ian", None.Value, "Russell"));

	customer.Dump();
	
	var customer2 = new Customer(1, new CustomerName("Ian", "John", "Russell"));

	customer2.Dump();
	
	var middleName = customer2.CustomerName.MiddleName.Reduce("Not found");
	
	middleName.Dump();
}

class Customer
{
	public Customer(int id, CustomerName name)
	{
		Id = id;
		CustomerName = name;
	}
	
	public int Id { get; }
	public CustomerName CustomerName { get; }
}

class CustomerName
{
	public CustomerName(string firstName, Option<string> middleName, string lastName)
	{
		FirstName = firstName;
		MiddleName = middleName;
		LastName = lastName;
	}
	
	public string FirstName { get; }
	public Option<string> MiddleName { get; }
	public string LastName { get; }
}

class Option<T>
{
	public static implicit operator Option<T>(T value) =>
		new Some<T>(value);
		
	public static implicit operator Option<T>(None none) =>
		new None<T>();
}

class Some<T> : Option<T>
{
	private T Content { get; }
	
	public Some(T content)
	{
		this.Content = content;
	}
	
	public static implicit operator T(Some<T> value) => value.Content;
}

class None<T> : Option<T> { }

class None
{
	public static None Value { get; } = new None();
	private None() { }
}

static class OptionAdaptors
{
	public static Option<TResult> Map<T, TResult>(this Option<T> option, Func<T, TResult> map) =>
		option is Some<T> some ? (Option<TResult>)map(some) : None.Value;
		
	public static Option<T> When<T>(this T value, Func<T, bool> predicate) =>
		predicate(value) ? (Option<T>)value : None.Value;
		
	public static T Reduce<T>(this Option<T> option, T whenNone) =>
		option is Some<T> some ? (T)some : whenNone;
		
	public static T Reduce<T>(this Option<T> option, Func<T> whenNone) =>
		option is Some<T> some ? (T)some : whenNone();
}

static class EnumerableExtensions
{
	public static IEnumerable<TResult> Flatten<T, TResult>(this IEnumerable<T> sequence, Func<T, Option<TResult>> map) =>
		sequence.Select(map)
			.OfType<Some<TResult>>()
			.Select(x => (TResult)x);
}