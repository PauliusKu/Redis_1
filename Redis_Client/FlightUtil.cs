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
        readonly string flightIdSet = "FlightIdSet:";
        readonly string flightHash = "FlightHash:";
        readonly string flightPassSet = "FlightPassSet:";
        readonly string clientFlightsSet = "clnFlSet:";
        readonly string passFlightOrderAmount = "PassFlOrdAmt:";
        readonly string flightPassSetHis = "FlightPassSetHis:";
        readonly string clientFlightsSetHis = "clnFlSetHis:";
        IDatabase db;
        public string GetClientFlightInfo(int clnId)
        {
            db = DbConn.redis.GetDatabase();

            RedisValue[] flightsId = db.SetCombine(SetOperation.Intersect, flightIdSet, clientFlightsSet + clnId);
            string flights = "";
            string delimiter = ";";
            foreach (int itr in flightsId)
            {
                RedisValue[] flight = db.HashValues(flightHash + itr);
                for (int i = 0; i < flight.Length - 1; i++)
                {
                    flights += flight.ElementAt(i).ToString();
                    flights += delimiter;
                }
                flights += db.StringGet(passFlightOrderAmount + clnId + ":" + itr);
                flights += delimiter;

            }
            Console.WriteLine(flights);
            return flights;
        }

        public string GetSystemFlightInfo()
        {
            db = DbConn.redis.GetDatabase();

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
            db = DbConn.redis.GetDatabase();
            return (decimal)db.HashGet(flightHash + flightId, "COST");
        }

        public bool IsEnoughTicket(int flightId, int amount)
        {
            db = DbConn.redis.GetDatabase();
            if ((int)db.HashGet(flightHash + flightId, "LEFT") >= amount)
                return true;
            return false;
        }

        public void BookFlight(int flightId, int clnId, int orderAmount)
        {
            db = DbConn.redis.GetDatabase();
            db.SetAdd(flightPassSet + flightId, clnId);
            db.HashSet(flightHash + flightId, "LEFT", (int)db.HashGet(flightHash + flightId, "LEFT") - orderAmount);
            db.SetAdd(clientFlightsSet + clnId, flightId);
            orderAmount += (int)db.StringGet(passFlightOrderAmount + clnId + ":" + flightId);
            db.StringSet(passFlightOrderAmount + clnId + ":" + flightId, orderAmount);
        }

        public void UnBookFlight(int flightId, int clnId, int orderAmount)
        {
            db = DbConn.redis.GetDatabase();
            db.HashSet(flightHash + flightId, "LEFT", (int)db.HashGet(flightHash + flightId, "LEFT") + orderAmount);
            orderAmount = (int)db.StringGet(passFlightOrderAmount + clnId + ":" + flightId) - orderAmount;
            if (orderAmount == 0)
            {
                db.SetMove(flightPassSet + flightId, flightPassSetHis + flightId, clnId);
                db.SetMove(clientFlightsSet + clnId, clientFlightsSetHis + clnId, flightId);
            }
            db.StringSet(passFlightOrderAmount + clnId + ":" + flightId, orderAmount);
        }

        public int GetFlightOrderAmount(int flightId, int clnId)
        {
            db = DbConn.redis.GetDatabase();
            return (int)db.StringGet(passFlightOrderAmount + clnId + ":" + flightId);
        }

        public bool IsFlightClnBooked(int flightId, int clnId)
        {
            db = DbConn.redis.GetDatabase();
            RedisValue[] flightsId = db.SetMembers(clientFlightsSet + clnId);
            foreach (var itr in flightsId)
            {
                Console.WriteLine("line " + itr + "  " + flightId);
                if (itr == flightId) return true;
            }
            return false;
        }

        public int GetLeftTicketsAmount(int flightId)
        {
            db = DbConn.redis.GetDatabase();
            return (int)db.HashGet(flightHash + flightId, "LEFT");
        }

        public string GetFlightFromAirport(int flightId)
        {
            db = DbConn.redis.GetDatabase();
            return db.HashGet(flightHash + flightId, "FROM");
        }

        public string GetFlightToAirport(int flightId)
        {
            db = DbConn.redis.GetDatabase();
            return db.HashGet(flightHash + flightId, "TO");
        }
    }
}
