using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncRedisProject
{
   public class ReactiveWOService
    {
        public void CreateWO()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("==========Start Create WO==========");
            var woNumber = GenerateWo();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Console.WriteLine($"========WO Created：Wo Number：{woNumber}========");
            Console.WriteLine(Environment.NewLine);

            //EmailService emailService = new EmailService();
            //emailService.SendAsync(woNumber);
            //Console.WriteLine(Environment.NewLine);

            //TextMessageService textMessageService = new TextMessageService();
            //textMessageService.SendAsync(woNumber);
            //Console.WriteLine(Environment.NewLine);

            using (var mq = new RedisMQ("localhost:6379"))
            {
                mq.EnQueue("wo_email", $"{woNumber}");
                mq.EnQueue("wo_message", $"{woNumber}");

            }
            stopwatch.Stop();
            Console.WriteLine($"Finished，Time-Span：{stopwatch.ElapsedMilliseconds} ms");
        }

        private string GenerateWo()
        {
            Random random = new Random();
            return string.Concat("C", DateTime.Now.ToString("yyyyMMddHHmmssff"), random.Next(100, 999));
        }
    }


}
