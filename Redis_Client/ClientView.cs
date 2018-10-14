using System;
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
        int clnid = -1;
        public ClientView(int clientId)
        {
            clnid = clientId;
            InitializeComponent();
        }

        private void ClientView_Load(object sender, EventArgs e)
        {
            ClientViewHelper clnviewhelp = new ClientViewHelper(clnid);
            clnviewhelp.GetAllClientInfo(out string username, out string mail, out decimal money);
            labelUsername.Text = username;
            labelMail.Text = mail;
            labelMoney.Text = money.ToString(CultureInfo.InvariantCulture);
            FormClientList();
        }

        private void FormClientList()
        {
            listViewClient.Clear();

            listViewClient.View = View.Details;
            listViewClient.GridLines = true;
            listViewClient.FullRowSelect = true;

            //Add column header
            listViewClient.Columns.Add("Flight", 80);
            listViewClient.Columns.Add("From-To", 150);
            listViewClient.Columns.Add("Date", 80);
            listViewClient.Columns.Add("Price", 70);
            listViewClient.Columns.Add("Status", 80);

            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm;

            //Add first item
            arr[0] = "product_1";
            arr[1] = "100";
            arr[2] = "10";
            itm = new ListViewItem(arr);
            listViewClient.Items.Add(itm);

            //Add second item
            arr[0] = "product_2";
            arr[1] = "200";
            arr[2] = "20";
            itm = new ListViewItem(arr);
            listViewClient.Items.Add(itm);
        }

        private void FormSystemList()
        {
            listViewClient.Clear();

            listViewClient.View = View.Details;
            listViewClient.GridLines = true;
            listViewClient.FullRowSelect = true;

            //Add column header
            listViewClient.Columns.Add("ProbggbbggbductName", 100);
            listViewClient.Columns.Add("Pribggbce", 70);
            listViewClient.Columns.Add("Qugbgbantity", 70);

            //Add items in the listview
            string[] arr = new string[4];
            ListViewItem itm;

            //Add first item
            arr[0] = "product_1";
            arr[1] = "100";
            arr[2] = "10";
            itm = new ListViewItem(arr);
            listViewClient.Items.Add(itm);

            //Add second item
            arr[0] = "product_2";
            arr[1] = "200";
            arr[2] = "20";
            itm = new ListViewItem(arr);
            listViewClient.Items.Add(itm);
        }

        private void ListViewClient_DoubleClick(object sender, EventArgs e)
        {

            MessageBox.Show(listViewClient.SelectedItems[0].SubItems[0].Text);
        }

        private void ButtonSystemFlights_Click(object sender, EventArgs e)
        {
            FormSystemList();
        }

        private void ButtonMyFlights_Click(object sender, EventArgs e)
        {
            FormClientList();
        }
    }
}
