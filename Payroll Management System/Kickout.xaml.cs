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
using System.Windows.Shapes;

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for Kickout.xaml
    /// </summary>
    public partial class Kickout : Window
    {
        public Kickout()
        {
            InitializeComponent();
        }

        private void permanent_check(object sender, RoutedEventArgs e)
        {
            PermanentKick per = new PermanentKick();
            per.Show();
            
        }

        private void temporary_check(object sender, RoutedEventArgs e)
        {
            TemporaryKick temp = new TemporaryKick();
            temp.Show();
            
        }
    }
}
