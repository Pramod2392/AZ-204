using Azure.Messaging.ServiceBus;

namespace AzureServiceBusSender
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            Execute(args).Wait();
        }
        static async Task Execute(string[] args)
        {
            // send message to a queue

            #region queue

            #region withoutbatch

            //var client = new ServiceBusClient(connectionString: "Endpoint=sb://namespace-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=vyWuHoGc1Z5EQg9EmJuEq3RMTaQFuo92c+ASbPXIi58=");

            //var serviceBusSender = client.CreateSender("testqueue");

            //ServiceBusMessage message = new ServiceBusMessage("Hi I am Pramod. I am working as a software engineer at 'Honeywell Technologies'");
            //message.Subject = "Introduction";

            //await serviceBusSender.SendMessageAsync(message);

            //Console.ReadLine();

            #endregion withoutbatch

            #region withbatch

            //var connectionString = "Endpoint=sb://namespace-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=vyWuHoGc1Z5EQg9EmJuEq3RMTaQFuo92c+ASbPXIi58=";
            //var queueName = "testqueue";

            //var servicebusClient = new ServiceBusClient(connectionString);

            //var sender = servicebusClient.CreateSender(queueName);

            //var listOfMessages = new List<ServiceBusMessage>();

            //listOfMessages.Add(new ServiceBusMessage("I am Pramod"));
            //listOfMessages.Add(new ServiceBusMessage("I am Praveen"));

            //await sender.SendMessagesAsync(listOfMessages);

            #endregion withbatch

            #region using ServiceBusMessageBatch 

            //var connectionString = "Endpoint=sb://namespace-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=vyWuHoGc1Z5EQg9EmJuEq3RMTaQFuo92c+ASbPXIi58=";
            //var queueName = "testqueue";

            //var servicebusClient = new ServiceBusClient(connectionString);

            //var sender = servicebusClient.CreateSender(queueName);

            //var batch = await sender.CreateMessageBatchAsync();

            //batch.TryAddMessage(new ServiceBusMessage("I am Prasad"));
            //batch.TryAddMessage(new ServiceBusMessage("I am Archana"));

            //await sender.SendMessagesAsync(batch);


            #endregion using ServiceBusMessageBatch


            #region Sending session messages

            string connectionString = "Endpoint=sb://cbpt01datdevaatmessaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UP53ArBOBjE2gWAXLOmBEqiZ/mSdlh+sdbu4J9zJyQs=";
            string queue = "testqueue";

            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queue);

            var batch = await sender.CreateMessageBatchAsync();

            batch.TryAddMessage(new ServiceBusMessage("I am Pramod") { SessionId = "1" });
            batch.TryAddMessage(new ServiceBusMessage("I am Praveen") { SessionId = "2" });
            batch.TryAddMessage(new ServiceBusMessage("I am Prasad") { SessionId = "1" });

            await sender.SendMessagesAsync(batch);


            #endregion Sending session messages

            #endregion queue


            #region topic

            #region without batch

            //string connString = "Endpoint=sb://cbpt01datdevaatmessaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UP53ArBOBjE2gWAXLOmBEqiZ/mSdlh+sdbu4J9zJyQs=";

            //var servicebusclient = new ServiceBusClient(connString);

            //var servicebusSender = servicebusclient.CreateSender("test");

            //var topicMessage = new ServiceBusMessage("I am Pramod. I am sending message to test topic");
            //topicMessage.Subject = "Introduction";

            //await servicebusSender.SendMessageAsync(topicMessage);

            //Console.ReadLine();

            #endregion without batch

            #region with batch


            #endregion with batch

            #endregion topic
        }
    }
}