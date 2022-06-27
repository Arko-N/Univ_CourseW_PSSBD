using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Client
{
    public partial class FORM_diagram_AND_excel : Form
    {
        FORM_main main_form;

        public FORM_diagram_AND_excel(FORM_main main)
        {
            InitializeComponent();

            main_form = main;

            foreach (DataGridViewRow row in main_form.DGRID_table.Rows)
            {
                DIAGRAM_query.Series["Clients"].Points.AddXY(row.Cells[1].Value.ToString(), row.Cells[0].Value);
            }
        }

        private void BTN_load_Click(object sender, EventArgs e)
        {
            DIALOG_load.Filter = "Excel Documents (*.xls)|*.xls";
            DIALOG_load.FileName = "Report.xls";
            if (DIALOG_load.ShowDialog() == DialogResult.OK)
            {
                // COPY DGRID to Clipboard
                main_form.DGRID_table.SelectAll();
                DataObject dataObj = main_form.DGRID_table.GetClipboardContent();
                if (dataObj != null) Clipboard.SetDataObject(dataObj);

                // PROCESS
                object misValue = System.Reflection.Missing.Value;
                Excel.Application xlexcel = new Excel.Application();

                // Overrite all
                xlexcel.DisplayAlerts = false;
                Excel.Workbook xlWorkBook = xlexcel.Workbooks.Add(misValue);
                Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                // Format A:J as TEXT
                Excel.Range range = xlWorkSheet.get_Range("A:J").Cells;
                range.NumberFormat = "@";

                // Paste clipboard results to worksheet range
                range = (Excel.Range)xlWorkSheet.Cells[1, 1];
                range.Select();
                xlWorkSheet.PasteSpecial(range, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

                /*// For some reason column A is always blank in the worksheet. ¯\_(ツ)_/¯
                // Delete blank column A and select cell A1
                Excel.Range delRng = xlWorkSheet.get_Range("A:A").Cells;
                delRng.Delete(Type.Missing);
                xlWorkSheet.get_Range("A1").Select();*/

                // Save the excel file under the captured location from the SaveFileDialog
                xlWorkBook.SaveAs(DIALOG_load.FileName, Excel.XlFileFormat.xlWorkbookNormal,  misValue, misValue, misValue, misValue,
                                                        Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlexcel.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlexcel.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlexcel);

                // Clear Clipboard and DataGridView selection
                Clipboard.Clear();
                main_form.DGRID_table.ClearSelection();
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
