using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Redis_Client
{
    class ClientUtil
    {
        readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis, 127.0.0.1:6379");
        readonly string ClientNamesCounter = "ClnNamesCount";
        readonly string ClientHash = "ClnHash:";
        readonly string ClientName = "ClnName:";
        readonly string ClientPsw = "ClnPsw:";
        readonly string ClientMail = "ClnMail:";
        IDatabase db;
        public bool FindClient(string username, string password)
        {
            db = redis.GetDatabase();
            if (db.KeyExists(ClientName + username) && db.KeyExists(ClientPsw + password))
            {
                RedisValue[] intersection = db.SetCombine(SetOperation.Intersect, ClientName + username, ClientPsw + password);
                if (intersection.Length == 1) return true;
            }
            return false;
        }
        public void CreateClient(string username, string password, string mail)
        {
            int iNameID;
            string sNameID;

            db = redis.GetDatabase();
            sNameID = db.StringGet(ClientNamesCounter);

            if (!Int32.TryParse(sNameID, out iNameID))
            {
                iNameID = -1;
            }
            iNameID++;

            db.StringSet(ClientNamesCounter, iNameID);

            db.SetAdd(ClientName + username, iNameID);
            db.SetAdd(ClientPsw + password, iNameID);
            db.SetAdd(ClientMail + mail, iNameID);
            db.HashSet(ClientHash + iNameID, ClientName, username);
            db.HashSet(ClientHash + iNameID, ClientPsw, password);
            db.HashSet(ClientHash + iNameID, ClientMail, mail);
        }

        public bool IsUsernameExist(string username)
        {
            db = redis.GetDatabase();
            return db.KeyExists(ClientName + username);
        }

        public bool IsMailExist(string mail)
        {
            db = redis.GetDatabase();
            return db.KeyExists(ClientMail + mail);
        }

        public int GetId(string username)
        {
            db = redis.GetDatabase();

            RedisValue[] members = db.SetMembers(ClientName + username);

            if (members.Length == 1) return (int)members.First();
            else return -1;
        }

        public void GetClientInfo(int userID, out string username, out string mail)
        {
            db = redis.GetDatabase();
            username = db.HashGet(ClientHash + userID, ClientName);
            mail = db.HashGet(ClientHash + userID, ClientMail);
        }
    }
}
