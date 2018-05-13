<Query Kind="Expression" />



static IEnumerable<T> Where<T>(this IEnumerable<T> ts, Func<T, bool> predicate)
{
	foreach (T t in ts)
		if (predicate(t))
			yield return t;
}


// Pure function
// Higher-order function
// Referential Transparency