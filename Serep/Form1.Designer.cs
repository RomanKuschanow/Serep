
namespace Serep
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Browser = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Report = new System.Windows.Forms.TabPage();
            this.Tabel = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Count = new System.Windows.Forms.TabPage();
            this.Counts = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Add = new System.Windows.Forms.Button();
            this.Study = new System.Windows.Forms.NumericUpDown();
            this.Pp = new System.Windows.Forms.NumericUpDown();
            this.Minute = new System.Windows.Forms.NumericUpDown();
            this.Hour = new System.Windows.Forms.NumericUpDown();
            this.Video = new System.Windows.Forms.NumericUpDown();
            this.Publications = new System.Windows.Forms.NumericUpDown();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Path = new System.Windows.Forms.ToolStripTextBox();
            this.Create = new System.Windows.Forms.ToolStripButton();
            this.Search = new System.Windows.Forms.ToolStripButton();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Report.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabel)).BeginInit();
            this.Count.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Counts)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Study)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Video)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Publications)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Browser
            // 
            this.Browser.BackColor = System.Drawing.SystemColors.Control;
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(0, 0);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(126, 261);
            this.Browser.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(674, 261);
            this.panel3.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Browser);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(674, 261);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Report);
            this.tabControl1.Controls.Add(this.Count);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 207);
            this.tabControl1.TabIndex = 18;
            // 
            // Report
            // 
            this.Report.Controls.Add(this.Tabel);
            this.Report.Location = new System.Drawing.Point(4, 24);
            this.Report.Name = "Report";
            this.Report.Padding = new System.Windows.Forms.Padding(3);
            this.Report.Size = new System.Drawing.Size(536, 179);
            this.Report.TabIndex = 0;
            this.Report.Text = "Отчеты";
            this.Report.UseVisualStyleBackColor = true;
            // 
            // Tabel
            // 
            this.Tabel.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Tabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Tabel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column14});
            this.Tabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabel.Location = new System.Drawing.Point(3, 3);
            this.Tabel.Name = "Tabel";
            this.Tabel.RowTemplate.Height = 25;
            this.Tabel.Size = new System.Drawing.Size(530, 173);
            this.Tabel.TabIndex = 14;
            this.Tabel.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Tabel_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Дата";
            this.Column1.Name = "Column1";
            this.Column1.Width = 57;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Публикации";
            this.Column2.Name = "Column2";
            this.Column2.Width = 101;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "Видео";
            this.Column3.Name = "Column3";
            this.Column3.Width = 65;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column4.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column4.HeaderText = "Часы";
            this.Column4.Name = "Column4";
            this.Column4.Width = 61;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "п/п";
            this.Column5.Name = "Column5";
            this.Column5.Width = 51;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column6.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column6.HeaderText = "Изучения";
            this.Column6.Name = "Column6";
            this.Column6.Width = 85;
            // 
            // Column14
            // 
            this.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column14.HeaderText = "Удалить";
            this.Column14.Name = "Column14";
            this.Column14.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column14.Text = "Удалить";
            this.Column14.ToolTipText = "Удалить";
            this.Column14.UseColumnTextForButtonValue = true;
            this.Column14.Width = 76;
            // 
            // Count
            // 
            this.Count.Controls.Add(this.Counts);
            this.Count.Location = new System.Drawing.Point(4, 24);
            this.Count.Name = "Count";
            this.Count.Padding = new System.Windows.Forms.Padding(3);
            this.Count.Size = new System.Drawing.Size(536, 179);
            this.Count.TabIndex = 1;
            this.Count.Text = "Подсчет";
            this.Count.UseVisualStyleBackColor = true;
            this.Count.Enter += new System.EventHandler(this.Count_Enter);
            // 
            // Counts
            // 
            this.Counts.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Counts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Counts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12});
            this.Counts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Counts.Location = new System.Drawing.Point(3, 3);
            this.Counts.Name = "Counts";
            this.Counts.RowTemplate.Height = 25;
            this.Counts.Size = new System.Drawing.Size(530, 173);
            this.Counts.TabIndex = 0;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Месяц/Год";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column8.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column8.HeaderText = "Публикации";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Видео";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column10.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column10.HeaderText = "Часы";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "п/п";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column12
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Column12.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column12.HeaderText = "Изучения";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel4.Controls.Add(this.Add);
            this.panel4.Controls.Add(this.Study);
            this.panel4.Controls.Add(this.Pp);
            this.panel4.Controls.Add(this.Minute);
            this.panel4.Controls.Add(this.Hour);
            this.panel4.Controls.Add(this.Video);
            this.panel4.Controls.Add(this.Publications);
            this.panel4.Controls.Add(this.date);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 25);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 29);
            this.panel4.TabIndex = 17;
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(465, 3);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 7;
            this.Add.Text = "Добавить";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // Study
            // 
            this.Study.AutoSize = true;
            this.Study.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Study.Location = new System.Drawing.Point(409, 3);
            this.Study.Name = "Study";
            this.Study.Size = new System.Drawing.Size(50, 23);
            this.Study.TabIndex = 6;
            // 
            // Pp
            // 
            this.Pp.AutoSize = true;
            this.Pp.Location = new System.Drawing.Point(353, 3);
            this.Pp.Name = "Pp";
            this.Pp.Size = new System.Drawing.Size(50, 23);
            this.Pp.TabIndex = 5;
            // 
            // Minute
            // 
            this.Minute.AutoSize = true;
            this.Minute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Minute.Location = new System.Drawing.Point(307, 3);
            this.Minute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.Minute.Name = "Minute";
            this.Minute.Size = new System.Drawing.Size(40, 23);
            this.Minute.TabIndex = 4;
            // 
            // Hour
            // 
            this.Hour.AutoSize = true;
            this.Hour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Hour.Location = new System.Drawing.Point(261, 3);
            this.Hour.Name = "Hour";
            this.Hour.Size = new System.Drawing.Size(41, 23);
            this.Hour.TabIndex = 3;
            // 
            // Video
            // 
            this.Video.AutoSize = true;
            this.Video.Location = new System.Drawing.Point(205, 3);
            this.Video.Name = "Video";
            this.Video.Size = new System.Drawing.Size(50, 23);
            this.Video.TabIndex = 2;
            // 
            // Publications
            // 
            this.Publications.AutoSize = true;
            this.Publications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Publications.Location = new System.Drawing.Point(149, 3);
            this.Publications.Name = "Publications";
            this.Publications.Size = new System.Drawing.Size(50, 23);
            this.Publications.TabIndex = 1;
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(3, 3);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(140, 23);
            this.date.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Path,
            this.Create,
            this.Search});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(544, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // Path
            // 
            this.Path.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(220, 25);
            // 
            // Create
            // 
            this.Create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Create.Image = ((System.Drawing.Image)(resources.GetObject("Create.Image")));
            this.Create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(54, 22);
            this.Create.Text = "Создать";
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // Search
            // 
            this.Search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Search.Image = ((System.Drawing.Image)(resources.GetObject("Search.Image")));
            this.Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(45, 22);
            this.Search.Text = "Найти";
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 261);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Report.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tabel)).EndInit();
            this.Count.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Counts)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Study)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Hour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Video)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Publications)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView Browser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Report;
        private System.Windows.Forms.DataGridView Tabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewButtonColumn Column14;
        private System.Windows.Forms.TabPage Count;
        private System.Windows.Forms.DataGridView Counts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.NumericUpDown Study;
        private System.Windows.Forms.NumericUpDown Pp;
        private System.Windows.Forms.NumericUpDown Minute;
        private System.Windows.Forms.NumericUpDown Hour;
        private System.Windows.Forms.NumericUpDown Video;
        private System.Windows.Forms.NumericUpDown Publications;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox Path;
        private System.Windows.Forms.ToolStripButton Create;
        private System.Windows.Forms.ToolStripButton Search;
    }
}

