
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.Browser = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            Tabel = new System.Windows.Forms.TableLayoutPanel();
            this.Studys = new System.Windows.Forms.Label();
            this.Pp = new System.Windows.Forms.Label();
            this.Hours = new System.Windows.Forms.Label();
            this.Video = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.Publications = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Path = new System.Windows.Forms.ToolStripTextBox();
            this.Add = new System.Windows.Forms.ToolStripButton();
            this.Search = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            Tabel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.Controls.Add(this.Calendar);
            this.panel1.Controls.Add(this.Browser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 331);
            this.panel1.TabIndex = 12;
            // 
            // Calendar
            // 
            this.Calendar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Calendar.Dock = System.Windows.Forms.DockStyle.Top;
            this.Calendar.Location = new System.Drawing.Point(0, 0);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 1;
            // 
            // Browser
            // 
            this.Browser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Browser.BackColor = System.Drawing.SystemColors.Control;
            this.Browser.Location = new System.Drawing.Point(1, 165);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(162, 166);
            this.Browser.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 331);
            this.panel3.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(Tabel);
            this.panel2.Controls.Add(this.toolStrip1);
            this.panel2.Location = new System.Drawing.Point(164, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(620, 331);
            this.panel2.TabIndex = 0;
            // 
            // Tabel
            // 
            Tabel.AutoScroll = true;
            Tabel.BackColor = System.Drawing.SystemColors.HighlightText;
            Tabel.ColumnCount = 7;
            Tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.00000F));
            Tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67000F));
            Tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67000F));
            Tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67000F));
            Tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67000F));
            Tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67000F));
            Tabel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.67000F));
            Tabel.Controls.Add(this.Studys, 5, 0);
            Tabel.Controls.Add(this.Pp, 4, 0);
            Tabel.Controls.Add(this.Hours, 3, 0);
            Tabel.Controls.Add(this.Video, 2, 0);
            Tabel.Controls.Add(this.Date, 0, 0);
            Tabel.Controls.Add(this.Publications, 1, 0);
            Tabel.Dock = System.Windows.Forms.DockStyle.Top;
            Tabel.Location = new System.Drawing.Point(0, 25);
            Tabel.Name = "Tabel";
            Tabel.RowCount = 1;
            Tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            Tabel.Size = new System.Drawing.Size(620, 20);
            Tabel.TabIndex = 12;
            // 
            // Studys
            // 
            this.Studys.BackColor = System.Drawing.SystemColors.Control;
            this.Studys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Studys.Location = new System.Drawing.Point(477, 0);
            this.Studys.Name = "Studys";
            this.Studys.Size = new System.Drawing.Size(66, 20);
            this.Studys.TabIndex = 5;
            this.Studys.Text = "Изучения";
            this.Studys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pp
            // 
            this.Pp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pp.Location = new System.Drawing.Point(405, 0);
            this.Pp.Name = "Pp";
            this.Pp.Size = new System.Drawing.Size(66, 20);
            this.Pp.TabIndex = 4;
            this.Pp.Text = "п/п";
            this.Pp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Hours
            // 
            this.Hours.BackColor = System.Drawing.SystemColors.Control;
            this.Hours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Hours.Location = new System.Drawing.Point(333, 0);
            this.Hours.Name = "Hours";
            this.Hours.Size = new System.Drawing.Size(66, 20);
            this.Hours.TabIndex = 3;
            this.Hours.Text = "Часы";
            this.Hours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Video
            // 
            this.Video.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Video.Location = new System.Drawing.Point(261, 0);
            this.Video.Name = "Video";
            this.Video.Size = new System.Drawing.Size(66, 20);
            this.Video.TabIndex = 2;
            this.Video.Text = "Видео";
            this.Video.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Date
            // 
            this.Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Date.Location = new System.Drawing.Point(3, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(180, 20);
            this.Date.TabIndex = 0;
            this.Date.Text = "Дата";
            this.Date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Publications
            // 
            this.Publications.BackColor = System.Drawing.SystemColors.Control;
            this.Publications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Publications.Location = new System.Drawing.Point(189, 0);
            this.Publications.Name = "Publications";
            this.Publications.Size = new System.Drawing.Size(66, 20);
            this.Publications.TabIndex = 1;
            this.Publications.Text = "Публикации";
            this.Publications.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Path,
            this.Add,
            this.Search});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(620, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Path
            // 
            this.Path.BackColor = System.Drawing.Color.Silver;
            this.Path.Name = "Path";
            this.Path.Size = new System.Drawing.Size(220, 25);
            this.Path.Click += new System.EventHandler(this.Path_Click);
            // 
            // Add
            // 
            this.Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Add.Image = ((System.Drawing.Image)(resources.GetObject("Add.Image")));
            this.Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(63, 22);
            this.Add.Text = "Добавить";
            this.Add.Click += new System.EventHandler(this.Add_Click);
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
            this.ClientSize = new System.Drawing.Size(784, 331);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 370);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            Tabel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.TreeView Browser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox Path;
        private System.Windows.Forms.ToolStripButton Add;
        private System.Windows.Forms.ToolStripButton Search;
        private System.Windows.Forms.Label Studys;
        private System.Windows.Forms.Label Pp;
        private System.Windows.Forms.Label Hours;
        private System.Windows.Forms.Label Video;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label Publications;
        public static System.Windows.Forms.TableLayoutPanel Tabel;
    }
}

