using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Serep
{
    public partial class Form1 : Form
    {
        ReadedReport json;
        Lines pick;

        public Form1()
        {
            InitializeComponent();

            Browser.BeforeSelect += Browser_BeforeSelect;
            Browser.AfterSelect += Browser_AfterSelect;
            Browser.BeforeExpand += Browser_BeforeExpand;
            Browser.BeforeCollapse += Browser_BeforeCollapse;
            // заполняем дерево дисками
            FillDriveNodes();
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
                Path.Text = e.Node.FullPath;
            }

            //try
            //{
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
                    }
                }
            //}
            //catch
            //{
            //    MessageBox.Show("!!!Файл поврежден или не предназначен для чтения данной программой.");
            //}
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
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                File.Create(Path.Text).Close();
                json = new();
                File_Open();
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
            }
            catch
            {
                MessageBox.Show("!!!Файл поврежден или не предназначен для чтения данной программой.");
            }
        }

        // событие после открытия файла
        private void File_Open()
        {
            Tabel.Size = new(Tabel.Size.Width, 20);
            Tabel.RowCount = 1;
            pick = new("pick");
            pick.add.Click += Add_Click1;
        }

        private void Add_Click1(object sender, EventArgs e)
        {
            if (json.Items == null)
                json.Items = new List<Report>();
            json.Items.Add(new Report(pick.date.Value, Convert.ToInt32(pick.numericUpDown1.Value), Convert.ToInt32(pick.numericUpDown2.Value), pick.time.Value.Date.Hour, pick.time.Value.Date.Minute, Convert.ToInt32(pick.numericUpDown3.Value), Convert.ToInt32(pick.numericUpDown4.Value)));
            StreamWriter file = new(Path.Text);
            file.Write(JsonConvert.SerializeObject(json));
            file.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Path_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                Add_Click1(pick.add, null);
            }
        }
    }
}
