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
    class Tab
    {
        public TabItem tabItem;

        public Tab(string header, object obj)
        {
            Grid headerGrid = new();
            headerGrid.ColumnDefinitions.Add(new() { Width = new(1, GridUnitType.Star) });
            headerGrid.ColumnDefinitions.Add(new() { Width = new(1, GridUnitType.Auto) });

            Label name = new();
            name.Content = header;
            Grid.SetColumn(name, 0);
            headerGrid.Children.Add(name);

            Path path = new();
            path.Data = Geometry.Parse("M0,0 L8,8 M8,0 L0,8");
            path.StrokeThickness = 3;

            //ControlTemplate controlTemplate = new() { Template =  };

            //Button button = new() { Template = controlTemplate };

            //Grid.SetColumn(button, 1);
            //headerGrid.Children.Add(button);


            tabItem = new() { Header = headerGrid, Content = obj };
        }
    }
}
