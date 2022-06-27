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
    public partial class FORM_menu_d : Form
    {
        FORM_main main_form;

        public FORM_menu_d(FORM_main main) { main_form = main; InitializeComponent(); }

        private void BTN_logout_Click(object sender, EventArgs e) { main_form.DIS_query(); }

        private void MENU_item_1_Click(object sender, EventArgs e)
        {
            main_form.C22_query();
        }

        private void MENU_item_21_Click(object sender, EventArgs e) // Count of Barbers by it's factors
        {
            main_form.C01_query();
        }

        private void MENU_item_22_Click(object sender, EventArgs e) // Barbers with it's ownerships & ranks
        {
            main_form.C02_query();
        }

        private void MENU_item_23_Click(object sender, EventArgs e) // Count of barbers at districts
        {
            main_form.C03_query();
        }

        private void MENU_item_24_Click(object sender, EventArgs e) // Unranked Barbers at districts
        {
            main_form.C04_query();
        }

        private void MENU_item_25_Click(object sender, EventArgs e) // Districts with Barbers
        {
            main_form.C09_query();
        }

        private void MENU_item_26_Click(object sender, EventArgs e) // Barbers at ownernership
        {
            main_form.C11_query();
        }

        private void MENU_item_27_Click(object sender, EventArgs e) // Top profit services
        {
            main_form.C08_query();
        }

        private void MENU_item_28_Click(object sender, EventArgs e) // Average service order cost
        {
            main_form.C10_query();
        }

        private void MENU_item_29_Click(object sender, EventArgs e) // Profit by expensive services at date
        {
            main_form.C16_query();
        }
    }
}
