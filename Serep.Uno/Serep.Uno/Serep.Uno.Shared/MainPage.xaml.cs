using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Serep.Uno;
using Serep.Uno.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Serep.Uno
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static ObservableCollection<Reports> Sourse { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1200, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Sourse = new();
            Load();
        }

        private void GridLoaded(object sender, RoutedEventArgs e)
        {
            dataGrid.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            if (add != null)
            {
                if (time.Time.TotalMinutes > 0)
                    add.IsEnabled = true;
                else
                    add.IsEnabled = false;
            }

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            using var db = new DBContext();

            Reports report = new Reports
            {
                Date = DateTime.Now,
                Publications = Convert.ToInt32(publications.Text),
                Videos = Convert.ToInt32(videos.Text),
                Time = time.Time,
                Pp = Convert.ToInt32(pp.Text),
                Studys = Convert.ToInt32(studys.Text),
                Note = note.Text
            };

            publications.Text = "0";
            videos.Text = "0";
            time.Time = new();
            pp.Text = "0";
            studys.Text = "0";
            note.Text = "";

            db.Add(report);
            db.SaveChanges();
            Sourse.Add(report);
            Sourse = new ObservableCollection<Reports>(from item in Sourse orderby item.Date descending select item);
            dataGrid.ItemsSource = Sourse;
        }

        public void Load()
        {
            using var db = new DBContext();

            var reports = db.reports.ToList();

            foreach (var report in reports)
            {
                report.PropertyChanged += Report_PropertyChanged;
                Sourse.Add(report);
            }

            Sourse = new ObservableCollection<Reports>(from item in Sourse orderby item.Date descending select item);
            dataGrid.ItemsSource = Sourse;
        }

        private void Report_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            using var db = new DBContext();
            var d = sender as Reports;

            db.reports.Update(d);
            db.SaveChanges();
            Sourse = new ObservableCollection<Reports>(from item in Sourse orderby item.Date descending select item);
            dataGrid.ItemsSource = Sourse;
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand DeleteReport { get => new RelayCommand(CmdExec); }
        private void CmdExec(Object obj)
        {
            using var db = new DBContext();
            var rep = obj as Reports; 

            db.Remove(rep);
            db.SaveChanges();
            MainPage.Sourse.Remove(rep);
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propName = "") =>
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        #endregion
    }

    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        public event EventHandler CanExecuteChanged;
        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute) { _execute = execute; _canExecute = canExecute; }
        public bool CanExecute(object parameter) => (_canExecute == null) ? true : _canExecute(parameter);
        public void Execute(object parameter) => _execute(parameter);
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            DateTime dt = DateTime.Parse(value.ToString());
            return dt.ToString("yyyy.MM.dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class TimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            TimeSpan t = TimeSpan.Parse(value.ToString());
            return t.ToString(@"hh\:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
