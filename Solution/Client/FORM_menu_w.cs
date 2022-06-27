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
    public partial class FORM_menu_w : Form
    {
        FORM_main main_form;

        public FORM_menu_w(FORM_main main) { main_form = main; InitializeComponent(); }

        private void BTN_logout_Click(object sender, EventArgs e) { main_form.DIS_query(); }

        private void MENU_item_1_Click(object sender, EventArgs e) // Journal
        {
            main_form.C23_query();
        }

        private void MENU_item_3_Click(object sender, EventArgs e) // Clients
        {
            main_form.C21_query();
        }

        private void MENU_item_21_Click(object sender, EventArgs e) // Count of clients in groups
        {
            main_form.C05_query();
        }

        private void MENU_item_22_Click(object sender, EventArgs e) // Clients in groups
        {
            main_form.C06_query();
        }

        private void MENU_item_23_Click(object sender, EventArgs e) // Clients orders
        {
            main_form.C07_query();
        }

        private void MENU_item_24_Click(object sender, EventArgs e) // Clients at birthday
        {
            main_form.C13_query();
        }

        private void MENU_item_25_Click(object sender, EventArgs e) // Clients at groups
        {
            main_form.C14_query();
        }

        private void MENU_item_26_Click(object sender, EventArgs e) // Barbers phones at rank
        {
            main_form.C12_query();
        }

        private void MENU_item_27_Click(object sender, EventArgs e) // Barbers at rank & factors of other
        {
            main_form.C17_query();
        }

        private void MENU_item_28_Click(object sender, EventArgs e) // Orders at date
        {
            main_form.C15_query();
        }
    }
}
