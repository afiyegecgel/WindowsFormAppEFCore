using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormAppEFCore.Services;

namespace WinFormAppEFCore
{
    public partial class AdminLogin : Form
    {
        Form T;
        LoginServices loginServices = new LoginServices();
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = mtxtPassword.Text;

            bool result = loginServices.IsLoginSuccess(username, password);

            if(result)
            {
                if (Application.OpenForms["OperationSelect"] != null)
                {
                    T = Application.OpenForms["OperationSelect"];
                    T.Focus();
                    Close();
                }
                else
                {
                    T = new OperationSelect();
                    T.StartPosition = FormStartPosition.CenterScreen;
                    T.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Username or password is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            
        }
    }
}
