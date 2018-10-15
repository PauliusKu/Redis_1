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
    class AppError
    {
        public void ShowErrorMsg(string errCode)
        {
            MessageBox.Show(errCode, "Error",
            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ShowMsg(string code)
        {
            MessageBox.Show(code, "Message",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
