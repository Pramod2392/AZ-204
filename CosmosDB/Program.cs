// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CosmosDB;
using Microsoft.Azure.Cosmos;

Console.WriteLine("Hello, World!");

var client = new SecretClient(new Uri("https://az-204keyvault.vault.azure.net/"), new DefaultAzureCredential());

var secretValue = await client.GetSecretAsync("cosmosDBConnString");


string _connString = secretValue.Value.Value;

var cosmosDBClient = new CosmosClient(_connString);

// Read account properties

var accountProperties = await cosmosDBClient.ReadAccountAsync();

Console.WriteLine($"Id: { accountProperties.Id}, ETag: {accountProperties.ETag}");


// Create database

var response = await cosmosDBClient.CreateDatabaseIfNotExistsAsync("DatabaseFromCode");

Console.WriteLine($"DataBase creation status: {response.StatusCode}, Database name: {response.Database.Id}");

// Create container

var database = cosmosDBClient.GetDatabase("DatabaseFromCode");
var containerResponse = await database.CreateContainerIfNotExistsAsync("Student", "/StudentId");
Console.WriteLine($"Container creation status: {containerResponse.StatusCode}, Container name: {containerResponse.Container.Id}");

// CRUD operation on document

// CREATE

var container = database.GetContainer("Student");

//Student student = new()
//{
//    Name = "Pramod Shivaprasad",
//    StudentId = 1,
//    Age = 30,
//    id = "1",
//};

//var itemResponse = await container.CreateItemAsync<Student>(student);

//Console.WriteLine($"Status Code: {itemResponse.StatusCode}");

// READ

//var readResponse = await container.ReadItemAsync<Student>("1",new PartitionKey(1));
//Console.WriteLine($"{readResponse.Resource.Name}");


// UPDATE

//var updatedResponse =  await container.UpsertItemAsync(student);
//Console.WriteLine($"{updatedResponse.StatusCode}, {updatedResponse.Resource.Name}");


// DELETE

//var deleteResponse = await container.DeleteItemAsync<Student>("1",new PartitionKey(1));
//Console.WriteLine($"{deleteResponse.StatusCode}, {deleteResponse.Resource?.Name}");



// CREATE MULTIPLE

Student student1 = new()
{
    Name = "Mahesh",
    StudentId = 1,
    Age = 30,
    id = "1",
};

Student student2 = new()
{
    Name = "Suresh",
    StudentId = 1,
    Age = 30,
    id = "2",
};

TransactionalBatch transactionalBatch = container.CreateTransactionalBatch(new PartitionKey(1));
transactionalBatch.CreateItem<Student>(student1);
transactionalBatch.CreateItem<Student>(student2);
var transactionalBatchResponse = await transactionalBatch.ExecuteAsync();

Console.WriteLine($"Is Success: {transactionalBatchResponse.IsSuccessStatusCode}");