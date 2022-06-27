using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FORM_authorization : Form
    {
        private FORM_main main_form;

        public FORM_authorization()
        {
            main_form = new FORM_main(this);
            InitializeComponent();
#if DEBUG
            TXT_user.Text = "postgres";
            TXT_password.Text = "123";
#endif
        }

        private void FORM_authorization_FormClosed(object sender, FormClosedEventArgs e) { Application.Exit(); }

        private void TXT_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { e.SuppressKeyPress = true; SelectNextControl((Control)sender, true, true, true, true); }
        }

        private void TXT_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { e.SuppressKeyPress = true; SelectNextControl((Control)sender, true, true, true, true); }
        }

        private void BTN_login_Click(object sender, EventArgs e)
        {
            if (TXT_user.Text == ""         || TXT_password.Text == ""         ||
                TXT_user.Text.Contains("~") || TXT_password.Text.Contains("~") ||
                TXT_user.Text.Contains(":") || TXT_password.Text.Contains(":"))
            {
                MessageBox.Show("=== incorrect name ===");
                return;
            }

            if (!main_form.CON_query(TXT_user.Text.Trim(), TXT_password.Text.Trim())) // todo [:] USER NAME & PASSWORD
                MessageBox.Show("=== login failed ===", "TRY AGAIN");
        }
    }
}
