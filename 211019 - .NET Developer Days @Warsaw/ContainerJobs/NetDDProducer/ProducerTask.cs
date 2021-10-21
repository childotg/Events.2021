using Azure.Messaging.ServiceBus;
using Common;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetDDProducer
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
            var messages = Enumerable.Range(0, 4000)
                .Select(p => new ServiceBusMessage(JsonConvert
                        .SerializeObject(new MessageModel()
                        {
                            A = random.Next(0, 10000),
                            B = random.Next(0, 10000)
                        }))).ToArray();

            var batch = await client.CreateMessageBatchAsync();

            foreach (var message in messages)
            {
                if (!batch.TryAddMessage(message))
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