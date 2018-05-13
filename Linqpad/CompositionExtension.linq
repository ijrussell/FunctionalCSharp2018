<Query Kind="Program" />

void Main()
{
	var id = 23;
	
	var user = id.Map(x => new User(x));
	
	user.Dump();
}

static class CompositionExtension
{
	public static TResult Map<T, TResult>(this T input, Func<T, TResult> f) => f(input);
}

public class User
{
	public User(int id)
	{
		Id = id;
	}
	
	public int Id { get; }
}