using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XmlExplorer
{
    public partial class TextInput : Form
    {
        public static string FormTitle = "";
        public static string TextBoxText = "";

        public TextInput()
        {
            InitializeComponent();
        }

        private void TextInput_Load(object sender, EventArgs e)
        {
            setTheme();

            TextBoxText = "";
        }

        private void setTheme()
        {
            BackColor = Settings.ExplorerForm_BackColor;

            //Button
            doneButton.BackColor = Settings.Button_BackColor;
            doneButton.ForeColor = Settings.Button_ForeColor;
            doneButton.FlatAppearance.BorderColor = Settings.Button_BorderColor;

            //TextBox
            textBox.BackColor = Settings.ExplorerForm_BackColor;
            textBox.ForeColor = Settings.DataGridView_ForeColor;
            textBox.BorderStyle = BorderStyle.FixedSingle;

            Text = FormTitle;
            textBox.Text = TextBoxText;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            TextBoxText = textBox.Text;

            Close();
        }
    }
}
