using System;

namespace Upstream
{
    class Program
    {
        static void Main(string[] args)
        {
            UpstreamService upstream = new UpstreamService();
            upstream.CreateSkillOrder(10000);
            Console.ReadKey();
        }
    }
}
