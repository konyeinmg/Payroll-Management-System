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
    /// Interaction logic for Pay_Master.xaml
    /// </summary>
    public partial class Pay_Master : Page
    {
        public Pay_Master()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Allowance();
            MainWindow.global = 1;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Deduction();
            MainWindow.global = 2;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Pay_Change();
            MainWindow.global = 5;
        }

        private void new_click(object sender, RoutedEventArgs e)
        {

        }
    }
}


