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
    public partial class AdminView : Form
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void AdminView_Load(object sender, EventArgs e)
        {

        }

        private void FindFlight_Click(object sender, EventArgs e)
        {
            FormFlightTable(Int32.Parse(SearchBox.Text));
        }

        private void FormFlightTable(int pInput)
        {
            AdminTable.Clear();
            AdminViewHelper admViewHelper = new AdminViewHelper();
            string input = admViewHelper.GetFlightData(pInput);

            AdminTable.View = View.Details;
            AdminTable.GridLines = true;
            AdminTable.FullRowSelect = true;

            AdminTable.Columns.Add("Client ID", 80);
            AdminTable.Columns.Add("Client Name", 80);
            AdminTable.Columns.Add("Client Email", 80);
            AdminTable.Columns.Add("Booked Seats", 120);
            AdminTable.Columns.Add("Spent Time", 80);
            AdminTable.Columns.Add("Num. of views", 150);
            AdminTable.Columns.Add("Last view date", 150);

            string[] arr = new string[10];
            ListViewItem itm;
            string[] words = input.Split(';');
            for (int itr = 0; itr < words.Length - 1; itr += 7)
            {
                for (int initr = 0; initr < 7; initr++)
                {
                    arr[initr] = words[initr + itr];
                }
                itm = new ListViewItem(arr);
                AdminTable.Items.Add(itm);
            }
        }
    }
}
