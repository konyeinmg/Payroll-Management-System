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
    /// Interaction logic for Authorise.xaml
    /// </summary>
    public partial class Authorise : Page
    {
        public Authorise()
        {
            InitializeComponent();
        }

        private void tax_click(object sender, RoutedEventArgs e)
        {
            Tax tax = new Tax();
            tax.Show();
        }

        private void positionsalary_click(object sender, RoutedEventArgs e)
        {
            PositionSalary ps = new PositionSalary();
            ps.Show();
        }

        private void dept_click(object sender, RoutedEventArgs e)
        {
            Department dept = new Department();
            dept.Show();
        }
    }
}
