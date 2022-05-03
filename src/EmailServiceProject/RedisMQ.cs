using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmailServiceProject
{
    public class RedisMQ : IDisposable
    {
        private RedisClient _redisClient;
        public RedisMQ(string redisHost)
        {
            this._redisClient = new RedisClient(redisHost);
        }

        public long EnQueue(string key,string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            var count = _redisClient.LPush(key, messageBytes);
            return count;
        }

        /// <summary>
        /// 非阻塞出队 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string DeQueue(string key)
        {
            byte[] messageBytes = _redisClient.RPop(key);
            string message = string.Empty;
            if (messageBytes==null)
            {
                Console.WriteLine("队列中没有数据......");
            }
            else
            {
                message = Encoding.UTF8.GetString(messageBytes);
            }
            return message;
        }

        /// <summary>
        /// 阻塞出队
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public string DeQueue(string key, TimeSpan? timeSpan)
        {
            string message = _redisClient.BlockingPopItemFromList(key, timeSpan);
            return message;
        }

        public void Dispose()
        {
            _redisClient.Dispose();
        }

    }
}
