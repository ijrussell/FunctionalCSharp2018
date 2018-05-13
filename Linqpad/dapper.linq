<Query Kind="Program">
  <NuGetReference>Dapper</NuGetReference>
  <Namespace>Dapper</Namespace>
  <Namespace>ExtensionExample</Namespace>
</Query>

void Main()
{
	
}

public class DbLogger
{
	string connString;

	public void Log(LogMessage msg)
	{
		using (var conn = new SqlConnection(connString))
		{
			var affectedRows = conn.Execute("sp_create_log", msg, commandType: CommandType.StoredProcedure);
		}
	}

	public IEnumerable<LogMessage> GetLogs(DateTime since)
	{
		const string sqlGetLogs = "SELECT * FROM [Logs] WHERE [Timestamp] > @since";
		using (var conn = new SqlConnection(connString))
		{
			return conn.Query<LogMessage>(sqlGetLogs, new { since = since });
		}
	}
}

public class DbLoggerFunc
{
	string connString;

	public void Log(LogMessage message)
		=> Connect(connString, c => c.Execute("sp_create_log"
			, message, commandType: CommandType.StoredProcedure));

	public IEnumerable<LogMessage> GetLogs(DateTime since)
		=> Connect(connString, c => c.Query<LogMessage>(@"SELECT * FROM [Logs] WHERE [Timestamp] > @since", new { since = since }));

}


public class LogMessage
{
	public string Message { get; set; }
}


public static class ExtensionExample
{
    public static T Connect<T>(string connString, Func<IDbConnection, T> f)
	{
		using (var conn = new SqlConnection(connString))
		{
			conn.Open();
			return f(conn);
		}
	}

	public static T Using<TDisp, T>(TDisp disposable, Func<TDisp, T> f) where TDisp : IDisposable
	{
		using (disposable) return f(disposable);
	}

	//public static T Connect<T>(string connStr, Func<IDbConnection, T> f)
	//    => Using(new SqlConnection(connStr)
	//        , conn => { conn.Open(); return f(conn); });
}
