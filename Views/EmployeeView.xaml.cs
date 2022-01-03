using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UIApp.ViewModels;
using UIApp.Models;


namespace UIApp.Views
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        public EmployeeViewModel employeeVM;
        public EmployeeView()
        {
            InitializeComponent();

            employeeVM = new EmployeeViewModel();
            dEmployees.ItemsSource = employeeVM.EmployeesList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("dfghjkl");
            foreach (var item in dEmployees.SelectedItems)
            {
                Employee i = (Employee)item;
                i.Name = "Toto";
                System.Diagnostics.Debug.WriteLine(i.Name);
                dEmployees.Foreground = System.Windows.Media.Brushes.Green;
                /*dEmployees.ItemContainerGenerator.ContainerFromItem(item).Dispatcher.
                System.Diagnostics.Debug.WriteLine();*/
            }

            /*ListViewItem it = (ListViewItem)dEmployees.Items[dEmployees.SelectedIndex];
            it.Background = new BrushConverter().ConvertFromString("#FFFFFF") as SolidColorBrush;*/

            /*foreach (ListViewItem item in dEmployees.Items)
            {
                if (item.IsSelected)
                {
                    item.Background = new BrushConverter().ConvertFromString("#FFFFFF") as SolidColorBrush;
                    // System.Windows.Media.Brushes.Green;

                }
            }*/

            /*foreach (var item in dEmployees.Items)
            {
                item.Column[0].IsChecked;
            }*/

        }

        private void dEmployees_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            /*ListView lv = (ListView)sender;
            EmployeeView currentEV = (EmployeeView)lv.SelectedItem;
            currentEV.Name = "Toto";*/
        }
    }
}
