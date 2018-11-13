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

            List<string> trackerInfo = GetFromClnTrack(flightNum);

            for (var i = 0; i < trackerInfo.Count; i++)
            {
                data += trackerInfo[i];
                data += delimiter;
                if (i % 4 == 0)
                {
                    List<string> redisInfo = GetFromRedis(Int32.Parse(trackerInfo[i]), flightNum);
                    foreach(var j in redisInfo)
                    {
                        data += j;
                        data += delimiter;
                    }
                }
            }

            return data;
        }

        private List<string> GetFromClnTrack(int flightNum)
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
                totalDuration += row.GetValue<double>("time");
                totalVisits++;
                lastDate = row.GetValue<DateTime>("start");
            }
            Results.Add(clnId.ToString());
            Results.Add(totalDuration.ToString());
            Results.Add(totalVisits.ToString());
            Results.Add(lastDate.ToString());

            return Results;
        }

        private List<string> GetFromRedis(int clnId, int flightNum)
        {
            List<string> redisData = new List<string>();

            string username = "";
            string email = "";
            string amount = "";

            ClientUtil clnUt = new ClientUtil();
            FlightUtil flUt = new FlightUtil();

            clnUt.GetClientInfo(clnId, out username, out email);
            amount = flUt.GetFlightOrderAmount(flightNum - 1000000, clnId).ToString();
            redisData.Add(username);
            redisData.Add(email);
            redisData.Add(amount);

            return redisData;
        }
    }
}
