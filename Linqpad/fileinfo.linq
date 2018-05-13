<Query Kind="Program" />

void Main()
{
	//Func<FileInfo, string> formatFileInfo = fi => $"{fi.Name}:{fi.Length}:{fi.LastAccessTime.ToString("yyyy-MM-dd hh:mm:ss")}";
	string formatFileInfo(FileInfo fi) => $"{fi.Name}:{fi.Length}:{fi.LastAccessTime.ToString("yyyy-MM-dd hh:mm:ss")}";

	Directory.GetFiles(@"c:\users\ian\documents")
		.Select(f => new FileInfo(f))
		.Select(formatFileInfo)
		.Dump();
}

// Define other methods and classes here
