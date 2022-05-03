using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncRedisProject
{
    public class EmailService
    {
        public  void  SendAsync(string woNumber)
        {
            Console.WriteLine("===================Start Send Email=====================");
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine($"==========Send Email Finished,Email for {woNumber}==========");
        }
    }
}
