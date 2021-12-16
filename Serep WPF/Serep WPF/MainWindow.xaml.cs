using Microsoft.Win32;
using Newtonsoft.Json;
using Serep_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Serep_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReadedReport json;

        public MainWindow()
        {
            InitializeComponent();

            //AddTabCallendar();
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("Explorer.exe", @"C:\");
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.ShowDialog();
            try
            {
                File_Open(openFileDialog.FileName);
            }
            catch
            {
            }
        }

        private void File_Open(string path)
        {
            StreamReader file = new(path);
            json = JsonConvert.DeserializeObject<ReadedReport>(file.ReadToEnd());
            file.Close();
        }

        private void AddTabCallendar()
        {
            Grid grid = new();
            new Calendar(grid, 1, 0);
            tabcontrol.Items.Add(new Tab("Календарь", grid).tabItem);
        }
    }
}
