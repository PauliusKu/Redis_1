using System.Linq;
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
        IDatabase _database;
        public string GetClientFlightInfo(int clnId)
        {
            _database = DbConn.redis.GetDatabase();

            RedisValue[] flightsId = _database.SetCombine(SetOperation.Intersect, flightIdSet, clientFlightsSet + clnId);
            string flights = "";
            string delimiter = ";";
            foreach (int itr in flightsId)
            {
                RedisValue[] flight = _database.HashValues(flightHash + itr);
                for (int i = 0; i < flight.Length - 1; i++)
                {
                    flights += flight.ElementAt(i).ToString();
                    flights += delimiter;
                }
                flights += _database.StringGet(passFlightOrderAmount + clnId + ":" + itr);
                flights += delimiter;

            }
            return flights;
        }

        public string GetSystemFlightInfo()
        {
            _database = DbConn.redis.GetDatabase();

            RedisValue[] flightsId = _database.SetMembers(flightIdSet);
            string flights = "";
            string delimiter = ";";
            foreach (int itr in flightsId)
            {
                RedisValue[] flight = _database.HashValues(flightHash + itr);
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
            _database = DbConn.redis.GetDatabase();
            return (decimal)_database.HashGet(flightHash + flightId, "COST");
        }

        public bool IsEnoughTicket(int flightId, int amount)
        {
            _database = DbConn.redis.GetDatabase();
            if ((int)_database.HashGet(flightHash + flightId, "LEFT") >= amount)
                return true;
            return false;
        }

        public void BookFlight(int flightId, int clnId, int orderAmount)
        {
            _database = DbConn.redis.GetDatabase();
            _database.SetAdd(flightPassSet + flightId, clnId);
            _database.HashSet(flightHash + flightId, "LEFT", (int)_database.HashGet(flightHash + flightId, "LEFT") - orderAmount);
            _database.SetAdd(clientFlightsSet + clnId, flightId);
            orderAmount += (int)_database.StringGet(passFlightOrderAmount + clnId + ":" + flightId);
            _database.StringSet(passFlightOrderAmount + clnId + ":" + flightId, orderAmount);
        }

        public void UnBookFlight(int flightId, int clnId, int orderAmount)
        {
            _database = DbConn.redis.GetDatabase();
            _database.HashSet(flightHash + flightId, "LEFT", (int)_database.HashGet(flightHash + flightId, "LEFT") + orderAmount);
            orderAmount = (int)_database.StringGet(passFlightOrderAmount + clnId + ":" + flightId) - orderAmount;
            if (orderAmount == 0)
            {
                _database.SetMove(flightPassSet + flightId, flightPassSetHis + flightId, clnId);
                _database.SetMove(clientFlightsSet + clnId, clientFlightsSetHis + clnId, flightId);
            }
            _database.StringSet(passFlightOrderAmount + clnId + ":" + flightId, orderAmount);
        }

        public int GetFlightOrderAmount(int flightId, int clnId)
        {
            _database = DbConn.redis.GetDatabase();
            return (int)_database.StringGet(passFlightOrderAmount + clnId + ":" + flightId);
        }

        public bool IsFlightClnBooked(int flightId, int clnId)
        {
            _database = DbConn.redis.GetDatabase();
            RedisValue[] flightsId = _database.SetMembers(clientFlightsSet + clnId);
            foreach (var itr in flightsId)
                if (itr == flightId) return true;
            return false;
        }

        public int GetLeftTicketsAmount(int flightId)
        {
            _database = DbConn.redis.GetDatabase();
            return (int)_database.HashGet(flightHash + flightId, "LEFT");
        }

        public string GetFlightFromAirport(int flightId)
        {
            _database = DbConn.redis.GetDatabase();
            return _database.HashGet(flightHash + flightId, "FROM");
        }

        public string GetFlightToAirport(int flightId)
        {
            _database = DbConn.redis.GetDatabase();
            return _database.HashGet(flightHash + flightId, "TO");
        }

        public string GetFlightDate(int flightId)
        {
            _database = DbConn.redis.GetDatabase();
            return _database.HashGet(flightHash + flightId, "DATE");
        }
    }
}
