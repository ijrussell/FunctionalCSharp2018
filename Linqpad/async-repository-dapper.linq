<Query Kind="Program">
  <Reference Relative="Dapper.1.50.4\lib\net451\Dapper.dll">&lt;MyDocuments&gt;\LINQPad Queries\Dapper.1.50.4\lib\net451\Dapper.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Namespace>Dapper</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var repos = new PersonRepository("");
	
	var person = repos.GetPersonById(Guid.NewGuid()).Result;
}

public class Person
{
	public Guid Id { get; set; }
	public string Name { get; set; }
}

public class PersonRepository : BaseRepository
{
    public PersonRepository(string connectionString): base (connectionString) { }

    public async Task<Person> GetPersonById(Guid Id)
    {
        return await WithConnection(async c => {

            // Here's all the same data access code,
            // albeit now it's async, and nicely wrapped
            // in this handy WithConnection() call.
            var p = new DynamicParameters();
            p.Add("Id", Id, DbType.Guid);
            var people = await c.QueryAsync<Person>(
                sql: "sp_Person_GetById", 
                param: p, 
                commandType: CommandType.StoredProcedure);
            return people.FirstOrDefault();

        });
    }
}

public abstract class BaseRepository 
{
    private readonly string _ConnectionString;

    protected BaseRepository(string connectionString) 
    {
        _ConnectionString = connectionString;
    }

    protected async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData) 
    {
        try {
            using (var connection = new SqlConnection(_ConnectionString)) {
                await connection.OpenAsync(); // Asynchronously open a connection to the database
                return await getData(connection); // Asynchronously execute getData, which has been passed in as a Func<IDBConnection, Task<T>>
            }
        }
        catch (TimeoutException ex) {
            throw new Exception(String.Format("{0}.WithConnection() experienced a SQL timeout", GetType().FullName), ex);
        }
        catch (SqlException ex) {
            throw new Exception(String.Format("{0}.WithConnection() experienced a SQL exception (not a timeout)", GetType().FullName), ex);
        }
    }
}

