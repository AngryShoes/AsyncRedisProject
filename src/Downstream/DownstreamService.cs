using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Downstream
{
    public class DownstreamService
    {
        public void HandlerRequest(string requestCount)
        {

            Thread.Sleep(10);
            // 1、创建订单
            Console.WriteLine($"秒杀订单创建成功");
            // 2、扣减库存
            Console.WriteLine($"秒杀订单库存扣减生成");
            // 3、扣减余额
            Console.WriteLine($"用户余额扣减成功");

            Console.WriteLine($"处理的请求数:{requestCount}");
        }
    }
}
