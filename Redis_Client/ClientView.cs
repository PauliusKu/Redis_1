﻿using System;
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
    public partial class ClientView : Form
    {
        int clnId = -1;
        public ClientView()
        {
            InitializeComponent();
        }

        public void Init(int clientId)
        {
            clnId = clientId;
            Console.WriteLine(clnId);
        }
        private void ClientView_Load(object sender, EventArgs e)
        {

        }
    }
}