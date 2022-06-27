#if DEBUG
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
    public partial class FORM_menu_p : Form
    {
        FORM_main main_form;

        public FORM_menu_p(FORM_main main)
        {
            main_form = main;
            InitializeComponent();

            // VIEWs
            MENU_item_c01.Click += MENU_item_c01_Click;
            MENU_item_c02.Click += MENU_item_c02_Click;
            MENU_item_c03.Click += MENU_item_c03_Click;
            MENU_item_c04.Click += MENU_item_c04_Click;
            MENU_item_c05.Click += MENU_item_c05_Click;
            MENU_item_c06.Click += MENU_item_c06_Click;
            MENU_item_c07.Click += MENU_item_c07_Click;
            MENU_item_c08.Click += MENU_item_c08_Click;
            MENU_item_c09.Click += MENU_item_c09_Click;

            // FUNCTIONs
            MENU_item_c10.Click += MENU_item_c10_Click;
            MENU_item_c11.Click += MENU_item_c11_Click;
            MENU_item_c12.Click += MENU_item_c12_Click;
            MENU_item_c13.Click += MENU_item_c13_Click;
            MENU_item_c14.Click += MENU_item_c14_Click;
            MENU_item_c15.Click += MENU_item_c15_Click;
            MENU_item_c16.Click += MENU_item_c16_Click;
            MENU_item_c17.Click += MENU_item_c17_Click;
            MENU_item_c18.Click += MENU_item_c18_Click;
            MENU_item_c19.Click += MENU_item_c19_Click;
            MENU_item_c20.Click += MENU_item_c20_Click;

            // OTHER
            MENU_item_c21.Click += MENU_item_c21_Click;
            MENU_item_c22.Click += MENU_item_c22_Click;
            MENU_item_c23.Click += MENU_item_c23_Click;

            MENU_item_c61.Click += MENU_item_c61_Click;
        }

        private void BTN_logout_Click(object sender, EventArgs e) { main_form.DIS_query(); }

        // VIEWs
        private void MENU_item_c01_Click(object sender, EventArgs e) { main_form.C01_query(); }
        private void MENU_item_c02_Click(object sender, EventArgs e) { main_form.C02_query(); }
        private void MENU_item_c03_Click(object sender, EventArgs e) { main_form.C03_query(); }
        private void MENU_item_c04_Click(object sender, EventArgs e) { main_form.C04_query(); }
        private void MENU_item_c05_Click(object sender, EventArgs e) { main_form.C05_query(); }
        private void MENU_item_c06_Click(object sender, EventArgs e) { main_form.C06_query(); }
        private void MENU_item_c07_Click(object sender, EventArgs e) { main_form.C07_query(); }
        private void MENU_item_c08_Click(object sender, EventArgs e) { main_form.C08_query(); }
        private void MENU_item_c09_Click(object sender, EventArgs e) { main_form.C09_query(); }

        // FUNCTIONs
        private void MENU_item_c10_Click(object sender, EventArgs e) { main_form.C10_query(); }
        private void MENU_item_c11_Click(object sender, EventArgs e) { main_form.C11_query(); }
        private void MENU_item_c12_Click(object sender, EventArgs e) { main_form.C12_query(); }
        private void MENU_item_c13_Click(object sender, EventArgs e) { main_form.C13_query(); }
        private void MENU_item_c14_Click(object sender, EventArgs e) { main_form.C14_query(); }
        private void MENU_item_c15_Click(object sender, EventArgs e) { main_form.C15_query(); }
        private void MENU_item_c16_Click(object sender, EventArgs e) { main_form.C16_query(); }
        private void MENU_item_c17_Click(object sender, EventArgs e) { main_form.C17_query(); }
        private void MENU_item_c18_Click(object sender, EventArgs e) { main_form.C18_query(); }
        private void MENU_item_c19_Click(object sender, EventArgs e) { main_form.C19_query(); }
        private void MENU_item_c20_Click(object sender, EventArgs e) { main_form.C20_query(); }

        // OTHER
        private void MENU_item_c21_Click(object sender, EventArgs e) { main_form.C21_query(); }
        private void MENU_item_c22_Click(object sender, EventArgs e) { main_form.C22_query(); }
        private void MENU_item_c23_Click(object sender, EventArgs e) { main_form.C23_query(); }

        private void MENU_item_c61_Click(object sender, EventArgs e) { main_form.C61_query(); }
    }
}
#endif