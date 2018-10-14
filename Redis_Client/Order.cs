using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Redis_Client
{
    public partial class Order : Form
    {
        int clnId = -1;
        int flightId = -1;
        public Order(int cId, int flId)
        {
            clnId = cId;
            flightId = flId;
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {

        }

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnId);
            clnviewhelp.MakeOrder(flightId);
            this.Close();
        }
    }
}
