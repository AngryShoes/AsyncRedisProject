using System;

namespace MessageServiceProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mq=new RedisMQ("localhost:6379"))
            {
                Console.WriteLine("Text Message....");
                while (true)
                {
                    string message = mq.DeQueue("wo_message", TimeSpan.FromSeconds(10));
                    if (message!=null)
                    {
                        TextMessageService textMessageService = new TextMessageService();
                        textMessageService.SendAsync(message);

                    }
                }
            }
        }
    }
}
