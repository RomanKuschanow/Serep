using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Serep_WPF
{
    public class Calendar
    {
        public Calendar(Grid main, int Row, int Colum)
        {
            Grid grid = new();
            for (int i = 0; i < 7; i++)
            {
                grid.ColumnDefinitions.Add(new());
            }
            Grid.SetRow(grid, Row);
            Grid.SetColumn(grid, Colum);
            main.Children.Add(grid);
            Build_Calendar_Grid(DateTime.Now, grid);
        }

        public void Build_Calendar_Grid(DateTime date, Grid grid)
        {
            for (int i = 1; i <= DateTime.DaysInMonth(date.Year, date.Month); i++)
            {
                if(i == 1 || (int) new DateTime(date.Year, date.Month, i).DayOfWeek == 1)
                    grid.RowDefinitions.Add(new());

                DayCell dayCell = new();

                dayCell.label.Content = i;

                Grid.SetRow(dayCell.DayCellGrid, grid.RowDefinitions.Count - 1);
                Grid.SetColumn(dayCell.DayCellGrid, Day_Converter(date, i));
                grid.Children.Add(dayCell.DayCellGrid);
            }
        }

        private int Day_Converter(DateTime date, int i)
        {
            if (new DateTime(date.Year, date.Month, i).DayOfWeek == 0)
                return 6;
            else
                return (int)new DateTime(date.Year, date.Month, i).DayOfWeek - 1;
        }
    }

    public class DayCell
    {
        public Grid DayCellGrid = new();
        private Rectangle rect = new();
        public Label label = new();
        public DayCell()
        {
            DayCellGrid.RowDefinitions.Add(new() { Height = new(0.5f, GridUnitType.Star) });
            DayCellGrid.RowDefinitions.Add(new());
            DayCellGrid.ColumnDefinitions.Add(new() { Width = new(0.3f, GridUnitType.Star) });
            DayCellGrid.ColumnDefinitions.Add(new());

            rect.Fill = new SolidColorBrush(Color.FromArgb(255, 150, 150, 150));
            rect.Stroke = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));
            rect.HorizontalAlignment = HorizontalAlignment.Stretch;
            rect.VerticalAlignment = VerticalAlignment.Stretch;

            Grid.SetRow(rect, 0);
            Grid.SetColumn(rect, 0);
            Grid.SetRowSpan(rect, 2);
            Grid.SetColumnSpan(rect, 2);

            DayCellGrid.Children.Add(rect);

            Viewbox viewbox = new();

            label.FontWeight = FontWeight.FromOpenTypeWeight(999);
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;

            viewbox.Child = label;

            Grid.SetRow(viewbox, 0);
            Grid.SetColumn(viewbox, 0);

            DayCellGrid.Children.Add(viewbox);
        }
    }
}
