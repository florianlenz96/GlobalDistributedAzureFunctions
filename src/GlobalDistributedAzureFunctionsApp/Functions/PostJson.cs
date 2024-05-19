using System.Collections.Generic;
using System.Net;
using System.Text;
using GlobalDistributedAzureFunctionsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace GlobalDistributedAzureFunctionsApp.Functions;

public class PostJson
{
    [Function("PostJson")]
    public async Task<PostJsonResponse> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")]
        HttpRequestData req,
        FunctionContext executionContext)
    {
        var json = await req.ReadAsStringAsync();
        
        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json");
        response.Body = new MemoryStream(Encoding.UTF8.GetBytes(json));

        return new PostJsonResponse
        {
            ResponseMessage = response,
            ResponseObject = json,
        };
    }
}