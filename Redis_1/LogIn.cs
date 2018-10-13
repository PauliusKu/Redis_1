using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StackExchange.Redis;

namespace Redis_1
{
    public partial class LogIn : Form
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost");
        public LogIn()
        {
            InitializeComponent();
        }

        private void ButLogIn_Click(object sender, EventArgs e)
        {
            IDatabase db = redis.GetDatabase();
            Random rnd = new Random();
            int value = rnd.Next(1, 100);
            db.StringSet("mykey", value);
            string retrievevalue = db.StringGet("mykey");
            textBox1.Text = retrievevalue;
        }
    }
}
