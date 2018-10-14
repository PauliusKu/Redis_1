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
        readonly string flightIdSet = "FlightIdSet:";
        readonly string flightHash = "FlightHash:";
        readonly string flightPassSet = "FlightPassSet:";
        readonly string clientFlightsSet = "clnFlSet:";
        IDatabase db;
        public string GetClientFlightInfo(int clnId)
        {
            db = redis.GetDatabase();

            RedisValue[] flightsId = db.SetCombine(SetOperation.Intersect, flightIdSet, clientFlightsSet + clnId);
            string flights = "";
            string delimiter = ";";
            foreach (int itr in flightsId)
            {
                RedisValue[] flight = db.HashValues(flightHash + itr);
                for (int i = 0; i < flight.Length; i++)
                {
                    flights += flight.ElementAt(i).ToString();
                    flights += delimiter;
                }
            }
            Console.WriteLine(flights);
            return flights;
        }

        public string GetSystemFlightInfo()
        {
            db = redis.GetDatabase();

            RedisValue[] flightsId = db.SetMembers(flightIdSet);
            string flights = "";
            string delimiter = ";";
            foreach (int itr in flightsId)
            {
                RedisValue[] flight = db.HashValues(flightHash + itr);
                for (int i = 0; i < flight.Length; i++)
                {
                    flights += flight.ElementAt(i).ToString();
                    flights += delimiter;
                }
            }
            return flights;
        }

        public decimal GetFlightCost(int flightId)
        {
            db = redis.GetDatabase();
            return (decimal)db.HashGet(flightHash + flightId, "COST");
        }

        public bool IsTicket(int flightId)
        {
            db = redis.GetDatabase();
            if ((decimal)db.HashGet(flightHash + flightId, "LEFT") > 0)
            {
                return true;
            }
            return false;
        }

        public void BookFlight(int flightId, int clnId)
        {
            db = redis.GetDatabase();
            db.SetAdd(flightPassSet + flightId, clnId);
            db.HashSet(flightHash + flightId, "LEFT", (int)db.HashGet(flightHash + flightId, "LEFT") - 1);
            db.SetAdd(clientFlightsSet + clnId, flightId);
        }
    }
}
