using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace Serep.Uno.Model
{
    public class DBContext : DbContext
    {
        public DbSet<Reports> reports { get; set; }

        public string DbPath { get; }

        public DBContext()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DbPath = Path.Combine(path, "reports.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }

    }

    public class Reports : ViewModelBase
    {
        private DateTimeOffset _Date;
        private int _Publications;
        private int _Videos;
        private TimeSpan _Time;
        private int _Pp;
        private int _Studys;
        private string _Note;

        public int id { get; set; }
        public DateTimeOffset Date { get => _Date; set => SetProperty(ref _Date, value); }
        public int Publications { get => _Publications; set => SetProperty(ref _Publications, value); }
        public int Videos { get => _Videos; set => SetProperty(ref _Videos, value); }
        public TimeSpan Time { get => _Time; set => SetProperty(ref _Time, value); }
        public int Pp { get => _Pp; set => SetProperty(ref _Pp, value); }
        public int Studys { get => _Studys; set => SetProperty(ref _Studys, value); }
        public string Note { get => _Note; set => SetProperty(ref _Note, value); }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public void SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
