using Common;
using Microsoft.Azure.ServiceBus;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer
{
    internal class ConsumerTask
    {
        public ConsumerTask()
        {
        }

        public async Task RunAsync()
        {
            var qc = new QueueClient(Constants.SBConnection, Constants.SBTodoQueue,
               ReceiveMode.PeekLock);
            qc.RegisterMessageHandler(async (msg, token) =>
            {
                System.Console.WriteLine(Encoding.UTF8.GetString(msg.Body));
                await Task.Delay(1000);
            },new MessageHandlerOptions(args => Task.CompletedTask)
            {
                AutoComplete=true
            });
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}