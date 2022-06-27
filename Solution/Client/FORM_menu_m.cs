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
    public partial class FORM_menu_m : Form
    {
        FORM_main main_form;

        public FORM_menu_m(FORM_main main) { main_form = main; InitializeComponent(); }

        private void BTN_logout_Click(object sender, EventArgs e) { main_form.DIS_query(); }

        private void MENU_item_1_Click(object sender, EventArgs e) // Workers
        {

        }
    }
}
