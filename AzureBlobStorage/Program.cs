using Azure.Storage.Blobs;

// See https://aka.ms/new-console-template for more information

var blobServiceClient = new BlobServiceClient("BlobEndpoint=https://salearnaz204.blob.core.windows.net/;QueueEndpoint=https://salearnaz204.queue.core.windows.net/;FileEndpoint=https://salearnaz204.file.core.windows.net/;TableEndpoint=https://salearnaz204.table.core.windows.net/;SharedAccessSignature=sv=2022-11-02&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2023-08-19T02:52:56Z&st=2023-08-18T18:52:56Z&spr=https&sig=r%2F6lowqHICaPczs9z1CwsISK5b8DFXKcU1QYV2lh0i8%3D");

// Creating blob container
//await blobServiceClient.CreateBlobContainerAsync("testcontainerfromcode");

var blobContainerClient = blobServiceClient.GetBlobContainerClient("testcontainerfromcode");

FileInfo _fileInfo = new FileInfo("C:\\Users\\Pramod\\Downloads\\Home.jpg");
FileStream _file = _fileInfo.OpenRead();

// Uploading blob
//await blobContainerClient.UploadBlobAsync("Home.jpg", _file);

IDictionary<string, string> containermetadata = new Dictionary<string, string>();
containermetadata.Add("City", "Bangalore");

//Set meta data for the container
await blobContainerClient.SetMetadataAsync(containermetadata);

var blobClient = blobContainerClient.GetBlobClient("Home.jpg");

IDictionary<string, string> blobmetadata = new Dictionary<string, string>();
blobmetadata.Add("Age", "30");

// Set meta data for the blob
//await blobClient.SetMetadataAsync(blobmetadata);

// read metadata of the blob
var properties = await blobClient.GetPropertiesAsync();

foreach (var metaddata in properties.Value.Metadata)
{
    Console.WriteLine($"Metadata key: {metaddata.Key}, Metadata value: {metaddata.Value}");
}


var policies = await blobContainerClient.GetAccessPolicyAsync();

Console.WriteLine($"Policy: {policies.Value.ToString()}");

Console.ReadLine();


