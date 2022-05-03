using System;

namespace AsyncRedisProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ReactiveWOService reactiveWOService = new ReactiveWOService();
            reactiveWOService.CreateWO();
            Console.ReadKey();
        }
    }
}
