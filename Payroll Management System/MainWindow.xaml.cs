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
using System.Data;
using MySql.Data.MySqlClient;

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int global=0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.Content = new Pay_Master();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.Content = new View();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.Content = new Daily_Process();

        }
        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            switch (global)
            {
                case 1: frame1.Content = new Allowance(); break;
                case 2: frame1.Content = new Deduction(); break;
                case 3: frame1.Content = new Pay_Change(); break;
                default: break;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.Content = new Home();
        }



        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(((DataRowView)dataGrid.SelectedItem).Row[0].ToString()+ ((DataRowView)dataGrid.SelectedItem).Row[1].ToString()+ ((DataRowView)dataGrid.SelectedItem).Row[2].ToString());
            

        }

        private void window_loaded(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            try
            {
                con.Open();
                //MySqlCommand cmd = new MySqlCommand("select employee.employee_id as ID, employee.name as Name, position as Position, dept_name as Dept from employee,dept where employee.dept_code = dept.dept_code", con);
                MySqlDataAdapter adp = new MySqlDataAdapter("select employee.employee_id as ID, employee.name as Name, position as Position, dept_name as Dept,basic_salary as Salary,start_date as Start_Date from employee,dept where employee.dept_code = dept.dept_code", con);
                DataSet ds = new DataSet();
                adp.Fill(ds, "employee");
                dataGrid.DataContext = ds.Tables[0].DefaultView;
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void autho_click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame.Content = new Authorise();
        }
        public static Boolean testnull(string[] text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (String.IsNullOrWhiteSpace(text[i]))
                    return false;
            }
            return true;
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Search();
            MainWindow.global = 0;
        }
    }
}
