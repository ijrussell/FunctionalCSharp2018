<Query Kind="Statements" />

var ceiling = 1000000;
var numbers = Enumerable.Range(2, ceiling).ToList();

for (var i = 2; i < Math.Sqrt(ceiling); i++)
{
	if (numbers.Contains(i))
	{
		numbers = numbers.Where(x => x == i || x % i != 0).ToList();
	}
}
numbers.Count().Dump();
numbers.OrderByDescending(x => x).Dump();
