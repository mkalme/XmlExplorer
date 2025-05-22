using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using XmlFileEngine;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Reflection;

namespace XmlExplorer
{
    public partial class Explorer : Form
    {
        public static Commands xmlCommands;
        public static string path = "";

        public static string ExplorerPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Xml Explorer 2019 v1.0";

        public static Dictionary<int, string[]> AllFiles = new Dictionary<int, string[]>(); //index -  new string[]{0 - type, 1 - full path}

        public static string[,] Clipboard = { { "", "" } };

        //Visited directories global variable
        public static List<string> VisitedDirectories = new List<string>();
        public static int IndexOfVisitedDirectories = -1;

        //Selected items global variable
        public static Dictionary<string, string> SelectedItems = new Dictionary<string, string>(); // path, path selected
        public static int CurrentDirectoryLevel = 0;


        //Class Initializer
        public Explorer()
        {
            InitializeComponent();

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1){
                xmlCommands = new Commands(args[1].Split('\n')[0]);
                path = args[1].Split('\n')[1];
            }else {
                fileBrowser.ShowDialog();

                if (fileBrowser.FileNames.Length == 0){
                    Environment.Exit(1);
                }
                else {
                    xmlCommands = new Commands(fileBrowser.FileName);
                    path = "";
                }
            }
        }

        //Setup Explorer
        private void Explorer_Load(object sender, EventArgs e)
        {
            setTheme();
            setExplorerPath();

            Methods.SetCommonFileExtensions();
            Methods.SetPrograms();

            loadFiles();
            loadDataGridView();

            setFileWatcher();

            timer.Start();
        }
        private void setTheme()
        {
            Focus();
            BackColor = Settings.ExplorerForm_BackColor;

            tableLayoutPanel2.BackColor = Settings.ExplorerForm_BackColorDark;

            panel3.BackColor = ColorTranslator.FromHtml("#353535");
            itemCountLabel.ForeColor = Settings.DataGridView_ForeColor;

            //Button
            leftArrowButton.BackColor = Settings.ExplorerForm_BackColorDark;
            leftArrowButton.ForeColor = Settings.Button_ForeColor;
            leftArrowButton.FlatAppearance.BorderColor = Settings.ExplorerForm_BackColorDark;

            rightArrowButton.BackColor = Settings.ExplorerForm_BackColorDark;
            rightArrowButton.ForeColor = Settings.Button_BackColor;
            rightArrowButton.FlatAppearance.BorderColor = Settings.ExplorerForm_BackColorDark;

            //TextBox
            pathTextBox.BackColor = Settings.ExplorerForm_BackColorDark;
            pathTextBox.ForeColor = Settings.DataGridView_ForeColor;
            pathTextBox.BorderStyle = BorderStyle.FixedSingle;

            searchTextBox.BackColor = Settings.ExplorerForm_BackColorDark;
            searchTextBox.ForeColor = Color.Orange;
            searchTextBox.BorderStyle = BorderStyle.FixedSingle;

            //DatagGridView
            dataGridView1.DoubleBuffered(true);

            dataGridView1.BackgroundColor = Settings.ExplorerForm_BackColor;
            dataGridView1.DefaultCellStyle.BackColor = Settings.ExplorerForm_BackColor;
            dataGridView1.DefaultCellStyle.ForeColor = Settings.DataGridView_ForeColor;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Settings.DataGridView_RowSelectionColor;

            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;

            dataGridView1.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            dataGridView1.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Settings.ExplorerForm_BackColor;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(3, 3, 3, 3);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.LightGray;

            dataGridView1.EnableHeadersVisualStyles = false;

            //ContextMenuStrip
            ToolStripMenuItem[] toolStripMenus = {openToolStripMenuItem, openWithToolStripMenuItem, copyToolStripMenuItem,
                                                  paseToolStripMenuItem, deleteToolStripMenuItem, moveToolStripMenuItem,
                                                  renameToolStripMenuItem, newToolStripMenuItem, folderToolStripMenuItem,
                                                  fileToolStripMenuItem };

            for (int i = 0; i < toolStripMenus.Length; i++)
            {
                toolStripMenus[i].BackColor = Settings.ExplorerForm_BackColor;
                toolStripMenus[i].ForeColor = Settings.DataGridView_ForeColor;
            }
        }
        private void setExplorerPath() {
            Directory.CreateDirectory(ExplorerPath + "/Storage");
        }

        //Update Explorer
        private void loadDataGridView() {
            preRow = -1;
            dataGridView1.Cursor = Cursors.Arrow;

            //Add Rows
            dataGridView1.Rows.Clear();
            for (int i = 0; i < AllFiles.Keys.Count; i++)
            {
                int type = Int32.Parse(AllFiles[i][0]);

                dataGridView1.Rows.Add(
                    i,
                    type == 0 ? Methods.DirectoryContainsFiles(AllFiles[i][1]) ? Properties.Resources.Directory_WithFile : Properties.Resources.Directory_Empty : (string.IsNullOrEmpty(Methods.GetExtensionIconPath(xmlCommands.GetFileAttribute(AllFiles[i][1], "extension"))) ?  Properties.Resources.File_NoExtension : Image.FromFile(Methods.GetExtensionIconPath(xmlCommands.GetFileAttribute(AllFiles[i][1], "extension")))),
                    type == 0 ? xmlCommands.GetDirectoryAttribute(AllFiles[i][1], "name") : xmlCommands.GetFileAttribute(AllFiles[i][1], "name"),
                    Methods.GetDateTimeShow(type == 0 ? xmlCommands.GetDirectoryAttribute(AllFiles[i][1], "modifdate") : xmlCommands.GetFileAttribute(AllFiles[i][1], "modifdate")),
                    type == 0 ? "Folder" : Methods.GetShowExtension(xmlCommands.GetFileAttribute(AllFiles[i][1], "extension")),
                    type == 0 ? Methods.GetShowSize(xmlCommands.GetDirectoryAttribute(AllFiles[i][1], "size")) : Methods.GetShowSize(xmlCommands.GetFileAttribute(AllFiles[i][1], "size"))
                );
                dataGridView1.Rows[i].ReadOnly = true;
            }

            //Selection
            dataGridView1.ClearSelection();
            if (SelectedItems.ContainsKey(path)){
                selectRowBasedOnItemPath(SelectedItems[path]);
            }

            //Miscellaneous
            pathTextBox.Text = Methods.GetPathTextBox();
            itemCountLabel.Text = AllFiles.Count + " Items";
        }
        private void loadFiles() {
            string[] directories = xmlCommands.GetAllDirectories(path);
            string[] files = xmlCommands.GetAllFiles(path);

            AllFiles.Clear();

            //directories
            for (int i = 0; i < directories.Length; i++)
            {
                AllFiles.Add(i, new string[] { "0", directories[i] });
            }

            //files
            for (int i = 0; i < files.Length; i++)
            {
                AllFiles.Add((i + directories.Length), new string[] { "1", files[i]});
            }
        }

        //Timer Tick
        private void timer_Tick(object sender, EventArgs e)
        {
            //Left Arrow Button
            if (path.Length > 0)
            {
                leftArrowButton.Enabled = true;
            }
            else
            {
                leftArrowButton.Enabled = false;
            }

            //Right Arrow Button
            if (VisitedDirectories.Count > 0 && IndexOfVisitedDirectories + 1 < VisitedDirectories.Count)
            {
                rightArrowButton.Enabled = true;
            }else
            {
                rightArrowButton.Enabled = false;
            }

            //Context Menu Strip
            if(dataGridView1.SelectedRows.Count > 0)
            {
                openToolStripMenuItem.Visible = true;
                deleteToolStripMenuItem.Visible = true;
                moveToolStripMenuItem.Visible = true;
                renameToolStripMenuItem.Visible = true;

                copyToolStripMenuItem.Enabled = true;
            }
            else
            {
                openToolStripMenuItem.Visible = false;
                deleteToolStripMenuItem.Visible = false;
                moveToolStripMenuItem.Visible = false;
                renameToolStripMenuItem.Visible = false;

                copyToolStripMenuItem.Enabled = false;
            }

            //Paste Tool Strip Menu Item
            if (!string.IsNullOrEmpty(Clipboard[0, 1]))
            {
                paseToolStripMenuItem.Enabled = true;
            }
            else {
                paseToolStripMenuItem.Enabled = false;
            }
        }

        //File Watcher
        private void setFileWatcher()
        {
            // Create a new FileSystemWatcher and set its properties.
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = System.IO.Path.GetDirectoryName(xmlCommands.BasePath);
            /* Watch for changes in LastAccess and LastWrite times, and 
               the renaming of files or directories. */
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            watcher.Filter = System.IO.Path.GetFileName(xmlCommands.BasePath);

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(onChanged);

            // Begin watching.
            watcher.EnableRaisingEvents = true;
        }
        private DateTime lastRead = DateTime.MinValue;
        private void onChanged(object source, FileSystemEventArgs a)
        {
            DateTime lastWriteTime = File.GetLastWriteTime(xmlCommands.BasePath);
            if (lastWriteTime != lastRead)
            {
                Methods.WaitTillFileIsReady(xmlCommands.BasePath);

                loadFiles();
                dataGridView1.Invoke(new Action(() => loadDataGridView()));

                lastRead = lastWriteTime;
            }
        }

        //Tool Strip Menu Items
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openItem(AllFiles[getData()][1]);
        }
        private void openWithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWith openWidth = new OpenWith();
            OpenWith.filePath = AllFiles[getData()][1];

            openWidth.ShowDialog();
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextInput input = new TextInput();
            TextInput.FormTitle = "New Folder";
            TextInput.TextBoxText = Methods.GetDirectoryName(path, "New Folder", 0);

            input.ShowDialog();

            if (!string.IsNullOrEmpty(TextInput.TextBoxText)){
                if (!xmlCommands.DirectoryExists(Path.Combine(path, TextInput.TextBoxText))){
                    xmlCommands.CreateDirectory(Path.Combine(new string[] { path, TextInput.TextBoxText }));
                }else{
                    MessageBox.Show("Directory already exists.\t\t\t\t\t", "Create a new file", MessageBoxButtons.OK);
                }
            }
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextInput input = new TextInput();
            TextInput.FormTitle = "New File";
            TextInput.TextBoxText = Methods.GetDirectoryName(path, "New File", 0) + ".txt";

            input.ShowDialog();

            if (!string.IsNullOrEmpty(TextInput.TextBoxText))
            {
                if (!xmlCommands.FileExists(Path.Combine(path, TextInput.TextBoxText))){
                    xmlCommands.CreateFile(Path.Combine(new string[] { path, TextInput.TextBoxText }));
                }else {
                    MessageBox.Show("File already exists.\t\t\t\t\t\t", "Create a new file", MessageBoxButtons.OK);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this?\t\t\t", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (AllFiles[getData()][0] == "0") {
                    xmlCommands.DeleteDirectory(AllFiles[getData()][1]);
                } else if (AllFiles[getData()][0] == "1") {
                    xmlCommands.DeleteFile(AllFiles[getData()][1]);
                }
            }
        }
        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextInput input = new TextInput();
            TextInput.FormTitle = "Rename " + (AllFiles[getData()][0] == "0" ? "folder" : "file");

            if (AllFiles[getData()][0] == "0"){
                TextInput.TextBoxText = xmlCommands.GetDirectoryAttribute(AllFiles[getData()][1], "name");
            }
            else if (AllFiles[getData()][0] == "1"){
                TextInput.TextBoxText = xmlCommands.GetFileAttribute(AllFiles[getData()][1], "name");
            }

            input.ShowDialog();

            if (!string.IsNullOrEmpty(TextInput.TextBoxText))
            {
                if (AllFiles[getData()][0] == "0")
                {
                    xmlCommands.ChangeDirectoryAttribute(AllFiles[getData()][1], "name", TextInput.TextBoxText);
                }
                else if (AllFiles[getData()][0] == "1")
                {
                    xmlCommands.ChangeFileAttribute(AllFiles[getData()][1], "name", TextInput.TextBoxText);
                    AllFiles[getData()][1] = Path.Combine(new string[] { Path.GetDirectoryName(AllFiles[getData()][1]), TextInput.TextBoxText });

                    xmlCommands.ChangeFileAttribute(AllFiles[getData()][1], "extension", Methods.GetExtension(TextInput.TextBoxText));
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard = new string[dataGridView1.SelectedRows.Count,2];

            for (int i = 0; i < Clipboard.GetLength(0); i++) {
                Clipboard[i, 0] = AllFiles[Int32.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[i].Index].Cells[0].Value.ToString())][0];
                Clipboard[i, 1] = AllFiles[Int32.Parse(dataGridView1.Rows[dataGridView1.SelectedRows[i].Index].Cells[0].Value.ToString())][1];
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pathToPaste = path;
            if (dataGridView1.SelectedRows.Count > 0){
                if (AllFiles[getData()][0] == "0"){
                    pathToPaste = Path.Combine(path, xmlCommands.GetDirectoryAttribute(AllFiles[getData()][1], "name"));
                }
            }

            for (int i = 0; i < Clipboard.GetLength(0); i++){
                if (Clipboard[i, 0] == "0"){
                    if (xmlCommands.DirectoryExists(Clipboard[i, 1]) && !Clipboard[i, 1].Equals(pathToPaste)){
                        xmlCommands.CloneDirectory(
                                                   Clipboard[i, 1],
                                                   pathToPaste,
                                                   Methods.GetDirectoryName(pathToPaste,
                                                       xmlCommands.GetDirectoryAttribute(Clipboard[i, 1], "name"), 1));
                    }else{
                        if (Clipboard[i, 1].Equals(pathToPaste)){
                            MessageBox.Show("Copied directory is the same as destination.\t\t", "Paste", MessageBoxButtons.OK);
                        }else{
                            MessageBox.Show("Directory doesn't exist.\t\t\t", "Paste", MessageBoxButtons.OK);
                        }
                    }
                }else if (Clipboard[i, 0] == "1"){
                    if (xmlCommands.FileExists(Clipboard[i, 1])){
                        xmlCommands.CloneFile(
                                              Clipboard[i, 1],
                                              pathToPaste,
                                              Methods.GetFileName(pathToPaste,
                                                  xmlCommands.GetFileAttribute(Clipboard[i, 1], "name"), 1));
                    }else{
                        MessageBox.Show("File doesn't exist.\t\t\t\t\t", "Paste", MessageBoxButtons.OK);
                    }
                }
            }
        }

        //DropDown
        private void dropDown_Opening(object sender, CancelEventArgs e){
            var hit = dataGridView1.HitTest(MousePosition.X - dataGridView1.Location.X - Location.X - dataGridView1.Margin.Left,
                                            MousePosition.Y - dataGridView1.Location.Y - dataGridView1.ColumnHeadersHeight - Location.Y -
                                                 dataGridView1.Margin.Top - dataGridView1.ColumnHeadersDefaultCellStyle.Padding.Top
                      );

            if (hit.RowIndex < 0){
                dataGridView1.ClearSelection();

                if (SelectedItems.ContainsKey(path))
                {
                    SelectedItems[path] = "";
                }
                else {
                    SelectedItems.Add(path, "");
                }
            }
            else{
                if (!dataGridView1.Rows[hit.RowIndex].Selected) {
                    dataGridView1.ClearSelection();
                }

                dataGridView1.Rows[hit.RowIndex].Selected = true;

                if (SelectedItems.ContainsKey(path))
                {
                    SelectedItems[path] = AllFiles[getData()][1];
                }
                else
                {
                    SelectedItems.Add(path, AllFiles[getData()][1]);
                }
            }
        }

        //DataGridView
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var hit = dataGridView1.HitTest(e.X, e.Y);

            if (hit.Type == DataGridViewHitTestType.None)
            {
                dataGridView1.ClearSelection();

                if (SelectedItems.ContainsKey(path))
                {
                    SelectedItems[path] = "";
                }else{
                    SelectedItems.Add(path, "");
                }
            }
            else if (hit.Type == DataGridViewHitTestType.Cell){
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    if (SelectedItems.ContainsKey(path))
                    {
                        SelectedItems[path] = AllFiles[getData()][1];
                    }else{
                        SelectedItems.Add(path, AllFiles[getData()][1]);
                    }
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0){
                string SelectedFile = AllFiles[getData()][1];

                openItem(SelectedFile);
            }
        }
        private void openItem(string itemPath)
        {
            if (AllFiles[getData()][0] == "0"){

                path = Path.Combine(path, xmlCommands.GetDirectoryAttribute(itemPath, "name"));

                //visited directories
                IndexOfVisitedDirectories++;
                if (VisitedDirectories.Count == IndexOfVisitedDirectories)
                {//check if to add new
                    VisitedDirectories.Add(xmlCommands.GetDirectoryAttribute(itemPath, "name"));
                }
                else if (!VisitedDirectories[IndexOfVisitedDirectories].Equals(xmlCommands.GetDirectoryAttribute(itemPath, "name")))
                {//if not the same
                    VisitedDirectories.RemoveRange(IndexOfVisitedDirectories, VisitedDirectories.Count - IndexOfVisitedDirectories);
                    VisitedDirectories.Add(xmlCommands.GetDirectoryAttribute(itemPath, "name"));
                }

                CurrentDirectoryLevel++;

                loadFiles();
                loadDataGridView();
            }
            else if (AllFiles[getData()][0] == "1"){
                Process p = new Process();
                
                p.StartInfo.FileName = ExplorerPath + @"\Storage\Programs\" + Methods.GetProgramAttributes(xmlCommands.GetFileAttribute(AllFiles[getData()][1], "extension"), 0);
                p.StartInfo.Arguments = "\"" + xmlCommands.BasePath + "\n" + AllFiles[getData()][1] + "\"";

                if (File.Exists(p.StartInfo.FileName)){
                    p.Start();
                }else {
                    MessageBox.Show("The program to open the file has not been found.\t\t", "Open", MessageBoxButtons.OK);
                }
            }
        }

        private int preRow = -1;
        private void dataGridView1_MouseLeave(object sender, EventArgs e){
            if (preRow > -1){
                dataGridView1.Rows[preRow].DefaultCellStyle.BackColor = Settings.ExplorerForm_BackColor;

                preRow = -1;

                dataGridView1.Cursor = Cursors.Arrow;
            }
        }
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e){
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

        private int getData()
        {
            int value = 0;

            if (dataGridView1.SelectedRows.Count > 0) {
                bool result = Int32.TryParse(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString(), out value);
            }

            return value;
        }
        private void selectRowBasedOnItemPath(string itemPath)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (AllFiles[i][1].Equals(itemPath))
                {
                    dataGridView1.Rows[i].Selected = true;
                    i = dataGridView1.RowCount;
                }
            }
        }
        private void selectRowBasedOnValue(int col, string value)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[col].Value.ToString().Equals(value))
                {
                    dataGridView1.Rows[i].Selected = true;
                    i = dataGridView1.RowCount;
                }
            }
        }

        //Left-Right Buttons
        private void leftArrowButton_Click(object sender, EventArgs e)
        {
            path = Path.GetDirectoryName(path);

            IndexOfVisitedDirectories--;
            CurrentDirectoryLevel--;

            loadFiles();
            loadDataGridView();
        }
        private void rightArrowButton_Click(object sender, EventArgs e)
        {
            IndexOfVisitedDirectories++;
            CurrentDirectoryLevel++;

            path = Path.Combine(path, VisitedDirectories[IndexOfVisitedDirectories]);

            loadFiles();
            loadDataGridView();
        }

        //Search TextBox
        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            searchItems(searchTextBox.Text);
        }
        private void searchItems(string name){
            for (int i = 0; i < dataGridView1.RowCount; i++){
                if (!dataGridView1.Rows[i].Cells[2].Value.ToString().ToLower().Contains(name.ToLower()) && !string.IsNullOrEmpty(name)){
                    dataGridView1.Rows[i].Visible = false;
                }else
                {
                    dataGridView1.Rows[i].Visible = true;
                }
            }
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
