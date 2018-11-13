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
        DateTime start;
        ISession session;
        PreparedStatement ps1, ps2;
        public void Start_Tracking()
        {
            session = DbConn.cluster.Connect();
            ps1 = session.Prepare("insert into redis_fly.sysObj_to_cln (sysObjId, clnId, start, time) values (?, ?, ?, ?)");
            ps2 = session.Prepare("SELECT clnid, start, time FROM redis_fly.sysObj_To_Cln where sysobjid=?");
        }

        public void Start_Timer()
        {
            start = DateTime.Now;
        }

        public void End_Timer(int sysObjId, int clnId)
        {
            var statement = ps1.Bind(sysObjId, clnId, DateTime.Now, DateTime.Now.Subtract(start).TotalSeconds);
            session.Execute(statement);
        }

        public List<Row> GetClientInfoByFlight(int flightId)
        {
            var statement = ps2.Bind(flightId);

            return session.Execute(statement).ToList();
        }
    }
}
