using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_Client
{
    class AdminViewHelper
    {
        public string GetFlightData(int flightNum)
        {
            string data = "";
            string delimiter = ";";

            List<string> trackerInfo = GetClnFromClnTrack(flightNum);

            for (var i = 0; i < trackerInfo.Count; i++)
            {
                data += trackerInfo[i];
                data += delimiter;
                if (i % 4 == 0)
                {
                    List<string> redisInfo = GetClnFromRedis(Int32.Parse(trackerInfo[i]), flightNum);
                    foreach(var j in redisInfo)
                    {
                        data += j;
                        data += delimiter;
                    }
                }
            }

            return data;
        }

        public string GetClientData(int clnId)
        {
            string data = "";
            string delimiter = ";";

            List<string> trackerInfo = GetFlightFromClnTrack(clnId);

            for (var i = 0; i < trackerInfo.Count; i++)
            {
                data += trackerInfo[i];
                data += delimiter;
                if (i % 4 == 0)
                {
                    List<string> redisInfo = GetFlightFromRedis(clnId, Int32.Parse(trackerInfo[i]));
                    foreach (var j in redisInfo)
                    {
                        data += j;
                        data += delimiter;
                    }
                }
            }

            return data;
        }

        private List<string> GetClnFromClnTrack(int flightNum)
        {
            List<string> Results = new List<string>();

            ClientTracker clnTrack = new ClientTracker();
            clnTrack.Start_Tracking();

            var clnInfo = clnTrack.GetClientInfoByFlight(flightNum);
            int totalVisits = 0;
            double totalDuration = 0;
            DateTime lastDate = new DateTime();

            int clnId = -1;
            foreach (var row in clnInfo)
            {
                if (clnId != row.GetValue<int>("clnid") && clnId != -1)
                {
                    Results.Add(clnId.ToString());
                    Results.Add(totalDuration.ToString());
                    Results.Add(totalVisits.ToString());
                    Results.Add(lastDate.ToString());

                    totalVisits = 0;
                    totalDuration = 0;
                }
                clnId = row.GetValue<int>("clnid");
                totalDuration += row.GetValue<double>("durration");
                totalVisits++;
                lastDate = row.GetValue<DateTime>("starttime");
            }
            Results.Add(clnId.ToString());
            Results.Add(totalDuration.ToString());
            Results.Add(totalVisits.ToString());
            Results.Add(lastDate.ToString());

            return Results;
        }

        private List<string> GetFlightFromClnTrack(int clnId)
        {
            List<string> Results = new List<string>();

            ClientTracker clnTrack = new ClientTracker();
            clnTrack.Start_Tracking();

            var clnInfo = clnTrack.GetFlightInfoByClient(clnId);
            int totalVisits = 0;
            double totalDuration = 0;
            DateTime lastDate = new DateTime();

            int flightId = -1;
            foreach (var row in clnInfo)
            {
                if (flightId != row.GetValue<int>("flightid") && flightId != -1)
                {
                    Results.Add(flightId.ToString());
                    Results.Add(totalDuration.ToString());
                    Results.Add(totalVisits.ToString());
                    Results.Add(lastDate.ToString());

                    totalVisits = 0;
                    totalDuration = 0;
                }
                flightId = row.GetValue<int>("flightid");
                totalDuration += row.GetValue<double>("durration");
                totalVisits++;
                lastDate = row.GetValue<DateTime>("starttime");
            }
            Results.Add(flightId.ToString());
            Results.Add(totalDuration.ToString());
            Results.Add(totalVisits.ToString());
            Results.Add(lastDate.ToString());

            return Results;
        }

        private List<string> GetClnFromRedis(int clnId, int flightNum)
        {
            List<string> redisData = new List<string>();

            string username = "";
            string email = "";

            ClientUtil clnUt = new ClientUtil();
            FlightUtil flUt = new FlightUtil();

            clnUt.GetClientInfo(clnId, out username, out email);
            redisData.Add(username);
            redisData.Add(email);
            redisData.Add(flUt.GetFlightOrderAmount(flightNum, clnId).ToString());

            return redisData;
        }

        private List<string> GetFlightFromRedis(int clnId, int flightNum)
        {
            List<string> redisData = new List<string>();

            ClientUtil clnUt = new ClientUtil();
            FlightUtil flUt = new FlightUtil();
            redisData.Add(flUt.GetFlightFromAirport(flightNum));
            redisData.Add(flUt.GetFlightToAirport(flightNum));
            redisData.Add(flUt.GetFlightCost(flightNum).ToString());
            redisData.Add(flUt.GetFlightOrderAmount(flightNum, clnId).ToString());

            return redisData;
        }

        public void GetFlightInfoFromRedis(int flightNum, ref string from, ref string to, ref string date, ref string cost, ref string leftTickets)
        {
            FlightUtil flUt = new FlightUtil();
            from = flUt.GetFlightFromAirport(flightNum);
            to = flUt.GetFlightToAirport(flightNum);
            date = flUt.GetFlightDate(flightNum);
            cost = flUt.GetFlightCost(flightNum).ToString();
            leftTickets = flUt.GetLeftTicketsAmount(flightNum).ToString();
        }

        public void GetClientInfoFromRedis(int clnId, ref string name, ref string email, ref string money, ref string booked)
        {
            ClientTracker clnTrack = new ClientTracker();
            clnTrack.Start_Tracking();

            ClientUtil clnUt = new ClientUtil();
            BankUtil bnkUt = new BankUtil();
            clnUt.GetClientInfo(clnId, out name, out email);
            money = bnkUt.GetClientsAmount(clnId).ToString();

            var row = clnTrack.GetClientBookedTotal(clnId).First();
            booked = row.GetValue<int>("system.sum(action)").ToString();
        }

        public string GetDetailedData(int flightId, int clientId)
        {
            ClientTracker clnTrack = new ClientTracker();
            clnTrack.Start_Tracking();

            string data = "";
            string delimiter = ";";

            var trackerInfo = clnTrack.GetVisistsDetails(flightId, clientId);

            foreach (var row in trackerInfo)
            {

                data += row.GetValue<DateTime>("starttime").ToString() + delimiter;
                data += row.GetValue<double>("durration").ToString() + delimiter;
                data += row.GetValue<int>("action").ToString() + delimiter;
            }

            return data;
        }
    }
}
