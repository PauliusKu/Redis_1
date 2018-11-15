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
        bool isOrderOrCancelation;
        ClientTracker clnTrack;

        public Order(int cId, int flId, bool isOrder, ClientTracker clnT)
        {
            clnTrack = clnT;
            clnId = cId;
            flightId = flId;
            InitializeComponent();
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnId);
            ticketsMaxAmount = clnviewhelp.GetLeftTicketsAmount(flightId);
            oneTicketCost = clnviewhelp.GetTicketsCost(flightId);
            ticketsCost = oneTicketCost;
            isOrderOrCancelation = isOrder;
            if (isOrder) ButtonOrder.Text = "Book Seats";
            else ButtonOrder.Text = "Unbook Seats";
        }

        private void Order_Load(object sender, EventArgs e)
        {
            labelSum.Text = ticketsCost.ToString() + " EUR";
        }

        private void ButtonOrder_Click(object sender, EventArgs e)
        {
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnId, clnTrack);
            if (isOrderOrCancelation == true)
            clnviewhelp.MakeOrder(flightId, ticketsAmount);
            else clnviewhelp.DeleteOrder(flightId, ticketsAmount);
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
            FlightUtil flightUt = new FlightUtil();
            if ((ticketsAmount < ticketsMaxAmount && isOrderOrCancelation == true) || (ticketsAmount < flightUt.GetFlightOrderAmount(flightId, clnId)))
            {
                ticketsAmount++;
                ticketsCost += oneTicketCost;
                labelSum.Text = ticketsCost.ToString() + " EUR";
            }
            textBoxPassAmount.Text = ticketsAmount.ToString();
        }

    }
}
