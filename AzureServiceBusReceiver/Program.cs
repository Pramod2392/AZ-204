using Azure.Messaging.ServiceBus;

namespace AzureServiceBusReceiver
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Receive message using ServiceBus receiver from a queue

            #region queue

            #region without batch

            //string connectionString = "Endpoint=sb://namespace-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=vyWuHoGc1Z5EQg9EmJuEq3RMTaQFuo92c+ASbPXIi58=";
            //string queueName = "testqueue";

            //var client = new ServiceBusClient(connectionString);

            //var receiver = client.CreateReceiver(queueName);

            //var receivedMessage = await receiver.ReceiveMessageAsync();

            //Console.WriteLine(receivedMessage.Body.ToString());

            //await receiver.CompleteMessageAsync(receivedMessage);

            //Console.ReadLine();

            #endregion without batch

            #region with batch

            //string connectionString = "Endpoint=sb://namespace-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=vyWuHoGc1Z5EQg9EmJuEq3RMTaQFuo92c+ASbPXIi58=";
            //string queueName = "testqueue";

            //var client = new ServiceBusClient(connectionString);

            //var receiver = client.CreateReceiver(queueName);

            //var receivedMessages = await receiver.ReceiveMessagesAsync(maxMessages: 2);

            //foreach (var receivedMessage in receivedMessages)
            //{
            //	Console.WriteLine(receivedMessage.Body.ToString());
            //    await receiver.CompleteMessageAsync(receivedMessage);
            //}



            //Console.ReadLine();


            #endregion with batch

            #region Receiving session messages

            //string connectionString = "Endpoint=sb://cbpt01datdevaatmessaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UP53ArBOBjE2gWAXLOmBEqiZ/mSdlh+sdbu4J9zJyQs=";
            //string queueName = "testqueue";

            //var client = new ServiceBusClient(connectionString);
            //var receiver = await client.AcceptNextSessionAsync(queueName);

            //var messages = receiver.ReceiveMessagesAsync();

            //await foreach (var msg in messages)
            //{
            //    Console.WriteLine ($"Session Id: {msg.SessionId}, Body: {msg.Body.ToString()}" );
            //    await receiver.CompleteMessageAsync(msg);
            //}


            //Console.ReadLine();


            #endregion Receiving session messages


            #region receive messages using Service bus processor

            //string connectionString = "Endpoint=sb://namespace-servicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=vyWuHoGc1Z5EQg9EmJuEq3RMTaQFuo92c+ASbPXIi58=";
            //string queueName = "testqueue";

            //await using var sbClient = new ServiceBusClient(connectionString);  

            //await using var processor = sbClient.CreateProcessor(queueName);

            //processor.ProcessMessageAsync += Processor_ProcessMessageAsync;
            //processor.ProcessErrorAsync += Processor_ProcessErrorAsync;


            //async Task Processor_ProcessErrorAsync(ProcessErrorEventArgs arg)
            //{
            //    Console.WriteLine(arg.Exception.Message);
            //    Task.CompletedTask.Wait();
            //}

            //async Task Processor_ProcessMessageAsync(ProcessMessageEventArgs arg)
            //{
            //    Console.WriteLine(arg.Message.Body.ToString());
            //    Task.CompletedTask.Wait();
            //}

            //try
            //{
            //    CancellationToken token = new CancellationToken();
            //    token.ThrowIfCancellationRequested();
            //	await processor.StartProcessingAsync(token);

            //    Console.ReadLine();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            #endregion receive messages using Service bus processor


            #region receive messages using Service bus session processor

            string connectionString = "Endpoint=sb://cbpt01datdevaatmessaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UP53ArBOBjE2gWAXLOmBEqiZ/mSdlh+sdbu4J9zJyQs=";
            string queueName = "testqueue";

            var sbClient = new ServiceBusClient(connectionString);
            ServiceBusSessionProcessorOptions options = new ServiceBusSessionProcessorOptions();
            options.SessionIds.Add("1");
            var processor = sbClient.CreateSessionProcessor(queueName, options);
            processor.ProcessMessageAsync += Processor_ProcessMessageAsync;
            processor.ProcessErrorAsync += Processor_ProcessErrorAsync;

            async Task Processor_ProcessErrorAsync(ProcessErrorEventArgs arg)
            {
                Console.WriteLine(arg.Exception.Message.ToString());
                Task.CompletedTask.Wait();
            }

            async Task Processor_ProcessMessageAsync(ProcessSessionMessageEventArgs arg)
            {
                Console.WriteLine(arg.Message.Body.ToString());
                Task.CompletedTask.Wait();
            }

            await processor.StartProcessingAsync();

            Console.ReadLine();

            #endregion receive messages using Service bus session processor

            #endregion queue



            #region topic

            //string connectionString = "Endpoint=sb://cbpt01datdevaatmessaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=UP53ArBOBjE2gWAXLOmBEqiZ/mSdlh+sdbu4J9zJyQs=";
            //string topicName = "test";
            //string subName = "sub2";

            //var servicebusclient = new ServiceBusClient(connectionString);

            //var servicebusReceiver = servicebusclient.CreateReceiver(topicName, subName);
            //var receivedMessages = servicebusReceiver.ReceiveMessagesAsync();

            //await foreach (var receivedMsg in receivedMessages)
            //{
            //    Console.WriteLine(receivedMsg.Body.ToString());
            //    await servicebusReceiver.CompleteMessageAsync(receivedMsg);
            //}

            //Console.ReadLine();

            #endregion topic
        }
    }
}