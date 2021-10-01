using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Win32;
using System.Timers;

namespace Serep
{
    public partial class Form1 : Form
    {
        ReadedReport json;
        bool timer = false;
        public delegate void delegat();

        public Form1()
        {
            InitializeComponent();

            Browser.BeforeSelect += Browser_BeforeSelect;
            Browser.AfterSelect += Browser_AfterSelect;
            Browser.BeforeExpand += Browser_BeforeExpand;
            Browser.BeforeCollapse += Browser_BeforeCollapse;
            // заполняем дерево дисками
            FillDriveNodes();

            Path.Text = Registry_Read("path", Registry.CurrentUser.CreateSubKey("Serep")).ToString();
            StreamReader file = new(Path.Text);
            json = JsonConvert.DeserializeObject<ReadedReport>(file.ReadToEnd());
            file.Close();
            File_Open();
            if (json == null)
                json = new();
        }


        //событие перед скрытием узла
        private void Browser_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            string[] files;
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    files = Directory.GetFiles(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                    if (files.Length != 0)
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i].Remove(0, (files[i].LastIndexOf(".") + 1)) == "json")
                            {
                                TreeNode fileNode = new(new DirectoryInfo(files[i]).Name);
                                e.Node.Nodes.Add(fileNode);
                            }
                            else
                                continue;
                        }
                    }
                }
            }
            catch { }
        }

        // событие перед раскрытием узла
        void Browser_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            string[] files;
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    files = Directory.GetFiles(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                    if (files.Length != 0)
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i].Remove(0, (files[i].LastIndexOf(".") + 1)) == "json")
                            {
                                TreeNode fileNode = new(new DirectoryInfo(files[i]).Name);
                                e.Node.Nodes.Add(fileNode);
                            }
                            else
                                continue;
                        }
                    }
                }
            }
            catch { }
        }

        // событие перед выделением узла
        void Browser_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            string[] dirs;
            string[] files;
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    dirs = Directory.GetDirectories(e.Node.FullPath);
                    files = Directory.GetFiles(e.Node.FullPath);
                    if (dirs.Length != 0)
                    {
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            TreeNode dirNode = new(new DirectoryInfo(dirs[i]).Name);
                            FillTreeNode(dirNode, dirs[i]);
                            e.Node.Nodes.Add(dirNode);
                        }
                    }
                    if (files.Length != 0)
                    {
                        for (int i = 0; i < files.Length; i++)
                        {
                            if (files[i].Remove(0, (files[i].LastIndexOf(".") + 1)) == "json")
                            {
                                TreeNode fileNode = new(new DirectoryInfo(files[i]).Name);
                                e.Node.Nodes.Add(fileNode);
                            }
                            else
                                continue;
                        }
                    }
                }
            }
            catch { }
        }

        // событие после выделение узла
        private void Browser_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                Path.Text = e.Node.FullPath.Remove(e.Node.FullPath.IndexOf("\\"), e.Node.FullPath.IndexOf("\\") - 1);
            }
            catch
            {
            }

            try
            {
                if (File.Exists(Path.Text))
                {
                    if (e.Node.Text.Remove(0, (e.Node.Text.LastIndexOf(".") + 1)) == "json")
                    {
                        StreamReader file = new(e.Node.FullPath);
                        json = JsonConvert.DeserializeObject<ReadedReport>(file.ReadToEnd());
                        file.Close();
                        File_Open();
                        if (json == null)
                            json = new();
                        Registry_Write("path", Path.Text, RegistryValueKind.String, Registry.CurrentUser.CreateSubKey("Serep"));
                    }
                }
            }
            catch
            {
                MessageBox.Show("!!!Файл поврежден или не предназначен для чтения данной программой.");
            }
            Registry_Read("path", Registry.CurrentUser.CreateSubKey("Serep"));
        }

        // получаем все диски на компьютере
        private void FillDriveNodes()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode driveNode = new TreeNode { Text = drive.Name };
                    FillTreeNode(driveNode, drive.Name);
                    Browser.Nodes.Add(driveNode);
                }
            }
            catch { }
        }

        // получаем дочерние узлы для определенного узла
        private void FillTreeNode(TreeNode driveNode, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new();
                    dirNode.Text = dir.Remove(0, dir.LastIndexOf("\\") + 1);
                    driveNode.Nodes.Add(dirNode);
                }
                foreach (string file in files)
                {
                    if (file.Remove(0, (file.LastIndexOf(".") + 1)) == "json")
                    {
                        TreeNode fileNode = new();
                        fileNode.Text = file.Remove(0, file.LastIndexOf("\\") + 1);
                        driveNode.Nodes.Add(fileNode);
                    }
                    else
                        continue;
                }
            }
            catch { }
        }

        // добавления файла
        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                File.Create(Path.Text).Close();
                json = new();
                File_Open();
                Registry_Write("path", Path.Text, RegistryValueKind.String, Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time"));
            }
            catch
            {

            }
        }

        // открыть файл по заданному пути
        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader file = new(Path.Text);
                json = JsonConvert.DeserializeObject<ReadedReport>(file.ReadToEnd());
                file.Close();
                File_Open();
                if (json == null)
                    json = new();
                Registry_Write("path", Path.Text, RegistryValueKind.String, Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time"));
            }
            catch
            {
                MessageBox.Show("!!!Файл поврежден или не предназначен для чтения данной программой.");
            }
        }

        // событие после открытия файла
        private void File_Open()
        {
            Tabel.Rows.Clear();
            List<string[]> param = new();
            if (json != null)
            {
                json.Sorter();
                foreach (Report item in json.Items)
                {
                    string[] row = new string[] { item.Date.ToString(), item.Publication.ToString(), item.Video.ToString(), item.Hour.ToString() + ':' + item.Minute.ToString(), item.Pp.ToString(), item.Study.ToString(), item.Notes.ToString() };
                    param.Add(row);
                }
                foreach (string[] item in param)
                {
                    Tabel.Rows.Add(item);
                }
            }
        }

        // событие при старте формы
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // добавление по клавише Enter
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
                Add_Click(Add, null);
        }

        // кнопка добавления отчета
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (json.Items == null)
                    json.Items = new List<Report>();
                json.Items.Add(new Report(date.Value, Convert.ToInt32(Publications.Value), Convert.ToInt32(Video.Value), Convert.ToInt32(Hour.Value), Convert.ToInt32(Minute.Value), Convert.ToInt32(Pp.Value), Convert.ToInt32(Study.Value)));
                StreamWriter file = new(Path.Text);
                file.Write(JsonConvert.SerializeObject(json));
                file.Close();
                File_Open();
                date.Value = DateTime.Now;
                Publications.Value = 0;
                Video.Value = 0;
                Hour.Value = 0;
                Minute.Value = 0;
                Pp.Value = 0;
                Study.Value = 0;

            }
            catch
            {
            }
        }

        // изменение отчета
        private void Tabel_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        json.Items[e.RowIndex].Date = Convert.ToDateTime(Tabel[0, e.RowIndex].Value);
                        break;

                    case 1:
                        json.Items[e.RowIndex].Publication = Convert.ToInt32(Tabel[1, e.RowIndex].Value);
                        break;

                    case 2:
                        json.Items[e.RowIndex].Video = Convert.ToInt32(Tabel[2, e.RowIndex].Value);
                        break;

                    case 3:
                        json.Items[e.RowIndex].Hour = Convert.ToInt32(Convert.ToString(Tabel[3, e.RowIndex].Value).Remove(Convert.ToString(Tabel[3, e.RowIndex].Value).IndexOf(':')));
                        json.Items[e.RowIndex].Minute = Convert.ToInt32(Convert.ToString(Tabel[3, e.RowIndex].Value).Remove(0, Convert.ToString(Tabel[3, e.RowIndex].Value).IndexOf(':') + 1));
                        break;

                    case 4:
                        json.Items[e.RowIndex].Pp = Convert.ToInt32(Tabel[4, e.RowIndex].Value);
                        break;

                    case 5:
                        json.Items[e.RowIndex].Study = Convert.ToInt32(Tabel[5, e.RowIndex].Value);
                        break;

                    case 6:
                        json.Items[e.RowIndex].Notes = Convert.ToString(Tabel[6, e.RowIndex].Value);
                        break;

                    default:
                        break;
                }
                StreamWriter file = new(Path.Text);
                file.Write(JsonConvert.SerializeObject(json));
                file.Close();
                File_Open();
            }
            catch
            {
                File_Open();
            }
        }

        // удаление отчета
        private void Tabel_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                try
                {
                    json.Items.RemoveAt(e.RowIndex);
                    StreamWriter file = new(Path.Text);
                    file.Write(JsonConvert.SerializeObject(json));
                    file.Close();
                    File_Open();
                }
                catch
                {
                }
            }
        }

        // посчет отчета
        private void Count_Enter(object sender, EventArgs e)
        {
            StreamReader file = new(Path.Text);
            json = JsonConvert.DeserializeObject<ReadedReport>(file.ReadToEnd());
            file.Close();

            if (json != null)
            {
                Counts.Rows.Clear();
                List<object[]> param = new();
                json.Sorter();
                foreach (Report item in json.Items)
                {
                    object[] obj1 = new object[] { item.Date.Year };
                    object[] obj2 = new object[] { item.Date.Year, item.Date.Month };

                    if (param.Count == 0)
                    {
                        param.Add(obj1);
                        param.Add(obj2);
                    }
                    else
                    {
                        if (param.Exists(y => y.SequenceEqual(obj1)))
                        {
                            if (param.Exists(y => y.SequenceEqual(obj2)))
                                continue;
                            else
                                param.Add(obj2);
                        }
                        else
                        {
                            param.Add(obj1);
                            param.Add(obj2);
                        }
                    }
                }


                for (int i = 0; i < param.Count; i++)
                {
                    if (param[i].Length == 1)
                        param[i] = new object[] { param[i][0], 0, true };
                    else
                        param[i] = new object[] { param[i][0], param[i][1], false };
                }
                param.Reverse();
                foreach (object[] item in param)
                {
                    if(Counts.Rows.Count > 1)
                    {
                        if (Convert.ToBoolean(item[2]) == false)
                        {
                            Counts.Rows.Insert(0, json.Counter(Convert.ToInt32(item[0]), Convert.ToInt32(item[1]), Convert.ToBoolean(item[2]), Convert.ToInt32(Counts[3, 0].Value.ToString()[(Counts[3, 0].Value.ToString().IndexOf(':') + 1)..])));
                            Counts[3, 1].Value = Counts[3, 1].Value.ToString()[..Counts[3, 1].Value.ToString().IndexOf(':')];
                        }
                    }
                    else
                        Counts.Rows.Insert(0, json.Counter(Convert.ToInt32(item[0]), Convert.ToInt32(item[1]), Convert.ToBoolean(item[2]), 0));
                }
            }
        }

        //

        // запись в реестр
        private void Registry_Write(string key, object o, RegistryValueKind valueKind, RegistryKey subKey)
        {
            subKey.SetValue(key, o, valueKind);
            subKey.Close();
        }

        // чтение из реестра
        private object Registry_Read(string key, RegistryKey subKey)
        {
            try
            {
                object o = subKey.GetValue(key);
                subKey.Close();
                return o;
            }
            catch
            {
                return new();
            }
        }

        //событие при открытии вкладки Калькулятора
        private void Calc_Enter(object sender, EventArgs e)
        {
            try
            {
                Calc_Hour_1.Value = Convert.ToInt32(Registry_Read("Hour_1", Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time")));
                Calc_Hour_2.Value = Convert.ToInt32(Registry_Read("Hour_2", Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time")));
                Calc_Minutes_1.Value = Convert.ToInt32(Registry_Read("Minutes_1", Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time")));
                Calc_Minutes_2.Value = Convert.ToInt32(Registry_Read("Minutes_2", Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time")));
                timer = Convert.ToBoolean(Registry_Read("timer", Registry.CurrentUser.CreateSubKey("Serep")));

                Invoke(new delegat(timer_label_set_value), null);

                if (timer)
                    timer_button.Text = "Остановить";
                else
                    timer_button.Text = "Запустить";

                System.Timers.Timer aTimer = new System.Timers.Timer(1000);
                aTimer.Elapsed += new ElapsedEventHandler(Timer);
                aTimer.Enabled = true;
            }
            catch
            {
            }
        }

        //таймер
        private void Timer(object source, ElapsedEventArgs e)
        {
            try
            {
                if (timer)
                    Invoke(new delegat(timer_label_set_value), null);
            }
            catch
            {
            }
        }

        //установка значения текста таймера
        private void timer_label_set_value()
        {
            timer_label.Text = (DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(Calc_Hour_1.Value), Convert.ToInt32(Calc_Minutes_1.Value), 0)).Hours.ToString() + ':' + (DateTime.Now - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, Convert.ToInt32(Calc_Hour_1.Value), Convert.ToInt32(Calc_Minutes_1.Value), 0)).Minutes.ToString();
        }

        //событие при изменении стартового значения часов
        private void Calc_Hour_1_ValueChanged(object sender, EventArgs e)
        {
            if (Calc_Hour_1.Value > 23)
                Calc_Hour_1.Value = 0;

            Registry_Write("hour_1", Calc_Hour_1.Value, RegistryValueKind.DWord, Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time"));
        }

        //событие при изменении стартового значения минут
        private void Calc_Minutes_1_ValueChanged(object sender, EventArgs e)
        {
            if (Calc_Minutes_1.Value > 59)
            {
                Calc_Minutes_1.Value = 0;
                Calc_Hour_1.Value++;
            }

            Registry_Write("Minutes_1", Calc_Minutes_1.Value, RegistryValueKind.DWord, Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time"));
        }

        //событие при изменении конечного значения часов
        private void Calc_Hour_2_ValueChanged(object sender, EventArgs e)
        {
            if (Calc_Hour_2.Value > 23)
                Calc_Hour_2.Value = 0;

            Registry_Write("hour_2", Calc_Hour_2.Value, RegistryValueKind.DWord, Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time"));
        }

        //событие при изменении конечного значения минут
        private void Calc_Minutes_2_ValueChanged(object sender, EventArgs e)
        {
            if (Calc_Minutes_2.Value > 59)
            {
                Calc_Minutes_2.Value = 0;
                Calc_Hour_2.Value++;
            }

            Registry_Write("Minutes_2", Calc_Minutes_2.Value, RegistryValueKind.DWord, Registry.CurrentUser.CreateSubKey("Serep").CreateSubKey("Time"));
        }

        //событие при нажатии кнопки подсчета и переноса
        private void Calc_button_time_Click(object sender, EventArgs e)
        {
            if(timer)
                timer_button_Click(Add, null);

            TimeSpan dateTime = new();
            if (Calc_Hour_2.Value > Calc_Hour_1.Value)
               dateTime = new DateTime(0001, 1, 1, (int)Calc_Hour_2.Value, (int)Calc_Minutes_2.Value, 0) - new DateTime(0001, 1, 1, (int)Calc_Hour_1.Value, (int)Calc_Minutes_1.Value, 0);
            else
                dateTime = new DateTime(0001, 1, 2, (int)Calc_Hour_2.Value, (int)Calc_Minutes_2.Value, 0) - new DateTime(0001, 1, 1, (int)Calc_Hour_1.Value, (int)Calc_Minutes_1.Value, 0);

            Hour.Value = dateTime.Hours;
            Minute.Value = dateTime.Minutes;

            Calc_Hour_1.Value = 0;
            Calc_Hour_2.Value = 0;
            Calc_Minutes_1.Value = 0;
            Calc_Minutes_2.Value = 0;
        }

        //собитие при запуске/остановке таймера
        private void timer_button_Click(object sender, EventArgs e)
        {
            timer = !timer;

            if (timer)
            {
                Calc_Hour_1.Value = 0;
                Calc_Hour_2.Value = 0;
                Calc_Minutes_1.Value = 0;
                Calc_Minutes_2.Value = 0;
                timer_label.Text = "0:0";
                timer_button.Text = "Остановить";
                DateTime dateTime = DateTime.Now;
                if (DateTime.Now.Second > 30)
                    dateTime = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute + 1, 0);

                    Calc_Hour_1.Value = dateTime.Hour;
                    Calc_Minutes_1.Value = dateTime.Minute;
            }
            else
            {
                timer_button.Text = "Запустить";
                DateTime dateTime = DateTime.Now;
                if (DateTime.Now.Second > 30)
                    dateTime = new(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute + 1, 0);

                Calc_Hour_2.Value = dateTime.Hour;
                Calc_Minutes_2.Value = dateTime.Minute;

            }
                Registry_Write("timer", timer, RegistryValueKind.DWord, Registry.CurrentUser.CreateSubKey("Serep"));
        }
    }
}
