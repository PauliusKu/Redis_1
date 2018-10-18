using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackExchange.Redis;

namespace Redis_Client
{
    static class ProgramCln
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BankUtil bUtil = new BankUtil();
            //bUtil.MoneyTransfer(1000, 1001, 1);  //transaction test
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }
    }
    public static class DbConn
    {
        public static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis, 127.0.0.1:6379");

    }
}
