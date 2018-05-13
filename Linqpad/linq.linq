<Query Kind="Program" />

void Main()
{
	Func<int, bool> isOdd = x => x % 2 == 1;
	int[] original = { 7, 6, 1 };
	var sorted = original.OrderBy(x => x);
	var filtered = sorted.Where(isOdd);
	original.Dump(); // => [7, 6, 1]
	sorted.Dump(); // => [1, 6, 7]
	filtered.Dump(); // => [1, 7]
	
	original
		.OrderBy(x => -x)
		.Where(isOdd)
		.Dump(); // => [7, 1]
}

// Define other methods and classes here