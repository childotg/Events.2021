using Azure.Messaging.ServiceBus;
using Common;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Producer
{
    internal class ProducerTask
    {
        public ProducerTask()
        {
        }

        internal async Task RunAsync()
        {
            var client = new ServiceBusClient(Constants.SBConnection)
                .CreateSender(Constants.SBTodoQueue);

            var random = new Random();
            var messages = Enumerable.Range(0, 10000)
                .Select(p => new ServiceBusMessage(
                        JsonConvert.SerializeObject(new MessageModel
                        {
                            A = random.Next(10000),
                            B = random.Next(10000)
                        }
                    )));

            var batch = await client.CreateMessageBatchAsync();
            foreach (var item in messages)
            {
                if (batch.Count == 4500 || !batch.TryAddMessage(item))
                {
                    Console.WriteLine("Sending a batch...");
                    await client.SendMessagesAsync(batch);
                    batch = await client.CreateMessageBatchAsync();
                }
            }
            Console.WriteLine("Sending a batch...");
            await client.SendMessagesAsync(batch);

        }
    }
}