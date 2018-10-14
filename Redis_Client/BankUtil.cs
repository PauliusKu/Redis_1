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
        readonly string bankAcout = "BankAcc:";
        IDatabase db;
        public decimal GetClientsAmount(int userId)
        {
            db = redis.GetDatabase();
            RedisValue amount = db.StringGet(bankAcout + userId);
            if (amount.IsNull)
            {
                return -1;
            }
            else return (decimal)amount;
        }

        public bool MoneyTransfer(int userId1, int userId2, decimal amount)
        {
            db = redis.GetDatabase();
            decimal dAmount1 = (decimal)db.StringGet(bankAcout + userId1);
            decimal dAmount2 = (decimal)db.StringGet(bankAcout + userId2);

            if (dAmount1 - amount < 0) return false;

            string sAmount1 = dAmount1.ToString();
            string sAmount2 = dAmount2.ToString();

            var tran = db.CreateTransaction();
            //tran.AddCondition(Condition.StringEqual(bankAcout + userId1, sAmount1));
            //tran.AddCondition(Condition.StringEqual(bankAcout + userId2, sAmount2));
            dAmount1 -= amount;
            dAmount2 += amount;
            sAmount1 = dAmount1.ToString();
            sAmount2 = dAmount2.ToString();
            tran.StringSetAsync(bankAcout + userId1, sAmount1);
            tran.StringSetAsync(bankAcout + userId2, sAmount2);
            return tran.Execute();
        }

    }
}
