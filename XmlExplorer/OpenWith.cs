using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace XmlExplorer
{
    public partial class OpenWith : Form
    {
        public static string filePath = "";

        public OpenWith()
        {
            InitializeComponent();
        }

        private void OpenWith_Load(object sender, EventArgs e)
        {
            setForm();

            preRow = -1;

            loadDataGridView();
        }

        private void setForm() {
            BackColor = Settings.ExplorerForm_BackColor;

            //DatagGridView
            dataGridView1.DoubleBuffered(true);

            dataGridView1.BackgroundColor = Settings.ExplorerForm_BackColor;
            dataGridView1.DefaultCellStyle.BackColor = Settings.ExplorerForm_BackColor;
            dataGridView1.DefaultCellStyle.ForeColor = Settings.DataGridView_ForeColor;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Settings.DataGridView_RowSelectionColor;

            dataGridView1.RowTemplate.Height = 40;

            dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

            dataGridView1.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView1.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;

            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void loadDataGridView() {
            preRow = -1;

            dataGridView1.Rows.Clear();

            for (int i = 0; i < Settings.ListOfPrograms.Count; i++) {
                string programPath = Explorer.ExplorerPath + @"\Storage\Programs\" + Settings.ListOfPrograms[i][0];

                Icon icon = Properties.Resources.ExecutableIcon;

                if (File.Exists(programPath)) {
                    icon = Icon.ExtractAssociatedIcon(programPath);
                }

                dataGridView1.Rows.Add(i,
                                       File.Exists(programPath) ? (!icon.Equals(SystemIcons.Application) ? icon : Properties.Resources.ExecutableIcon) : Properties.Resources.FileDoesntExistIcon,
                                       Settings.ListOfPrograms[i][1]
                                       );
            }

            dataGridView1.ClearSelection();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dataGridView1.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                dataGridView1.ClearSelection();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string programPath = Settings.ListOfPrograms[Int32.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString())][0];

            Process p = new Process();

            p.StartInfo.FileName = Explorer.ExplorerPath + @"\Storage\Programs\" + programPath;
            p.StartInfo.Arguments = "\"" + Explorer.xmlCommands.BasePath + "\n" + filePath + "\"";

            if (File.Exists(p.StartInfo.FileName)){
                p.Start();
            }else{
                MessageBox.Show("The program to open the file has not been found.\t\t", "Open", MessageBoxButtons.OK);
            }

            Close();
        }

        private static int preRow = -1;
        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            if (preRow > -1){
                dataGridView1.Rows[preRow].DefaultCellStyle.BackColor = Settings.ExplorerForm_BackColor;

                preRow = -1;

                dataGridView1.Cursor = Cursors.Arrow;
            }
        }
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            var hit = dataGridView1.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.Cell){
                if (preRow != hit.RowIndex){
                    dataGridView1.Rows[hit.RowIndex].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#444444");

                    if (preRow > -1){
                        dataGridView1.Rows[preRow].DefaultCellStyle.BackColor = Settings.ExplorerForm_BackColor;
                    }
                    preRow = hit.RowIndex;
                }

                dataGridView1.Cursor = Cursors.Hand;
            }else if (hit.Type == DataGridViewHitTestType.None && preRow > -1){
                dataGridView1.Rows[preRow].DefaultCellStyle.BackColor = Settings.ExplorerForm_BackColor;
                preRow = -1;

                dataGridView1.Cursor = Cursors.Arrow;
            }
        }
    }
}
