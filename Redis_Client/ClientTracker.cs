using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis_Client
{
    public class ClientTracker
    {
        ISession session;
        PreparedStatement insert1, insert2, select1, select2;
        DateTime start;
        int flId, clnId;
        bool isOrd;
        int result = 0;
        public void Start_Tracking()
        {
            session = DbConn.cluster.Connect();

            insert1 = session.Prepare("INSERT INTO redis_fly.flight_to_client (flightId, clnId, startTime, durration) values (?, ?, ?, ?)");
            insert2 = session.Prepare("INSERT INTO redis_fly.client_to_flight (flightId, clnId, startTime, durration) values (?, ?, ?, ?);");
            select1 = session.Prepare("SELECT clnId, startTime, durration FROM redis_fly.flight_to_client WHERE flightId=?");
            select2 = session.Prepare("SELECT flightId, startTime, durration FROM redis_fly.client_to_flight WHERE clnid=?");
        }

        public void Start_Timer(int flightId, int clientId, bool isOrder)
        {
            flId = flightId;
            clnId = clientId;
            isOrd = isOrder;
            start = DateTime.Now;
        }

        public void Set_Result(int OrderResult)
        {
            result = OrderResult;
        }

        public void End_Timer()
        {

            var batch = new BatchStatement()
            .Add(insert1.Bind(flId, clnId, DateTime.Now, DateTime.Now.Subtract(start).TotalSeconds))
            .Add(insert2.Bind(flId, clnId, DateTime.Now, DateTime.Now.Subtract(start).TotalSeconds));

            session.Execute(batch);
        }

        public List<Row> GetClientInfoByFlight(int flightId)
        {
            var statement = select1.Bind(flightId);

            return session.Execute(statement).ToList();
        }

        public List<Row> GetFlightInfoByClient(int clnId)
        {
            var statement = select2.Bind(clnId);

            return session.Execute(statement).ToList();
        }
    }
}
