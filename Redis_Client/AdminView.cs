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
        int input = -1;
        bool inputType;

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
            FormFlightInfo(Int32.Parse(SearchBox.Text));
            input = Int32.Parse(SearchBox.Text);
            inputType = true;
        }

        private void FormFlightTable(int pInput)
        {
            AdminTable.Clear();
            AdminViewHelper admViewHelper = new AdminViewHelper();
            string input = admViewHelper.GetFlightData(pInput);

            AdminTable.View = View.Details;
            AdminTable.GridLines = true;
            AdminTable.FullRowSelect = true;

            AdminTable.Columns.Add("Client ID", 100);
            AdminTable.Columns.Add("Client Name", 100);
            AdminTable.Columns.Add("Client Email", 100);
            AdminTable.Columns.Add("Booked Seats", 100);
            AdminTable.Columns.Add("Spent Time", 100);
            AdminTable.Columns.Add("Num. of views", 100);
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

        private void FormFlightInfo(int pInput)
        {
            AdminViewHelper admViewHelper = new AdminViewHelper();
            string txt8 = "", txt9 = "", txt10 = "", txt11 = "", txt12 = "";

            label1.Text = "ID";
            label2.Text = "FROM";
            label3.Text = "TO";
            label4.Text = "DATE";
            label5.Text = "COST";
            label6.Text = "LEFT TICKETS";

            admViewHelper.GetFlightInfoFromRedis(pInput, ref txt8, ref txt9, ref txt10, ref txt11, ref txt12);

            label7.Text = pInput.ToString();
            label8.Text = txt8;
            label9.Text = txt9;
            label10.Text = txt10;
            label11.Text = txt11;
            label12.Text = txt12;
        }

        private void FindUser_Click(object sender, EventArgs e)
        {
            FormClientTable(Int32.Parse(SearchBox.Text));
            FormClientInfo(Int32.Parse(SearchBox.Text));
            input = Int32.Parse(SearchBox.Text);
            inputType = false;
        }

        private void FormClientTable(int pInput)
        {
            AdminTable.Clear();
            AdminViewHelper admViewHelper = new AdminViewHelper();
            string input = admViewHelper.GetClientData(pInput);

            AdminTable.View = View.Details;
            AdminTable.GridLines = true;
            AdminTable.FullRowSelect = true;

            AdminTable.Columns.Add("Flight ID", 100);
            AdminTable.Columns.Add("From", 100);
            AdminTable.Columns.Add("To", 100);
            AdminTable.Columns.Add("Cost", 100);
            AdminTable.Columns.Add("Booked", 100);
            AdminTable.Columns.Add("Spent Time", 100);
            AdminTable.Columns.Add("Num. of views", 100);
            AdminTable.Columns.Add("Last view date", 150);

            string[] arr = new string[10];
            ListViewItem itm;
            string[] words = input.Split(';');
            for (int itr = 0; itr < words.Length - 1; itr += 8)
            {
                for (int initr = 0; initr < 8; initr++)
                {
                    arr[initr] = words[initr + itr];
                }
                itm = new ListViewItem(arr);
                AdminTable.Items.Add(itm);
            }
        }

        private void FormClientInfo(int pInput)
        {
            AdminViewHelper admViewHelper = new AdminViewHelper();
            string txt8 = "", txt9 = "", txt11 = "", txt12 = "";

            label1.Text = "ID";
            label2.Text = "NAME";
            label3.Text = "EMAIL";
            label4.Text = "";
            label5.Text = "MONEY";
            label6.Text = "TOTAL ORDERS";

            admViewHelper.GetClientInfoFromRedis(pInput, ref txt8, ref txt9, ref txt11, ref txt12);

            label7.Text = pInput.ToString();
            label8.Text = txt8;
            label9.Text = txt9;
            label10.Text = "";
            label11.Text = txt11;
            label12.Text = txt12;
        }

        private void AdminTable_DoubleClick(object sender, EventArgs e)
        {
            int rowId;
            if (Int32.TryParse(AdminTable.SelectedItems[0].SubItems[0].Text, out rowId))
            {
                if (inputType)
                    GoToAdminViewDetails(input, rowId);
                else GoToAdminViewDetails(rowId, input);
            }
        }

        private void GoToAdminViewDetails(int flightId, int clientId)
        {
            AdminViewDetails admV = new AdminViewDetails(flightId, clientId);

            if (flightId >= 0 && clientId >= 0)
            {
                admV.ShowDialog();

            }
        }
    }
}
