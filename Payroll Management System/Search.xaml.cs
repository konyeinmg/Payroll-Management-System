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
using MySql.Data.MySqlClient;
using System.Data;

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public static int table;

        private static string path = "server=localhost;uid=root;pwd=root;database=payroll";
        MySqlConnection con = new MySqlConnection(path);

        private string by;
        string search;

        string[] religion = { "Buddha", "Hindu", "Muslin", "Christian" };
        string[] blood = { "O", "A", "B", "AB" };
        string[] Department = { "sale", "finance", "vehicle", "manage", "store" };
        string[] City = { "Yangon", "Mandalay", "Mawlamyine", "Myeik", "Pathein", "Bago", "Pyin Oo Lwin", "Taunggyi", "Magway", "Myitgyi Nar", "Sagaing" };
        string[] degree = { "B.E", "B.C.Sc", "B.A", "B.Sc", "B.Com", "M.E", "Ph.D", "B.Tech", "B.Art", "M.A", "B.Ed" };
        public Search()
        {
            InitializeComponent();
        }

        //private void Combo_SelectionChanged(object sender, MouseEventArgs e)
        //{
        //    int type = comboBoxType.SelectedIndex;
        //    switch (type)
        //    {
        //        case 0: comboBoxBy.ItemsSource = religion; break;
        //        case 1: comboBoxBy.ItemsSource = blood; break;
        //        case 2: comboBoxBy.ItemsSource = weight; break;
        //        case 3: comboBoxBy.ItemsSource = height; break;
        //        case 4: comboBoxBy.ItemsSource = Department; break;
        //        case 6: comboBoxBy.ItemsSource = Month; break;
        //        default: break;
        //    }
        //}

        private void search_click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox.Text))
            {
                string name = textBox.Text;
                int id = Convert.ToInt16(textBox1.Text);
                EmployeeData data = new EmployeeData(name, id);
                data.Show();
            }
            else
            {
                MessageBox.Show("Please Enter employee name and ID");
            }
        }
        public void Allowance()
        {
            try
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select name as Name, allowance_type as Type, begin_month as Begin, end_month as End, allowance_length as Length, allowance_amount as Amount, employee_id as ID from allowance where begin_month = '" + comboBoxBy.SelectedItem.ToString() + "'", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "allowance");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void Deduction()
        {
            try
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select name as Name, deduction_type as Type, begin_month as Begin, end_month as End, deduction_length as Length, deduction_amount as Amount, employee_id as ID from deduction where begin_month = '" + comboBoxBy.SelectedItem.ToString() + "'", con);
                DataSet dt = new DataSet();
                myAdp.Fill(dt, "deduction");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = dt.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void by_changed(object sender, SelectionChangedEventArgs e)
        {
            textBox.Text = null;
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // comboBoxBy.Items.Clear();
            int type = comboBoxType.SelectedIndex;
            //comboBoxBy.Items.Clear();
            switch (type)
            {
                case 0: comboBoxBy.ItemsSource = religion; search = "religion"; break;
                case 1: comboBoxBy.ItemsSource = blood; search = "blood"; break;
                case 2: comboBoxBy.ItemsSource = degree; search = "education"; break;
                case 3: comboBoxBy.ItemsSource = City; search = "place_birth"; break;
                default: break;
            }
        }
        public void Month()
        {
            // by = comboBoxBy.SelectionBoxItem.ToString();
        }

        private void comboBoxType_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void name_changed(object sender, TextChangedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            if (textBox.Text != null)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select employee_id from employee where name = '" + textBox.Text + "'", con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        textBox1.Text = reader[0].ToString();
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void filter_click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(comboBoxType.Text) && !String.IsNullOrWhiteSpace(comboBoxBy.Text))
            {
                try
                {
                    con.Open();
                    if (search == "religion" || search == "blood" || search == "education" || search == "place_birth")
                    {
                        MySqlDataAdapter adp = new MySqlDataAdapter("select employee.employee_id as ID, employee.name as Name, position as Position, dept_name as Dept,basic_salary as Salary,start_date as Start_Date from employee,dept,curriculum_vitae where employee.dept_code = dept.dept_code and curriculum_vitae.employee_id = employee.employee_id and curriculum_vitae." + search + " = '" + comboBoxBy.SelectedItem.ToString() + "'", con);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "employee");
                        ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Filter Completely");
            }
        }
        private void dept()
        {
            try
            {
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code,dept_name from dept", con);
                DataSet ds = new DataSet();
                adp.Fill(ds, "dept");

                comboBoxBy.ItemsSource = ds.Tables[0].DefaultView;
                comboBoxBy.DisplayMemberPath = ds.Tables[0].Columns[1].ToString();
                comboBoxBy.SelectedValuePath = ds.Tables[0].Columns[0].ToString();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}