using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace financial_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void AuthenticateUser(object sender, EventArgs e)
        {
            String username = this.txtUserName.Text;
            String password = this.txtPassword.Text;

            //validations
            if (username == null || username == String.Empty)
            {

                MessageBox.Show("Username Required", "Hey", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

                DashBordView dashBord = new DashBordView();
                dashBord.Show();
                this.Hide();
            }

        }
    }
}
