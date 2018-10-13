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
    public partial class LogIn : Form
    {
        String error = "";
        Boolean first_time_clickName = true;
        Boolean first_time_clickPsw = true;
        Boolean first_time_clickMail = true;
        Boolean registerButtonStatus = false;
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            textBoxName.ForeColor = System.Drawing.Color.Gray;
            textBoxName.Text = "Enter the Name";

            textBoxPsw.PasswordChar = '*';
            textBoxPsw.ForeColor = System.Drawing.Color.Gray;
            textBoxPsw.Text = "*******";

            textBoxMail.ForeColor = System.Drawing.Color.Gray;
            textBoxMail.Text = "Enter the your mail address";
        }

        private void ButLogIn_Click(object sender, EventArgs e)
        {
            LogInHelper loginhelper = new LogInHelper();
            string username = textBoxName.Text;
            string password = textBoxPsw.Text;

            error = loginhelper.LogIn(username, password);

            if (error == "") GoToClientView();
            else ShowMessage(error);
        }

        private void ButRegister_Click(object sender, EventArgs e)
        {
            LogInHelper loginhelper = new LogInHelper();
            if (registerButtonStatus == false)
            {
                textBoxMail.Show();
                registerButtonStatus = true;
            }
            else
            {
                string username = textBoxName.Text;
                string password = textBoxPsw.Text;
                string mail = textBoxMail.Text;
                error = loginhelper.Register(username, password, mail);

                loginhelper = null;
                GC.Collect();

                if (error == "") GoToClientView();
                else ShowMessage(error);
            }
        }

        private void TextBoxName_Click(object sender, EventArgs e)
        {
            if (first_time_clickName)
            {
                textBoxName.Clear();
                textBoxName.ForeColor = textBoxName.ForeColor = SystemColors.WindowText;
            }
            first_time_clickName = false;
        }
        private void TextBoxPsw_Click(object sender, EventArgs e)
        {
            if (first_time_clickPsw)
            {
                textBoxPsw.Clear();
                textBoxPsw.ForeColor = textBoxPsw.ForeColor = SystemColors.WindowText;
            }
            first_time_clickPsw = false;
        }
        private void TextBoxMail_Click(object sender, EventArgs e)
        {
            if (first_time_clickMail)
            {
                textBoxMail.Clear();
                textBoxMail.ForeColor = textBoxMail.ForeColor = SystemColors.WindowText;
            }
            first_time_clickMail = false;
        }
        private void GoToClientView()
        {
            ClientView clientview = new ClientView();
            this.Hide();
            clientview.ShowDialog();
            this.Close();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
