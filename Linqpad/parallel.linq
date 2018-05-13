<Query Kind="Statements">
  <Namespace>static System.Console</Namespace>
  <Namespace>static System.Linq.Enumerable</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var nums = Range(-10000, 20001).Reverse().ToList();
// => [10000, 9999, ... , -9999, -10000]
Action task1 = () => WriteLine(nums.Sum());
Action task2 = () => { nums.Sort(); WriteLine(nums.Sum()); };
Parallel.Invoke(task1, task2);
Action task3 = () => WriteLine(nums.OrderBy(x => x).Sum());
Parallel.Invoke(task1, task3);