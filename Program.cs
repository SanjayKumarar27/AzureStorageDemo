// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;
using System.Collections.Generic;
using System.IO;

//dotnet add package Azure.Storage.Blobs

class Program
{
    static async Task Main(string[] args)
    {
        BlobServiceClient client = new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=storageaccountsanjay;AccountKey=nBDSCXv1N5hUEm9TtD3p0zSlfjjJddbAcf1F8sjNOcWwzPawh4BHaToEoy89I3WjXIASfYiVGf6N+AStn2rPtQ==;EndpointSuffix=core.windows.net");
        // AccountInfo info = await client.GetAccountInfoAsync();


        await Console.Out.WriteLineAsync($"Connected  to Azure storage Account");
        // await Console.Out.WriteLineAsync($"Account kind :\t{info.AccountKind}");
        // await Console.Out.WriteLineAsync($"Account sku :\t{info.SkuName}");

        // BlobContainerClient blobContainer = await client.CreateBlobContainerAsync("sanjay");
        // await Console.Out.WriteLineAsync("Created");

        // BlobContainerClient blobContainer= client.GetBlobContainerClient("sanjay");
        //  BlobClient blob=blobContainer.GetBlobClient("sample.txt");

        // FileStream fileStream = File.OpenRead("c:\\work\\sample.txt");
        // await blob.UploadAsync(fileStream,true);
        // Console.WriteLine("Done!");


        /*
         await foreach (BlobContainerItem container in client.GetBlobContainersAsync())
            {
                await Console.Out.WriteLineAsync($"Container:\t{container.Name}");
                BlobContainerClient container1 = client.GetBlobContainerClient(container.Name);
                await foreach (BlobItem blob in container1.GetBlobsAsync())
                {
                    await Console.Out.WriteLineAsync($"Existing Blob:\t{blob.Name}");
                    BlobClient blobClient = container1.GetBlobClient(blob.Name);
                    await Console.Out.WriteLineAsync($"Blob uri:\t{blobClient.Uri}");

                    IDictionary<string,string> metadata=new Dictionary<string, string>();
                    metadata.Add("demo","metadata");
                    metadata.Add("demo1", "metadata1");
                   
                    blobClient.SetMetadata(metadata);

                    BlobProperties blobProperties = await blobClient.GetPropertiesAsync();
                    foreach (var md in blobProperties.Metadata)
                    {
                        await Console.Out.WriteLineAsync($"Key:\t{md.Key}\tValue:\t{md.Value}");
                    }
                }
            }
    */

    //text from the cloud in continer

       BlobContainerClient blobContainer = client.GetBlobContainerClient("sanjay");
        BlobClient blob = blobContainer.GetBlobClient("sample.txt");
    //     string text=(await blob.DownloadContentAsync()).Value.Content.ToString();
    //     Console.WriteLine(text);

    //DownloadContentAsync() is available from "Azure.Storage.Blobs" Version="12.10.0" if its lower than 12.10 then it'll not work
      BlobDownloadInfo blobdata = await blob.DownloadAsync();


        using (FileStream downloadFileStream = File.OpenWrite("c:\\work\\download.txt"))
        {
            await blobdata.Content.CopyToAsync(downloadFileStream);
            downloadFileStream.Close();
        }


        Console.WriteLine(File.ReadAllText("c:\\work\\download.txt"));

            // Read the new file
            // using (FileStream downloadFileStream = File.OpenRead("c:\\work\\sampled.txt"))
            // {
            //     using var strreader = new StreamReader(downloadFileStream);
            //     string line;
            //     while ((line = strreader.ReadLine()) != null)
            //     {
            //         Console.WriteLine(line);
            //     }
            // }
    }
}


