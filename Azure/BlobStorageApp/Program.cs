using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

const string connectionString = "<YOUR-CONNECTION-STRING>";

var blobServiceClient = new BlobServiceClient(connectionString);



// get all containers
//await foreach (var container in blobServiceClient.GetBlobContainersAsync())
//{
//    System.Console.WriteLine(container.Name);
//}



// create container
//var createBlobContainerResponse = await blobServiceClient.CreateBlobContainerAsync("testcontainer", PublicAccessType.BlobContainer);
//var blobContainerClient = createBlobContainerResponse.Value;
//System.Console.WriteLine(createBlobContainerResponse);
//System.Console.WriteLine(blobContainerClient);



// get blobs
//var containerClient = blobServiceClient.GetBlobContainerClient("mycontainer");
//await foreach (var blob in containerClient.GetBlobsAsync())
//{
//    System.Console.WriteLine(blob.Name);
//}



// download blob
//var containerClient = blobServiceClient.GetBlobContainerClient("mycontainer");
//var blobClient = containerClient.GetBlobClient("bob marley.jpg");

//using FileStream newFileStream = File.Create(blobClient.Name);
//var response = await blobClient.DownloadToAsync(newFileStream);
//System.Console.WriteLine(response);



// download all blobs from container
//var containerClient = blobServiceClient.GetBlobContainerClient("mycontainer");
//await foreach (var blob in containerClient.GetBlobsAsync())
//{
//    var blobClient = containerClient.GetBlobClient(blob.Name);

//    using var fileStream = File.Create(blob.Name);
//    var response = await blobClient.DownloadToAsync(fileStream);
//    fileStream.Close();
//}



// upload blob
//var containerClient = blobServiceClient.GetBlobContainerClient("testcontainer");
//var blobClient = containerClient.GetBlobClient("test.jpg");

//using var fileStream = File.Open("cat.jpg", FileMode.Open);
//await blobClient.UploadAsync(fileStream);
//fileStream.Close();