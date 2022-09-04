using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Downstream
{
    public class RedisMQ : IDisposable
    {
        private RedisClient _redisClient;
        public RedisMQ(string redisHost)
        {
            this._redisClient = new RedisClient(redisHost);
        }

        public long EnQueue(string key, string message)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            var count = _redisClient.LPush(key, messageBytes);
            return count;
        }

        /// <summary>
        /// DeQueue (Pull)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string DeQueue(string key)
        {
            byte[] messageBytes = _redisClient.RPop(key);
            string message = string.Empty;
            if (messageBytes == null)
            {
                Console.WriteLine("No Data in Queue......");
            }
            else
            {
                message = Encoding.UTF8.GetString(messageBytes);
            }
            return message;
        }

        /// <summary>
        /// Blocking pop item from queue(Push)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public string DeQueue(string key, TimeSpan? timeSpan)
        {
            string message = _redisClient.BlockingPopItemFromList(key, timeSpan);
            return message;
        }

        public long GetQueueCount(string QKey)
        {
            return _redisClient.GetListCount(QKey);
        }

        public void Dispose()
        {
            _redisClient.Dispose();
        }
    }
}
