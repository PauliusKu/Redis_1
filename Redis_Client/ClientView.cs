﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Redis_Client
{
    public partial class ClientView : Form
    {
        int clnId = -1;
        public ClientView(int clientId)
        {
            clnId = clientId;
            InitializeComponent();
        }

        private void ClientView_Load(object sender, EventArgs e)
        {
            RefreshWindow();
        }

        private void FormClientList()
        {
            listViewClient.Clear();
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnId);
            string input = clnviewhelp.GetTable(true);

            listViewClient.View = View.Details;
            listViewClient.GridLines = true;
            listViewClient.FullRowSelect = true;

            listViewClient.Columns.Add("FLIGHT", 80);
            listViewClient.Columns.Add("FROM", 100);
            listViewClient.Columns.Add("TO", 100);
            listViewClient.Columns.Add("DATE", 80);
            listViewClient.Columns.Add("COST", 80);
            listViewClient.Columns.Add("LEFT TICKETS", 150);

            string[] arr = new string[7];
            ListViewItem itm;

            string[] words = input.Split(';');
            for (int itr = 0; itr < words.Length - 1; itr += 6)
            {
                for (int initr = 0; initr < 6; initr++)
                {
                    arr[initr] = words[initr + itr];
                }
                itm = new ListViewItem(arr);
                listViewClient.Items.Add(itm);
            }
        }

        private void FormSystemList()
        {
            listViewSystem.Clear();
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnId);
            string input = clnviewhelp.GetTable(false);

            listViewSystem.View = View.Details;
            listViewSystem.GridLines = true;
            listViewSystem.FullRowSelect = true;

            listViewSystem.Columns.Add("FLIGHT", 80);
            listViewSystem.Columns.Add("FROM", 100);
            listViewSystem.Columns.Add("TO", 100);
            listViewSystem.Columns.Add("DATE", 80);
            listViewSystem.Columns.Add("COST", 80);
            listViewSystem.Columns.Add("LEFT TICKETS", 150);

            string[] arr = new string[7];
            ListViewItem itm;

            string[] words = input.Split(';');
            for (int itr = 0; itr < words.Length-1; itr += 6)
            {
                for (int initr = 0; initr < 6; initr++)
                {
                    arr[initr] = words[initr + itr];
                }
                itm = new ListViewItem(arr);
                listViewSystem.Items.Add(itm);
            }
        }

        private void ListViewClient_DoubleClick(object sender, EventArgs e)
        {
            int flightId;
            if (Int32.TryParse(listViewSystem.SelectedItems[0].SubItems[0].Text, out flightId))
            GoToOrder(flightId);
        }

        private void ButtonSystemFlights_Click(object sender, EventArgs e)
        {
            listViewClient.Hide();
            listViewSystem.Show();
        }

        private void ButtonMyFlights_Click(object sender, EventArgs e)
        {
            listViewSystem.Hide();
            listViewClient.Show();
        }

        private void GoToOrder(int flightId)
        {
            Order order = new Order(clnId, flightId);

            if (clnId >= 0 && flightId >= 0)
            {
                order.ShowDialog();
                RefreshWindow();
            }
        }
        private void RefreshWindow()
        {
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnId);
            clnviewhelp.GetAllClientInfo(out string username, out string mail, out decimal money);
            labelUsername.Text = username;
            labelMail.Text = mail;
            labelMoney.Text = money.ToString(CultureInfo.InvariantCulture);
            FormClientList();
            FormSystemList();
        }
    }
}
