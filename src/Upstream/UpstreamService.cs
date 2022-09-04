using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upstream
{
    public class UpstreamService
    {
        private readonly int MaxRequestCounts = 1000;
        public void CreateSkillOrder(int RequestCounts)
        {
            // 1、创建秒杀订单
            Console.WriteLine($"Request count:{RequestCounts}");

            // 1.1 模拟系统宕机
            /*if (HandlerRequestCounts < RequestCounts)
            {
                throw new Exception($"系统宕机:目前请求数：{RequestCounts}，能够处理请求数：{HandlerRequestCounts}");
            }*/

            // redis优化流量请求
            using (var messageQueue = new RedisMQ("localhost:6379"))
            {
                // 1、循环写入队列
                for (int i = 0; i < RequestCounts; i++)
                {
                    // 1.1 获取消息队列数量
                    long count = messageQueue.GetQueueCount("grab_ball");

                    // 1.2 判断是否已满
                    if (count > MaxRequestCounts)
                    {
                        Console.WriteLine($"Busy，Please wait minutes...");
                    }
                    else
                    {
                        // 1.3 写入队列
                        Console.WriteLine($"into queue...");
                        messageQueue.EnQueue("grab_ball", i + "");
                    }
                }

            }
        }
    }
}
