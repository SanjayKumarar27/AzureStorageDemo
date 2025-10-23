// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


//dotnet add package Azure.Storage.Blobs

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

class Program
{
    static async Task Main(string[] args)
    {
        BlobServiceClient client = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=sanjaysstorageforphoto;AccountKey=SKEB26HloIH9SQaaXRTvvH+dHzSIj8+1PykLh5FqDioZY2na39jFAN1LTuH3zLGol9r7cN8x9aKZ+ASt+9lz7w==;EndpointSuffix=core.windows.net");

        AccountInfo info = await client.GetAccountInfoAsync();


        await Console.Out.WriteLineAsync($"Connected  to Azure storage Account");
        await Console.Out.WriteLineAsync($"Account kind :\t{info.AccountKind}");
        await Console.Out.WriteLineAsync($"Account sku :\t{info.SkuName}");
        

    }
}


