using System;
using System.Collections.Generic;
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

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for Daily_Process.xaml
    /// </summary>
    public partial class Daily_Process : Page
    {
        public Daily_Process()
        {
            InitializeComponent();
        }

        private void overtime_click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Overtime();
            MainWindow.global = 3;
        }

        private void leavelist_click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Leavelist();
            MainWindow.global = 4;
        }

        private void atten_click(object sender, RoutedEventArgs e)
        {
            Attendance att = new Attendance();
            att.Show();
        }

        private void new_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
