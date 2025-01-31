using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;

public static class FilterRecordsInCosmosDB
{
    private static readonly string EndpointUri = Environment.GetEnvironmentVariable("CosmosDBEndpoint");
    private static readonly string PrimaryKey = Environment.GetEnvironmentVariable("CosmosDBPrimaryKey");
    private static DocumentClient client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);

    [FunctionName("FilterRecordsInCosmosDB")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "filter/{genre}")] HttpRequest req,
        string genre,
        ILogger log)
    {
        var queryOptions = new FeedOptions { MaxItemCount = -1 };
        IQueryable<dynamic> query = client.CreateDocumentQuery<dynamic>(
            UriFactory.CreateDocumentCollectionUri("CatalogDatabase", "CatalogCollection"), queryOptions)
            .Where(d => d.genre == genre);

        var results = await query.ToListAsync();
        return new OkObjectResult(results);
    }
}
