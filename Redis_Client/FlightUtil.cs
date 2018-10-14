using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Redis_Client
{
    class FlightUtil
    {
        readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis, 127.0.0.1:6379");
        public void GetClientFlightInfo()
        {

        }
    }
}
