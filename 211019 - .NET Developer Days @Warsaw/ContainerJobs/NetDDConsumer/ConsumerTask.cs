using Azure.Messaging.ServiceBus;
using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetDDConsumer
{
    public class ConsumerTask
    {
        internal async Task RunAsync()
        {
            var client = new ServiceBusClient(Constants.SBConnection)
                .CreateReceiver(Constants.SBTodoQueue);

            while (true)
            {
                var message = await client.ReceiveMessageAsync(
                    TimeSpan.FromSeconds(10));
                if (message != null)
                {
                    await Task.Delay(1000);
                    var obj = JsonConvert.DeserializeObject<MessageModel>(
                        message.Body.ToString());
                    await client.CompleteMessageAsync(message);
                    Console.WriteLine($"A:{obj.A} B:{obj.B} - Result {obj.A+obj.B}");
                }
            }
        }
    }
    
}
