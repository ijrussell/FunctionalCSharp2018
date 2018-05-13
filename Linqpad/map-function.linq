<Query Kind="Program" />

void Main()
{
	var id = 1;
	
	var user = id.Map(x => new User(x));
	
	user.Dump();
}

public static class Extensions
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