<Query Kind="Statements" />

Func<DirectoryInfo, int, string> read = (workingDirectory, id) =>
    {
        var path = Path.Combine(workingDirectory.FullName, id + ".txt");
        return File.ReadAllText(path);
    };
	
var words = read(new DirectoryInfo(@"C:\Users\ian.russell\Documents\LINQPad Queries"), 2);

words.Dump();