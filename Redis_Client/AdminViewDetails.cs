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
    public partial class AdminViewDetails : Form
    {
        int flightId = -1;
        int clientId = -1;

        public AdminViewDetails(int flId, int clnId)
        {
            InitializeComponent();
            flightId = flId;
            clientId = clnId;
            labelflight.Text = flightId.ToString();
            labelclient.Text = clientId.ToString();
            ShowDetailedData();
        }

        private void AdminViewDetails_Load(object sender, EventArgs e)
        {

        }

        private void ShowDetailedData()
        {
            DetailedData.Clear();
            AdminViewHelper admViewHelper = new AdminViewHelper();
            string input = admViewHelper.GetDetailedData(flightId, clientId);

            DetailedData.View = View.Details;
            DetailedData.GridLines = true;
            DetailedData.FullRowSelect = true;

            DetailedData.Columns.Add("Start Time", 200);
            DetailedData.Columns.Add("Duration", 150);
            DetailedData.Columns.Add("Action", 100);

            string[] arr = new string[10];
            ListViewItem itm;
            string[] words = input.Split(';');
            for (int itr = 0; itr < words.Length - 1; itr += 3)
            {
                for (int initr = 0; initr < 3; initr++)
                {
                    arr[initr] = words[initr + itr];
                }
                itm = new ListViewItem(arr);
                DetailedData.Items.Add(itm);
            }
        }
    }
}
