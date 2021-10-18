using Azure.Messaging.ServiceBus;
using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    public class ConsumerTask
    {

        public async Task RunAsync()
        {
            var client = new ServiceBusClient(Constants.SBConnection)
               .CreateReceiver(Constants.SBTodoQueue);

            while (true)
            {
                var message = await client.ReceiveMessageAsync(TimeSpan.FromSeconds(60));
                var op = JsonConvert.DeserializeObject<MessageModel>(message.Body.ToString());
                Console.WriteLine($"Result of A:{op.A} B:{op.B} is {op.A + op.B}");
                await client.CompleteMessageAsync(message);
                await Task.Delay(1000);
            }
        }
    }
}