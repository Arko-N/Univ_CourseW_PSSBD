using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    class InputBox : IDisposable
    {
        private static Form INPUT_box { get; set; }

        private InputBox() { }

        /// <summary>
        /// Creates WinForms dialog for getting ansver by user
        /// </summary>
        /// <param name="caption">Text line, that will be shown as form header</param>
        /// <param name="fields">Short int value, that reflects count of dialog fields</param>
        /// <param name="hints">List of lines, that will be used as hits on fileds.
        /// Can be "NULL" for skipping field hit.
        /// Can be as line like "value1~value2~..." that means field will be like combobox with this values</param>
        /// <returns>Concat each field of dialog to string, separate values by "~"</returns>
        public static string ShowDialog(string caption = "", short fields = 1, string[] hints = null)
        {
            int tbHeight = new TextBox().Height + 10;
            int btHeight = new Button().Height + 20;

            INPUT_box = new Form()
            {
#if !DEBUG
                Icon = new System.Drawing.Icon("icon.ico"),
#endif

                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                TopMost = true,

                Width = 500,
                Height = tbHeight * fields + btHeight + 50,

                Text = caption
            };

            Button BTN_accept = new Button()
            {
                Text = "ACCEPT",
                Width = 100,
                Left = 345,
                Top = tbHeight * fields + 20,

                DialogResult = DialogResult.OK,
                FlatStyle = FlatStyle.Flat,
                ForeColor = System.Drawing.Color.DarkGreen
            };
            BTN_accept.Click += (sender, e) => { INPUT_box.Close(); };
            INPUT_box.Controls.Add(BTN_accept);

            List<Control> fields_list = new List<Control>();
            for (int f = 0, h = 0; f < fields; f++, h++)
            {
                Control control = new TextBox();
                if (hints != null && h < hints.Length && hints[h] != null)
                {
                    string[] elements = hints[h].Split(new[] { '~' }, StringSplitOptions.RemoveEmptyEntries);

                    if (elements.Length == 1)
                    {
                        Label hint = new Label()
                        {
                            Visible = false,
                            Text = elements[0]
                        };

                        control.ForeColor = System.Drawing.Color.Gray;
                        control.Text = hint.Text;
                        control.GotFocus += (s, e) =>
                        {
                            if (control.ForeColor == System.Drawing.Color.Gray)
                            {
                                control.Text = "";
                                control.ForeColor = System.Drawing.Color.DarkBlue;
                            }
                        };
                        control.LostFocus += (s, e) =>
                        {
                            if (control.Text == "")
                            {
                                control.Text = hint.Text;
                                control.ForeColor = System.Drawing.Color.Gray;
                            }
                        };

                        INPUT_box.Controls.Add(hint);
                    }
                    else
                    {
                        control = new ComboBox();
                        ((ComboBox)control).Items.AddRange(elements);
                        ((ComboBox)control).DropDownStyle = ComboBoxStyle.DropDownList;
                    }
                }

                control.Left = 40; control.Top = 10 + tbHeight * f;
                control.Width = 405;
                if (control.ForeColor != System.Drawing.Color.Gray) control.ForeColor = System.Drawing.Color.DarkBlue;
                control.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    { e.SuppressKeyPress = true; INPUT_box.SelectNextControl((Control)s, true, true, true, true); }

                    if (e.KeyCode == Keys.Escape)
                    { e.SuppressKeyPress = true; BTN_accept.Focus(); }
                };

                INPUT_box.Controls.Add(control);
                fields_list.Add(control);
            }

            if (INPUT_box.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Control field in fields_list)
                {
                    string argument = "";
                    if (field.ForeColor == System.Drawing.Color.DarkBlue) argument = field.Text.Trim();
                    sb.Append($"~{argument}");
                }

                return sb.ToString();
            }
            else return null;
        }

        public void Dispose()
        {
            if (INPUT_box != null) INPUT_box.Dispose();
        }
    }
}
