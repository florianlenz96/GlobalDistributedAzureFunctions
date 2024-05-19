using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace GlobalDistributedAzureFunctionsApp.Models;

public class PostJsonResponse
{
    public HttpResponseData ResponseMessage { get; set; }
    
    [CosmosDBOutput("main", "json", Connection = "CosmosDBConnection")]
    public object ResponseObject { get; set; }
}