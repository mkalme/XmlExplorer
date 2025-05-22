namespace XmlExplorer
{
    partial class Explorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.fileBrowser = new System.Windows.Forms.OpenFileDialog();
            this.dropDown = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rightArrowButton = new System.Windows.Forms.Button();
            this.leftArrowButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.itemCountLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.dropDown.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dropDown
            // 
            this.dropDown.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dropDown.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openWithToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.paseToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.newToolStripMenuItem});
            this.dropDown.Name = "contextMenuStrip1";
            this.dropDown.Size = new System.Drawing.Size(146, 196);
            this.dropDown.Opening += new System.ComponentModel.CancelEventHandler(this.dropDown_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openWithToolStripMenuItem
            // 
            this.openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
            this.openWithToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.openWithToolStripMenuItem.Text = "Open With";
            this.openWithToolStripMenuItem.Click += new System.EventHandler(this.openWithToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::XmlExplorer.Properties.Resources.CopyItem;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // paseToolStripMenuItem
            // 
            this.paseToolStripMenuItem.Image = global::XmlExplorer.Properties.Resources.PasteIcon;
            this.paseToolStripMenuItem.Name = "paseToolStripMenuItem";
            this.paseToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.paseToolStripMenuItem.Text = "Paste";
            this.paseToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::XmlExplorer.Properties.Resources.DeleteIcon;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.moveToolStripMenuItem.Text = "Move ";
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem,
            this.fileToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.newToolStripMenuItem.Text = "New";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Image = global::XmlExplorer.Properties.Resources.Directory_Empty_Big;
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.folderToolStripMenuItem.Text = "Folder         ";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Image = global::XmlExplorer.Properties.Resources.File_NoExtension_Big;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(837, 478);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 58);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.pathTextBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.searchTextBox, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(837, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pathTextBox
            // 
            this.pathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pathTextBox.Font = new System.Drawing.Font("Arial", 8F);
            this.pathTextBox.Location = new System.Drawing.Point(61, 5);
            this.pathTextBox.Margin = new System.Windows.Forms.Padding(0, 5, 1, 0);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(579, 20);
            this.pathTextBox.TabIndex = 0;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.searchTextBox.Location = new System.Drawing.Point(660, 5);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(0, 1, 10, 0);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(167, 20);
            this.searchTextBox.TabIndex = 1;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rightArrowButton);
            this.panel1.Controls.Add(this.leftArrowButton);
            this.panel1.Location = new System.Drawing.Point(6, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(55, 29);
            this.panel1.TabIndex = 2;
            // 
            // rightArrowButton
            // 
            this.rightArrowButton.BackgroundImage = global::XmlExplorer.Properties.Resources.RightArrow;
            this.rightArrowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rightArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightArrowButton.Location = new System.Drawing.Point(28, 4);
            this.rightArrowButton.Name = "rightArrowButton";
            this.rightArrowButton.Size = new System.Drawing.Size(21, 21);
            this.rightArrowButton.TabIndex = 1;
            this.rightArrowButton.UseVisualStyleBackColor = true;
            this.rightArrowButton.Click += new System.EventHandler(this.rightArrowButton_Click);
            // 
            // leftArrowButton
            // 
            this.leftArrowButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftArrowButton.BackgroundImage")));
            this.leftArrowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.leftArrowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftArrowButton.Location = new System.Drawing.Point(2, 4);
            this.leftArrowButton.Name = "leftArrowButton";
            this.leftArrowButton.Size = new System.Drawing.Size(21, 21);
            this.leftArrowButton.TabIndex = 0;
            this.leftArrowButton.UseVisualStyleBackColor = true;
            this.leftArrowButton.Click += new System.EventHandler(this.leftArrowButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.ContextMenuStrip = this.dropDown;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(10, 90);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(824, 360);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            this.dataGridView1.MouseLeave += new System.EventHandler(this.dataGridView1_MouseLeave);
            this.dataGridView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseMove);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Index";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 300;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "";
            this.Column2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 30;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Name";
            this.Column3.Name = "Column3";
            this.Column3.Width = 230;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Modification Date";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 135;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "Extension";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 135;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Size";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.itemCountLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 453);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(837, 25);
            this.panel3.TabIndex = 3;
            // 
            // itemCountLabel
            // 
            this.itemCountLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.itemCountLabel.AutoSize = true;
            this.itemCountLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.itemCountLabel.Location = new System.Drawing.Point(13, 5);
            this.itemCountLabel.Name = "itemCountLabel";
            this.itemCountLabel.Size = new System.Drawing.Size(0, 15);
            this.itemCountLabel.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(837, 478);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Explorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xml Explorer";
            this.Load += new System.EventHandler(this.Explorer_Load);
            this.dropDown.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fileBrowser;
        private System.Windows.Forms.ContextMenuStrip dropDown;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button rightArrowButton;
        private System.Windows.Forms.Button leftArrowButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label itemCountLabel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem openWithToolStripMenuItem;
    }
}

