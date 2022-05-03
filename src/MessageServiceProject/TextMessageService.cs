using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessageServiceProject
{
    public class TextMessageService
    {
        public void SendAsync(string woNumber)
        {
            Console.WriteLine("=====================Send Text Message Start==========================");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine($"==========Send Text Message Finished, Text Message For {woNumber}==========");
        }
    }
}
