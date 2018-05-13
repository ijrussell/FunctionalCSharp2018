<Query Kind="Program" />

void Main()
{
	Demonstrate(NaiveFibonacci);
	Demonstrate(ForwardFibonacci);
	Demonstrate(ProperFibonacci);

	Console.ReadLine();
}

static IList<long> forwardCache = new List<long> {0,1};

static long ForwardFibonacci(int n)
{
	while (forwardCache.Count <= n)
	{
		forwardCache.Add(
			forwardCache[forwardCache.Count - 1] +
			forwardCache[forwardCache.Count - 2]
		);
	}
	return forwardCache[n];
}

static IDictionary<int, long> cache = new Dictionary<int, long>();

static long ProperFibonacci(int n)
{
	long value;
	if (!cache.TryGetValue(n, out value))
	{
		value = n < 2 ? n : ProperFibonacci(n - 1) + ProperFibonacci(n - 2);
		cache[n] = value;
	}	
	
	return value;
}

static long NaiveFibonacci(int n) =>
	n < 2 ? n : NaiveFibonacci(n - 1) + NaiveFibonacci(n - 2);
	
static void Demonstrate(Func<int, long> fibonacci)
{
	var offset = 30;
	for (int i = 0; i < 10; i++)
		Console.WriteLine($"{i}\t{fibonacci(i + offset)}");
	Console.WriteLine("Finished");
}
