using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serep
{
    class Lines
    {
        public DateTimePicker date, time;
        public NumericUpDown numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4;
        public Button add, edit, delete, confirm;

        //Label label1, label2, label3, label4, label5, label6;

        public Lines(string tipe)
        {
            if (tipe == "pick")
            {
                Form1.Tabel.Size = new(Form1.Tabel.Size.Width, Form1.Tabel.Size.Height + 30);
                Form1.Tabel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));

                date = new();
                numericUpDown1 = new();
                numericUpDown2 = new();
                time = new();
                time.Format = DateTimePickerFormat.Time;
                time.Value = time.MinDate;
                numericUpDown3 = new();
                numericUpDown4 = new();
                add = new();

                Form1.Tabel.Controls.Add(date, 0, 1);
                Form1.Tabel.Controls.Add(numericUpDown1, 1, 1);
                Form1.Tabel.Controls.Add(numericUpDown2, 2, 1);
                Form1.Tabel.Controls.Add(time, 3, 1);
                Form1.Tabel.Controls.Add(numericUpDown3, 4, 1);
                Form1.Tabel.Controls.Add(numericUpDown4, 5, 1);
                Form1.Tabel.Controls.Add(add, 6, 1);

                date.Dock = DockStyle.Fill;
                numericUpDown1.Dock = DockStyle.Fill;
                numericUpDown1.BackColor = System.Drawing.SystemColors.Control;
                numericUpDown2.Dock = DockStyle.Fill;
                time.Dock = DockStyle.Right;
                time.BackColor = System.Drawing.SystemColors.Control;
                numericUpDown3.Dock = DockStyle.Fill;
                numericUpDown4.Dock = DockStyle.Fill;
                numericUpDown4.BackColor = System.Drawing.SystemColors.Control;
                add.Dock = DockStyle.Fill;
            }
            //else if (tipe == "show")
            //{

            //}
        }
    }
}
