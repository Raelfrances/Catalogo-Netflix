using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;

public static class SaveToFileStorage
{
    [FunctionName("SaveToFileStorage")]
    public static void Run(
        [BlobTrigger("netflix-catalog/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob, 
        string name, 
        ILogger log)
    {
        var storageAccount = CloudStorageAccount.Parse(Environment.GetEnvironmentVariable("AzureWebJobsStorage"));
        var blobClient = storageAccount.CreateCloudBlobClient();
        var container = blobClient.GetContainerReference("netflix-catalog");

        var blockBlob = container.GetBlockBlobReference(name);
        using (var fileStream = myBlob)
        {
            blockBlob.UploadFromStreamAsync(fileStream).Wait();
        }
        
        log.LogInformation($"Blob {name} uploaded successfully");
    }
}
