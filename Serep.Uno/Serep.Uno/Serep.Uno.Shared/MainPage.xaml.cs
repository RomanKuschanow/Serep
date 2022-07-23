using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Toolkit.Collections;
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
using System.Text.RegularExpressions;
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
        public ObservableGroupedCollection<DateTime, Reports> groupedSource { get; set; }

        DispatcherTimer dispatcherTimer;
        TimeSpan timer;

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(800, 500);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            Sourse = new();
            Load();
            DispatcherTimerSetup();
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

            Sort();
        }


        private void Sort()
        {
            Sourse = new ObservableCollection<Reports>(from item in Sourse orderby item.Date descending select item);

            var grouped = Sourse.GroupBy(item => new DateTime(item.Date.Year, item.Date.Month, 1)).OrderBy(g => g.Key);
            groupedSource = new ObservableGroupedCollection<DateTime, Reports>(grouped);
            groupedSource = new ObservableGroupedCollection<DateTime, Reports>(from item in groupedSource orderby item.Key descending select item);
            var cvs = new CollectionViewSource
            {
                IsSourceGrouped = true,
                Source = groupedSource,
            };

            dataGrid.ItemsSource = cvs.View;
        }
        private void LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
        {
            ICollectionViewGroup group = e.RowGroupHeader.CollectionViewGroup;
            Reports item = group.GroupItems[0] as Reports;
            e.RowGroupHeader.PropertyValue = $"{item.Date.Year}.{item.Date.Month} total count: {Count(item.Date.Year, item.Date.Month)}";
        }
        private string Count(int year, int month)
        {
            int pub_count = 0;
            int vid_count = 0;
            TimeSpan time_count = new();
            int pp_count = 0;
            int std_count = 0;

            foreach (var rep in Sourse)
            {
                if (rep.Date.Year == year && rep.Date.Month == month)
                {
                    pub_count += rep.Publications;
                    vid_count += rep.Videos;
                    time_count += rep.Time;
                    pp_count += rep.Pp;
                    std_count += rep.Studys;
                }
            }

            TimeSpan prev = new();

            foreach (var rep in Sourse)
            {
                if (Convert.ToInt32($"{year}{month}") > Convert.ToInt32($"{rep.Date.Year}{rep.Date.Month}"))
                {
                    prev += rep.Time;
                }
            }

            time_count = time_count.Add(new TimeSpan(0, prev.Minutes, 0));

            return $"publications — {pub_count} videos — {vid_count} time — {time_count.ToString(@"hh\:mm")} pp — {pp_count} studys — {std_count}";
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
            report.PropertyChanged += Report_PropertyChanged;
            Sort();
        }

        private void Report_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            using var db = new DBContext();
            var d = sender as Reports;

            db.reports.Update(d);
            db.SaveChanges();
            Sort();
            if (e.PropertyName == "Date")
            {
                dataGrid.SelectedItem = d;
            }
        }


        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
        }
        void dispatcherTimer_Tick(object sender, object e)
        {
            timer += new TimeSpan(0, 0, 1);
            hours.Text = timer.ToString(@"hh");
            minutes.Text = timer.ToString(@"mm");
            seconds.Text = timer.ToString(@"ss");
        }

        private void TimerStart(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
            timer = new();
            hours.Text = "00";
            minutes.Text = "00";
            seconds.Text = "00";
            start.Visibility = Visibility.Collapsed;
            stop.Visibility = Visibility.Visible;
            pause.Visibility = Visibility.Visible;
            _continue.Visibility = Visibility.Collapsed;
            addToReport.Visibility = Visibility.Collapsed;
        }
        private void TimerStop(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            start.Visibility = Visibility.Visible;
            stop.Visibility = Visibility.Collapsed;
            pause.Visibility = Visibility.Collapsed;
            _continue.Visibility = Visibility.Collapsed;
            addToReport.Visibility = Visibility.Visible;
        }
        private void TimerPause(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            start.Visibility = Visibility.Collapsed;
            stop.Visibility = Visibility.Visible;
            pause.Visibility = Visibility.Collapsed;
            _continue.Visibility = Visibility.Visible;
            addToReport.Visibility = Visibility.Collapsed;
        }
        private void TimerContinue(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Start();
            start.Visibility = Visibility.Collapsed;
            stop.Visibility = Visibility.Visible;
            pause.Visibility = Visibility.Visible;
            _continue.Visibility = Visibility.Collapsed;
            addToReport.Visibility = Visibility.Collapsed;
        }
        private void TimerAdd(object sender, RoutedEventArgs e)
        {
            if (timer.Seconds >= 30) { timer += new TimeSpan(0, 0, 60 - timer.Seconds); }
            else { timer -= new TimeSpan(0, 0, timer.Seconds); }
            time.Time = timer;
            timer = new();
            hours.Text = "00";
            minutes.Text = "00";
            seconds.Text = "00";
            addToReport.Visibility = Visibility.Collapsed;
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
