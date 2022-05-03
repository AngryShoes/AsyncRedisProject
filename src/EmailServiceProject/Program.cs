using System;

namespace EmailServiceProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mq = new RedisMQ("localHost:6379"))
            {
                Console.WriteLine("Email ....");
                while (true)
                {
                    string message = mq.DeQueue("wo_email", TimeSpan.FromSeconds(10));
                    if (message != null)
                    {
                        EmailService emailService = new EmailService();
                        emailService.SendAsync(message);
                    }
                }
            }
        }
    }
}
