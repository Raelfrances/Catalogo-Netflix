using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

public static class SaveToCosmosDB
{
    [FunctionName("SaveToCosmosDB")]
    public static async Task Run(
        [BlobTrigger("netflix-catalog/{name}.json", Connection = "AzureWebJobsStorage")] Stream myBlob,
        string name,
        [CosmosDB(
            databaseName: "CatalogDatabase",
            collectionName: "CatalogCollection",
            ConnectionStringSetting = "CosmosDBConnection")]
        IAsyncCollector<dynamic> documentsOut,
        ILogger log)
    {
        using (var streamReader = new StreamReader(myBlob))
        {
            var jsonContent = await streamReader.ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(jsonContent);
            await documentsOut.AddAsync(data);
        }

        log.LogInformation($"Document {name} uploaded to CosmosDB successfully");
    }
}
