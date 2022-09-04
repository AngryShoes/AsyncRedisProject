using System;

namespace Downstream
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var mq = new RedisMQ("localHost:6379"))
            {
                Console.WriteLine("start ....");
                while (true)
                {
                    string current = mq.DeQueue("grab_ball", TimeSpan.FromSeconds(10));
                    DownstreamService downstream = new DownstreamService();
                    downstream.HandlerRequest(current);
                }
            }
        }
    }
}
