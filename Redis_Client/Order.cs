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
        int ticketsAmount = 1;
        int ticketsMaxAmount = 0;
        decimal oneTicketCost = 0;
        decimal ticketsCost = 0;
        public Order(int cId, int flId)
        {
            clnId = cId;
            flightId = flId;
            InitializeComponent();
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnId);
            ticketsMaxAmount = clnviewhelp.GetLeftTicketsAmount(flightId);
            oneTicketCost = clnviewhelp.GetTicketsCost(flightId);
            ticketsCost = oneTicketCost;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            labelSum.Text = ticketsCost.ToString() + " EUR";
        }

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnId);
            clnviewhelp.MakeOrder(flightId, ticketsAmount);
            this.Close();
        }

        private void buttonLess_Click(object sender, EventArgs e)
        {
            if (ticketsAmount > 1)
            {
                ticketsAmount--;
                ticketsCost -= oneTicketCost;
                labelSum.Text = ticketsCost.ToString() + " EUR";
            }
            textBoxPassAmount.Text = ticketsAmount.ToString();
        }

        private void buttonMore_Click(object sender, EventArgs e)
        {
            if (ticketsAmount < ticketsMaxAmount)
            {
                ticketsAmount++;
                ticketsCost += oneTicketCost;
                labelSum.Text = ticketsCost.ToString() + " EUR";
            }
            textBoxPassAmount.Text = ticketsAmount.ToString();
        }
    }
}
