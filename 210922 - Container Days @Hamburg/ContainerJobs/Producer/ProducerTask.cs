using Common;
using Microsoft.Azure.ServiceBus;
using System;
using System.Linq;
using System.Text;
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
            var qc = new QueueClient(Constants.SBConnection, Constants.SBTodoQueue,
                ReceiveMode.PeekLock);
            for (int i = 0; i < 10; i++)
            {
                var messages = Enumerable.Range(0, 3000)
                    .Select(p => new Message(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())))
                    .ToList();
                await qc.SendAsync(messages);
            }

        }
    }
}