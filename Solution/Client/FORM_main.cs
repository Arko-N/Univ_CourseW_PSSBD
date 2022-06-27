using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

// todo [:] codes - 01-09 = views ; 10-20 = functions ; 21-30 = selects ; 31-40 = inserts ; 41-50 = updates ; 51-60 = deletes ; 61-70 = USERS ; 71-80 = additional requests to tables
// todo [:] codes as tables - *1 = Clients ; *2 = Barbers ; *3 = Journal ; *4 = Groups ; *5 = Districts ; *6 = Ranks ; *7 = Ownerships ; *8 = Services

namespace Client
{
    public partial class FORM_main : Form
    {
        private FORM_authorization auth;
        private FORM_diagram_AND_excel diagram;
        private FORM_t_group groups;
        private Form menu;

        private const int port = 8888;
        private const string address = "127.0.0.1";

        private static TcpClient client;
        private static NetworkStream stream;
#if DEBUG
        private bool postgres = false;
#endif
        private bool director = false;
        private bool manager = false;
        private bool worker = false;

        string[] rows;

        #region T_MENU ITEMS

        ToolStripMenuItem ins_client;
        ToolStripMenuItem upd_client;
        ToolStripMenuItem del_client;

        ToolStripMenuItem ins_barber;
        ToolStripMenuItem upd_barber;
        ToolStripMenuItem del_barber;

        ToolStripMenuItem ins_journal;
        ToolStripMenuItem upd_journal;
        ToolStripMenuItem del_journal;

        ToolStripMenuItem add_worker;
        ToolStripMenuItem upd_worker;
        ToolStripMenuItem del_worker;

        ToolStripMenuItem show_diagram;

        #endregion T_MENU ITEMS

        #region FORM CONTROL

        public FORM_main(FORM_authorization auth_form)
        {
            InitializeComponent();

            ins_client = new ToolStripMenuItem("Добавить клиента");
            ins_client.Click += ins_client_Click;
            upd_client = new ToolStripMenuItem("Изменить выделенных клиентов");
            upd_client.Click += upd_client_Click;
            del_client = new ToolStripMenuItem("Удалить выделенных клиентов");
            del_client.Click += del_client_Click;

            ins_barber = new ToolStripMenuItem("Добавить парикмахерскую");
            ins_barber.Click += ins_barber_Click;
            upd_barber = new ToolStripMenuItem("Изменить выделенные парикмахерские");
            upd_barber.Click += upd_barber_Click;
            del_barber = new ToolStripMenuItem("Удалить выделенные парикмахерские");
            del_barber.Click += del_barber_Click;

            ins_journal = new ToolStripMenuItem("Добавить заказ");
            ins_journal.Click += ins_journal_Click;
            upd_journal = new ToolStripMenuItem("Изменить выделенные заказы");
            upd_journal.Click += upd_journal_Click;
            del_journal = new ToolStripMenuItem("Удалить выделенные заказы");
            del_journal.Click += del_journal_Click;

            add_worker = new ToolStripMenuItem("Создать аккаунт работника");
            add_worker.Click += add_worker_Click;
            upd_worker = new ToolStripMenuItem("Изменить выделенный аккаунт работника");
            upd_worker.Click += upd_worker_Click;
            del_worker = new ToolStripMenuItem("Удалить выделенный аккаунт работника");
            del_worker.Click += del_worker_Click;

            show_diagram = new ToolStripMenuItem("Показать в виде диаграммы");
            show_diagram.Click += show_diagram_Click;

            // OTHER FORMS
            auth = auth_form;

            groups = new FORM_t_group(this);
            ToolStripMenuItem ins_group = new ToolStripMenuItem("Добавить клиентскую группу");
            ins_group.Click += ins_group_Click;
            ToolStripMenuItem del_group = new ToolStripMenuItem("Удалить клиентскую группу");
            del_group.Click += del_group_Click;
            groups.CONTEXT_menu.Items.AddRange(new[] { ins_group, del_group });
        }

        private void FORM_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Visible)
            {
                string message = "DIS: CONNECT";
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                client.Close();
                Application.Exit();
            }
        }

        private void FORM_main_VisibleChanged(object sender, EventArgs e)
        {
            if (menu != null && !menu.IsDisposed) menu.Visible = Visible;
        }

        private void BTN_menu_Click(object sender, EventArgs e)
        {
            if (menu != null && menu.Visible) menu.Close();
            else
            {
                if (menu == null || menu.IsDisposed)
                {
#if DEBUG
                    if (postgres) menu = new FORM_menu_p(this);
#endif
                    if (director) menu = new FORM_menu_d(this);
                    if (manager)  menu = new FORM_menu_m(this);
                    if (worker)   menu = new FORM_menu_w(this);
                }
                menu.Show();
            }
        }

        private void Show_page()
        {
            for (int i = 0; i < DGRID_table.Rows.Count; i++)
            {
                if (i >= (NUM_page.Value - 1) * 17 && i < NUM_page.Value * 17) DGRID_table.Rows[i].Visible = true;
                else DGRID_table.Rows[i].Visible = false;
            }
        }
        private void NUM_page_ValueChanged(object sender, EventArgs e)
        {
            Show_page();
        }
        private void NUM_page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { e.SuppressKeyPress = true; }
        }

        private void TXT_search_Leave(object sender, EventArgs e)
        {
            if (TXT_search.Text == "") { SetRows(rows); NUM_page.Value = 1; Show_page(); }
        }
        private void TXT_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (TXT_search.Text != "")
                {
                    SetRows(rows.Where(line => line.Contains(TXT_search.Text.Trim())).ToArray());
                }
                else
                {
                    SetRows(rows);
                }
                NUM_page.Value = 1;
                Show_page();
            }
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void BTN_search_Click(object sender, EventArgs e)
        {
            NUM_page.Value = 1; SetRows(rows.Where(line => line.Contains(TXT_search.Text.Trim())).ToArray()); Show_page();
        }
        private void BTN_clear_Click(object sender, EventArgs e)
        {
            NUM_page.Value = 1; TXT_search.Text = ""; SetRows(rows); Show_page();
        }

        #endregion FORM CONTROL

        private string Send(string message)
        {
            StringBuilder builder = new StringBuilder();
            byte[] data = Encoding.Unicode.GetBytes(message); // преобразуем сообщение в массив байтов
            try
            {
                stream.Write(data, 0, data.Length);           // отправка сообщения

                // получаем ответ
                data = new byte[64];                          // буфер для получаемых данных
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);
            }
            catch
            {
                builder.Append("OVERTIME . DISCONNECTED");
            }

            return builder.ToString();
        }

        public bool CON_query(string user_name, string password)
        {
            try
            {
                client = new TcpClient(address, port);
                stream = client.GetStream();

                string message = $"CON: {user_name}~{password}";
                message = Send(message);
                if (message.Contains("DISCONNECTED")) { client.Close(); return false; }

                if (user_name == "postgres")
                {
#if DEBUG
                    postgres = true;
#else
                    message = "DIS: CONNECT --- MISHANDLING";
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    client.Close();
                    return false;
#endif
                }
                else if (message.Contains("director_gp"))
                {
                    director = true;
                }
                else if (message.Contains("manager_gp"))
                {
                    manager = true;
                }
                else if (message.Contains("worker_gp"))
                {
                    worker = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("отверг")) MessageBox.Show("Сервер: OFFLINE");
                else                               MessageBox.Show(ex.Message);

                if (client != null) client.Close();
                return false;
            }

            auth.Hide();
            Show();

            return true;
        }

        public void DIS_query()
        {
            string message = "DIS: CONNECT";
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);

            if (client != null) client.Close();

            auth.Show();
            Hide();

            TXT_title.Text = "";
            DGRID_table.Columns.Clear();
            DGRID_table.Rows.Clear();
            groups.Hide();
            menu.Close();

#if DEBUG
            postgres = false;
#endif
            director = false; manager = false; worker = false;
        }

#region VIEWs

        /// <summary>
        /// Count of Barbers by it's factors
        /// </summary>
        public void C01_query()
        {
            Query("C01", "Count of Barbers by it's factors", new[] { new KeyValuePair<string, string>("count", "count of Barbers"),
                                                                     new KeyValuePair<string, string>("factor", "factor for costs")});
        }

        /// <summary>
        /// Barbers with it's ownerships & ranks
        /// </summary>
        public void C02_query()
        {
            Query("C02", "Barbers with it's ownerships & ranks", new[] { new KeyValuePair<string, string>("barber", "Barbershop"),
                                                                         new KeyValuePair<string, string>("ownership", "Ownership"),
                                                                         new KeyValuePair<string, string>("rank", "Rank")});
        }

        /// <summary>
        /// Count of barbers at districts
        /// </summary>
        public void C03_query()
        {
            Query("C03", "Count of barbers at districts", new[] { new KeyValuePair<string, string>("count", "count of Barbers"),
                                                                  new KeyValuePair<string, string>("district", "district")});
        }

        /// <summary>
        /// Unranked Barbers at districts
        /// </summary>
        public void C04_query()
        {
            Query("C04", "Unranked Barbers at districts", new[] { new KeyValuePair<string, string>("barber ", "Barber"),
                                                                  new KeyValuePair<string, string>("date", "Starting date"),
                                                                  new KeyValuePair<string, string>("district", "District")});
        }

        /// <summary>
        /// Count of clients in groups
        /// </summary>
        public void C05_query()
        {
            Query("C05", "Count of clients in groups", new[] { new KeyValuePair<string, string>("count", "count of Clients"),
                                                               new KeyValuePair<string, string>("group", "Group")});

            CONTEXT_menu.Items.AddRange(new[] { show_diagram });
        }

        /// <summary>
        /// Clients in groups
        /// </summary>
        public void C06_query()
        {
            Query("C06", "Clients in groups", new[] { new KeyValuePair<string, string>("surname", "surname"),
                                                      new KeyValuePair<string, string>("name", "name"),
                                                      new KeyValuePair<string, string>("group", "group")});
        }

        /// <summary>
        /// Clients orders
        /// </summary>
        public void C07_query()
        {
            Query("C07", "Clients orders", new[] { new KeyValuePair<string, string>("surname", "surname"),
                                                   new KeyValuePair<string, string>("barber", "Barber"),
                                                   new KeyValuePair<string, string>("date", "record date")});
        }

        /// <summary>
        /// Top profit services
        /// </summary>
        public void C08_query()
        {
            Query("C08", "Top profit services", new[] { new KeyValuePair<string, string>("count", "count of Records"),
                                                        new KeyValuePair<string, string>("profit", "profit"),
                                                        new KeyValuePair<string, string>("service", "Service")});
        }

        /// <summary>
        /// Districts with Barbers
        /// </summary>
        public void C09_query()
        {
            Query("C09", "Districts with Barbers", new[] { new KeyValuePair<string, string>("district", "District") });
        }

#endregion VIEWs

#region FUNCTIONs

        /// <summary>
        /// Average service order cost
        /// </summary>
        public void C10_query()
        {
            Query(true, "C10", "Average service order cost",
                  new[] { new KeyValuePair<string, string>("avg", "average cost"),
                  new KeyValuePair<string, string>("service", "Service")},
                  hints: new[] { "service name" });
        }

        /// <summary>
        /// Barbers at ownernership
        /// </summary>
        public void C11_query()
        {
            Query(true, "C11", "Barbers at ownernership",
                  new[] { new KeyValuePair<string, string>("barber", "Barber"),
                  new KeyValuePair<string, string>("ownership", "Ownership"),
                  new KeyValuePair<string, string>("date", "starting date"),
                  new KeyValuePair<string, string>("district", "District")},
                  hints: new[] { "ownership name" });
        }

        /// <summary>
        /// Barbers phones at rank
        /// </summary>
        public void C12_query()
        {
            Query(true, "C12", "Barbers phones at rank",
                  new[] { new KeyValuePair<string, string>("barber", "Barbershop"),
                  new KeyValuePair<string, string>("phone", "phone")},
                  hints: new[] { "rank name" });
        }

        /// <summary>
        /// Clients at birthday
        /// </summary>
        public void C13_query()
        {
            Query(true, "C13", "Clients at birthday",
                  new[] { new KeyValuePair<string, string>("group", "Group"),
                  new KeyValuePair<string, string>("surname", "surname"),
                  new KeyValuePair<string, string>("birthday", "birthday")},
                  hints: new[] { "birthday [dd.mm.yyyy]" });
        }

        /// <summary>
        /// Clients at groups
        /// </summary>
        public void C14_query()
        {
            Query(true, "C14", "Clients at groups",
                  new[] { new KeyValuePair<string, string>("surname ", "surname"),
                  new KeyValuePair<string, string>("address", "address")},
                  hints: new[] { "group name" });
        }

        /// <summary>
        /// Orders at date
        /// </summary>
        public void C15_query()
        {
            Query(true, "C15", "Orders at date",
                  new[] { new KeyValuePair<string, string>("barber", "Barber"),
                  new KeyValuePair<string, string>("cost", "cost"),
                  new KeyValuePair<string, string>("date", "date")},
                  hints: new[] { "date [dd.mm.yyyy]" });
        }

        /// <summary>
        /// Profit by expensive services at date
        /// </summary>
        public void C16_query()
        {
            Query(true, "C16", "Profit by expensive services at date",
                  new[] { new KeyValuePair<string, string>("date", "date"),
                  new KeyValuePair<string, string>("sum", "sum of cost")},
                  hints: new[] { "date [dd.mm.yyyy]" });
        }

        /// <summary>
        /// Barbers at rank & factors of other
        /// </summary>
        public void C17_query()
        {
            Query(true, "C17", "Barbers at rank & factors of other",
                  new[] { new KeyValuePair<string, string>("rank", "Rank"),
                  new KeyValuePair<string, string>("factor", "factor"),
                  new KeyValuePair<string, string>("phone", "phone"),
                  new KeyValuePair<string, string>("date", "starting date")},
                  hints: new[] { "rank name" });
        }

        /// <summary>
        ///
        /// </summary>
        public void C18_query() // TODO : NEED TO CREATE DB-FUNCTION
        {
            return;

            Query(true, "C18", " --- ",
                  new[] { new KeyValuePair<string, string>(" --- ", " --- ") }, new[] { 0 },
                  1, hints: new[] { " --- " });
        }

        /// <summary>
        ///
        /// </summary>
        public void C19_query() // TODO : NEED TO CREATE DB-FUNCTION
        {
            return;

            Query(true, "C19", " --- ",
                  new[] { new KeyValuePair<string, string>(" --- ", " --- ") }, new[] { 0 },
                  1, hints: new[] { " --- " });
        }

        /// <summary>
        ///
        /// </summary>
        public void C20_query() // TODO : NEED TO CREATE DB-FUNCTION
        {
            return;

            Query(true, "C20", " --- ",
                  new[] { new KeyValuePair<string, string>(" --- ", " --- ") }, new[] { 0 },
                  1, hints: new[] { " --- " });
        }

#endregion FUNCTIONs

#region OTHER QUERIES

        /// <summary>
        /// Showing CLIENTs & cGROUPs
        /// </summary>
        public void C21_query()
        {
            Query("C21", "Clients", new[] { new KeyValuePair<string, string>("id",         "id"),
                                            new KeyValuePair<string, string>("surname",    "surname"),
                                            new KeyValuePair<string, string>("name",       "name"),
                                            new KeyValuePair<string, string>("fathername", "fathername"),
                                            new KeyValuePair<string, string>("birthday",   "birthday"),
                                            new KeyValuePair<string, string>("group",      "group"),
                                            new KeyValuePair<string, string>("address",    "address"),
                                            new KeyValuePair<string, string>("user",       "user name")}, new[] { 1, 8 });

            CONTEXT_menu.Items.AddRange(new[] { ins_client, upd_client, del_client });
        }

        /// <summary>
        /// Showing BARBERs
        /// </summary>
        public void C22_query()
        {
            Query("C22", "Barbershops", new[] { new KeyValuePair<string, string>("id",        "id"),
                                                new KeyValuePair<string, string>("district",  "district"),
                                                new KeyValuePair<string, string>("rank",      "rank"),
                                                new KeyValuePair<string, string>("ownership", "ownership"),
                                                new KeyValuePair<string, string>("date",      "starting date"),
                                                new KeyValuePair<string, string>("phone",     "phone"),
                                                new KeyValuePair<string, string>("user",      "user name")}, new[] { 1, 7 });

            CONTEXT_menu.Items.AddRange(new[] { ins_barber, upd_barber, del_barber });
        }

        /// <summary>
        /// Showing JOURNAL
        /// </summary>
        public void C23_query()
        {
            Query("C23", "Journal", new[] { new KeyValuePair<string, string>("id",      "id"),
                                            new KeyValuePair<string, string>("client",  "client"),
                                            new KeyValuePair<string, string>("barber",  "barbershop"),
                                            new KeyValuePair<string, string>("service", "service"),
                                            new KeyValuePair<string, string>("cost",    "cost"),
                                            new KeyValuePair<string, string>("date",    "date"),
                                            new KeyValuePair<string, string>("user",    "user name")}, new[] { 1, 7 });

            CONTEXT_menu.Items.AddRange(new[] { ins_journal, upd_journal, del_journal });
        }

        /// <summary>
        /// SELECT workers
        /// </summary>
        public void C61_query()
        {
            Query("C61", "Workers", new[] { new KeyValuePair<string, string>("login", "login") });

            CONTEXT_menu.Items.AddRange(new[] { add_worker, upd_worker, del_worker });
        }

        /// <summary>
        /// ADD worker
        /// </summary>
        public void C62_query()
        {
            string arguments = InputBox.ShowDialog("Add new worker", 2, new[] { "login", "password" });
            if (arguments == null) return;

            string message = Send($"C62: {arguments}");

            if (message.Contains("DISCONNECTED"))
            {
                MessageBox.Show("=== database exception ===", "DISCONNECTED");
                client.Close();
                Hide();
                auth.Show();
                return;
            }
            if (message.Contains("EXCEPTION"))
            {
                MessageBox.Show($"=== {message} ===", "DATABASE EXCEPTION");
                return;
            }

            MessageBox.Show(message);
            C61_query();
        }

        /// <summary>
        /// UPDATE worker
        /// </summary>
        public void C63_query()
        {
            string user = "";
            foreach (DataGridViewRow row in DGRID_table.SelectedRows)
            {
                user = row.Cells[0].Value.ToString();
            }
            if (user.Length == 0)
            {
                MessageBox.Show("Need to select worker before");
                return;
            }

            string arguments = InputBox.ShowDialog("Change worker", 2, new[] { "login", "password" });
            if (arguments == null) return;

            string message = Send($"C63: {arguments} |:| {user}");

            if (message.Contains("DISCONNECTED"))
            {
                MessageBox.Show("=== database exception ===", "DISCONNECTED");
                client.Close();
                Hide();
                auth.Show();
                return;
            }
            if (message.Contains("EXCEPTION"))
            {
                MessageBox.Show($"=== {message} ===", "DATABASE EXCEPTION");
                return;
            }

            MessageBox.Show(message);
            C61_query();
        }

        /// <summary>
        /// DELETE worker
        /// </summary>
        public void C64_query()
        {
            string user = "";
            foreach (DataGridViewRow row in DGRID_table.SelectedRows)
            {
                user = row.Cells[0].Value.ToString();
            }
            if (user.Length == 0)
            {
                MessageBox.Show("Need to select worker before");
                return;
            }

            if (MessageBox.Show($"Are you sure you want\nto Delete worker \"{user}\"", "Deleting", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string message = Send($"C64: {user}");

                if (message.Contains("DISCONNECTED"))
                {
                    MessageBox.Show("=== database exception ===", "DISCONNECTED");
                    client.Close();
                    Hide();
                    auth.Show();
                    return;
                }
                if (message.Contains("EXCEPTION"))
                {
                    MessageBox.Show($"=== {message} ===", "DATABASE EXCEPTION");
                    return;
                }

                MessageBox.Show(message);
                C61_query();
            }
        }

#endregion OTHER QUERIES

#region T_MENU ITEMS PROC

        void ins_group_Click(object sender, EventArgs e)
        {
            Insert("C34", "New group", hints: new[] { "name" });

            Groups();
        }

        void del_group_Click(object sender, EventArgs e)
        {
            StringBuilder rows = new StringBuilder();
            foreach (DataGridViewRow row in groups.DGRID_table.SelectedRows)
            {
                rows.Append($"~{row.Cells[0].Value}");
            }
            if (rows.Length == 0)
            {
                MessageBox.Show("Need to select rows before");
                return;
            }

            if (MessageBox.Show($"Are you sure you want\nto Delete {groups.DGRID_table.SelectedRows.Count} row(s) and related", "Deleting", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Process($"C54: {rows.ToString()}");
            }

            C21_query();
            Groups();
        }

        // GREAT TABLES

        void ins_client_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> items = Get_DB_list("C24");
            if (items == null) return;

            StringBuilder sb = new StringBuilder();
            foreach(KeyValuePair<string, string> item in items)
            {
                sb.Append($"~{item.Value}");
            }
            Insert("C31", "New client", 6, new[] { "surname", "name", "fathername",
                                                   "birthday [dd.mm.yyyy]",
                                                   sb.ToString(),
                                                   "address"});

            C21_query();
        }

        void upd_client_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> items = Get_DB_list("C24");
            if (items == null) return;

            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                sb.Append($"~{item.Value}");
            }
            Update("C41", "New values for clients", 6, new[] { "surname", "name", "fathername",
                                                               "birthday [dd.mm.yyyy]",
                                                               sb.ToString(),
                                                               "address"});

            C21_query();
        }

        void del_client_Click(object sender, EventArgs e)
        {
            Delete("C51");
            C21_query();
        }


        void ins_barber_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> items = Get_DB_list("C25");
            if (items == null) return;
            StringBuilder districts = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                districts.Append($"~{item.Value}");
            }

            items = Get_DB_list("C26");
            if (items == null) return;
            StringBuilder ranks = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                ranks.Append($"~{item.Value}");
            }

            items = Get_DB_list("C27");
            if (items == null) return;
            StringBuilder ownerships = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                ownerships.Append($"~{item.Value}");
            }

            Insert("C32", "New barbershop", 5, new[] { districts.ToString(),
                                                       ranks.ToString(),
                                                       ownerships.ToString(),
                                                       "starting date [dd.mm.yyyy]", "phone"});

            C22_query();
        }

        void upd_barber_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> items = Get_DB_list("C25");
            if (items == null) return;
            StringBuilder districts = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                districts.Append($"~{item.Value}");
            }

            items = Get_DB_list("C26");
            if (items == null) return;
            StringBuilder ranks = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                ranks.Append($"~{item.Value}");
            }

            items = Get_DB_list("C27");
            if (items == null) return;
            StringBuilder ownerships = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                ownerships.Append($"~{item.Value}");
            }

            Update("C42", "New values for barbershop", 5, new[] { districts.ToString(),
                                                                  ranks.ToString(),
                                                                  ownerships.ToString(),
                                                                  "starting date [dd.mm.yyyy]", "phone"});

            C22_query();
        }

        void del_barber_Click(object sender, EventArgs e)
        {
            Delete("C52");
            C22_query();
        }


        void ins_journal_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> items = Get_DB_list("C71");
            if (items == null) return;
            StringBuilder clients = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                clients.Append($"~{item.Key} [|] {item.Value}");
            }

            items = Get_DB_list("C72");
            if (items == null) return;
            StringBuilder barbers = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                barbers.Append($"~{item.Key} [|] {item.Value}");
            }

            items = Get_DB_list("C28");
            if (items == null) return;
            StringBuilder services = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                services.Append($"~{item.Value}");
            }

            Insert("C33", "New order", 3, new[] { clients.ToString(), barbers.ToString(), services.ToString() });

            C23_query();
        }

        void upd_journal_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> items = Get_DB_list("C71");
            if (items == null) return;
            StringBuilder clients = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                clients.Append($"~{item.Key} [|] {item.Value}");
            }

            items = Get_DB_list("C72");
            if (items == null) return;
            StringBuilder barbers = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                barbers.Append($"~{item.Key} [|] {item.Value}");
            }

            items = Get_DB_list("C28");
            if (items == null) return;
            StringBuilder services = new StringBuilder();
            foreach (KeyValuePair<string, string> item in items)
            {
                services.Append($"~{item.Value}");
            }

            Update("C43", "New values for orders", 4, new[] { clients.ToString(), barbers.ToString(),
                                                              services.ToString(), "date [dd.mm.yyyy]"});

            C23_query();
        }

        void del_journal_Click(object sender, EventArgs e)
        {
            Delete("C53");
            C23_query();
        }


        void add_worker_Click(object sender, EventArgs e)
        {
            C62_query();
        }

        void upd_worker_Click(object sender, EventArgs e)
        {
            C63_query();
        }

        void del_worker_Click(object sender, EventArgs e)
        {
            C64_query();
        }


        void show_diagram_Click(object sender, EventArgs e)
        {
            if (diagram != null && !diagram.IsDisposed) diagram.Close();
            else
            {
                diagram = new FORM_diagram_AND_excel(this);
                diagram.Show();
            }
        }

#endregion T_MENU ITEMS PROC

        private void Query(string code, string title, KeyValuePair<string, string>[] columns, int[] hidden = null)
        {
            CONTEXT_menu.Items.Clear();

            string message = $"{code}: ---";
            message = Send(message);
            if (message.Contains("DISCONNECTED"))
            {
                MessageBox.Show("=== database exception ===", "DISCONNECTED");
                client.Close();
                Hide();
                auth.Show();
                return;
            }

            DGRID_table.Columns.Clear();
            DGRID_table.Rows.Clear();

            if (message.Contains("EXCEPTION"))
            {
                MessageBox.Show($"=== {message} ===", "DATABASE EXCEPTION");
                return;
            }

            TXT_title.Text = title;

            for (int i = 0; i < columns.Length; i++)
            {
                DGRID_table.Columns.Add(columns[i].Key, columns[i].Value);
                if (hidden != null && hidden.Contains(i + 1)) DGRID_table.Columns[i].Visible = false;
            }

            if (code != "C61") DGRID_table.MultiSelect = true;
            else               DGRID_table.MultiSelect = false;

            rows = message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (code != "C22") SetRows(rows);
            else SetRows(rows.Where(line => !line.Contains("upd") && !line.Contains("del")).ToArray());

            Show_page();
            if (code != "C21") groups.Hide();
            else Groups();
        }
        private void Query(bool needSelection, string code, string title,
                           KeyValuePair<string, string>[] columns, int[] hidden = null,
                           short input_fields = 1, string[] hints = null)
        {
            CONTEXT_menu.Items.Clear();

            string arguments = InputBox.ShowDialog(title, input_fields, hints);
            if (arguments == null) return;

            string message = $"{code}: {arguments}";
            message = Send(message);
            if (message.Contains("DISCONNECTED"))
            {
                MessageBox.Show("=== database exception ===", "DISCONNECTED");
                client.Close();
                Hide();
                auth.Show();
                return;
            }

            DGRID_table.Columns.Clear();
            DGRID_table.Rows.Clear();

            if (message.Contains("EXCEPTION"))
            {
                MessageBox.Show($"=== {message} ===", "DATABASE EXCEPTION");
                return;
            }

            TXT_title.Text = title;

            for (int i = 0; i < columns.Length; i++)
            {
                DGRID_table.Columns.Add(columns[i].Key, columns[i].Value);
                if (hidden != null && hidden.Contains(i + 1)) DGRID_table.Columns[i].Visible = false;
            }

            DGRID_table.MultiSelect = true;

            rows = message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            SetRows(rows);

            Show_page();
            groups.Hide();
        }

        private void SetRows(string[] rows)
        {
            DGRID_table.Rows.Clear();
            foreach (string row in rows)
            {
                string[] items = row.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                DGRID_table.Rows.Add(items);
            }

            NUM_page.Value = 1;
            NUM_page.Maximum = rows.Length / 17;
            if ((rows.Length % 17) > 0) NUM_page.Maximum++;
            TXT_max.Text = $"\\ {NUM_page.Maximum}";
        }

        private void Groups()
        {
            string message = "C24: ---";
            message = Send(message);
            if (message.Contains("DISCONNECTED"))
            {
                MessageBox.Show("=== database exception ===", "DISCONNECTED");
                client.Close();
                Hide();
                auth.Show();
                return;
            }

            groups.DGRID_table.Columns.Clear();
            groups.DGRID_table.Rows.Clear();

            if (message.Contains("EXCEPTION"))
            {
                MessageBox.Show($"=== {message} ===", "DATABASE EXCEPTION");
                return;
            }

            groups.DGRID_table.Columns.Add("id", "id");
            groups.DGRID_table.Columns.Add("group", "group");
            groups.DGRID_table.Columns[0].Visible = false;

            string[] rows = message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string row in rows)
            {
                string[] items = row.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                groups.DGRID_table.Rows.Add(items);
            }

            groups.Show();
        }

        private List<KeyValuePair<string, string>> Get_DB_list(string code)
        {
            string message = $"{code}: ---";
            message = Send(message);
            if (message.Contains("DISCONNECTED"))
            {
                MessageBox.Show("=== database exception ===", "DISCONNECTED");
                client.Close();
                Hide();
                auth.Show();
                return null;
            }

            if (message.Contains("EXCEPTION"))
            {
                MessageBox.Show($"=== {message} ===", "DATABASE EXCEPTION");
                return null;
            }

            string[] rows = message.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();
            foreach (string row in rows)
            {
                string[] items = row.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                result.Add(new KeyValuePair<string, string>(items[0], items[1]));
            }

            return result;
        }

        private void Process(string message)
        {
            message = Send(message);

            if (message.Contains("DISCONNECTED"))
            {
                MessageBox.Show("=== database exception ===", "DISCONNECTED");
                client.Close();
                Hide();
                auth.Show();
                return;
            }
            if (message.Contains("EXCEPTION"))
            {
                MessageBox.Show($"=== {message} ===", "DATABASE EXCEPTION");
                return;
            }

            MessageBox.Show($"{message.Substring(3)} row(s) affected");
        }

        private void Insert(string code, string title, short input_fields = 1, string[] hints = null)
        {
            string arguments = InputBox.ShowDialog(title, input_fields, hints);
            if (arguments == null) return;

            Process($"{code}: {arguments}");
        }

        private void Update(string code, string title, short input_fields = 1, string[] hints = null)
        {
            StringBuilder rows = new StringBuilder();
            foreach (DataGridViewRow row in DGRID_table.SelectedRows)
            {
                rows.Append($"~{row.Cells[0].Value}");
            }
            if (rows.Length == 0)
            {
                MessageBox.Show("Need to select rows before");
                return;
            }

            string arguments = InputBox.ShowDialog(title, input_fields, hints);
            if (arguments == null) return;

            Process($"{code}: {arguments} |:| {rows.ToString()}");
        }

        private void Delete(string code)
        {
            StringBuilder rows = new StringBuilder();
            foreach (DataGridViewRow row in DGRID_table.SelectedRows)
            {
                rows.Append($"~{row.Cells[0].Value}");
            }
            if (rows.Length == 0)
            {
                MessageBox.Show("Need to select rows before");
                return;
            }

            if (MessageBox.Show($"Are you sure you want\nto Delete {DGRID_table.SelectedRows.Count} row(s) and related", "Deleting", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Process($"{code}: {rows.ToString()}");
            }
        }
    }
}
