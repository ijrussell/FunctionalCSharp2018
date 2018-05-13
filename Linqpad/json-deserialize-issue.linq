<Query Kind="Program">
  <NuGetReference>Rock.Core.Newtonsoft</NuGetReference>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var response = "{ ErrorCode: \"OrderNotSupported\" }";
	
	ApiErrorV1 apiError = JsonConvert.DeserializeObject<ApiErrorV1>(response);
	
	apiError.Dump();
}



public class ApiErrorV1
{
    public ApiErrorV1(string parameterName, string errorCode, string errorMessage, string userMessage)
	{
		ParameterName = parameterName;
		ErrorCode = errorCode;
		ErrorMessage = errorMessage;
		UserMessage = userMessage;
	}

    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public string Level { get; set; }
    public string ParameterName { get; set; }
    public string UserMessage { get; set; }
    public IEnumerable<string> MessageContext { get; set; }
}
