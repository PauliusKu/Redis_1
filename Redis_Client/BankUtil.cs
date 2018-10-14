using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Redis_Client
{
    class BankUtil
    {
        readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis, 127.0.0.1:6379");
        readonly string BankAcout = "BankAcc:";
        IDatabase db;
        public decimal GetClientsAmount(int userId)
        {
            Console.WriteLine(userId);
            db = redis.GetDatabase();
            RedisValue amount = db.ListRightPop(BankAcout + userId);
            if (amount.IsNull)
            {
                return -1;
            }
            else return (decimal)amount;
        }
    }
}
