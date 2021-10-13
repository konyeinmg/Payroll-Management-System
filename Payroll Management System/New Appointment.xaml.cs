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
using MySql.Data.MySqlClient;
using System.Data;

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for New_Appointment.xaml
    /// </summary>
    public partial class New_Appointment : Window
    {
        string[] dept = { "Sale", "Finance", "Vehicle", "Manage", "Store" };
        string[] dept_name;
        public New_Appointment()
        {
            InitializeComponent();
            
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            string[] testingnull = { txtName.Text, txtID.Text, txtPosition.Text, comboDept.Text };
            if (MainWindow.testnull(testingnull))
            {
                string name = txtName.Text;
                int id = Convert.ToInt16(txtID.Text);
                string date = pickerDate.Text;
                string position = txtPosition.Text;
                decimal basic_salary = Convert.ToDecimal(txtSalary.Text);
                decimal hourly_charge = Convert.ToDecimal(txtCharge.Text);
                int working_hr = Convert.ToInt16(txtHour.Text);
                decimal tax = Convert.ToDecimal(txtTax.Text);
                int index = comboDept.SelectedIndex;
                int dept_code = 0;
                switch (index)
                {
                    case 0: dept_code = 1101; break;
                    case 1: dept_code = 1102; break;
                    case 2: dept_code = 1103; break;
                    case 3: dept_code = 1104; break;
                    case 4: dept_code = 1105; break;
                    default: break;
                }



                string paths = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con = new MySqlConnection(paths);
                MySqlConnection con1 = new MySqlConnection(paths);
                MySqlConnection con2 = new MySqlConnection(paths);
                string command = string.Format("insert into employee values({0},'{1}','{2}',{3},'{4}',{5},{6},{7},{8})", id, name, position, dept_code, date, working_hr, basic_salary, tax, hourly_charge);

                try
                {
                    con.Open();
                    con1.Open();
                    con2.Open();
                    MySqlCommand cmd = new MySqlCommand(command, con);
                    int row = cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand("update curriculum_vitae set employee_id = " + id + " where name = '" + name + "'", con1);
                    int r = cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand("insert into attendance(employee_id,name) values(" + id + ",'" + name + "')", con2);
                    int t = cmd.ExecuteNonQuery();
                    if (row > 0 && r > 0 && t > 0) MessageBox.Show("Ok");
                }
                catch (Exception ex)
                {
                    con.Close();
                    con1.Close();
                    con2.Close();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    con1.Close();
                    con2.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Completely");
            }
        }

        private void appoint_click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtPosition.SelectedIndex = -1;
            pickerDate.SelectedDate = DateTime.Now.Date;
            txtSalary.Clear();
            txtID.Clear();
            // comboDept.Items.Clear();
            //comboDept.ItemsSource = dept;
            comboDept.SelectedIndex = -1;
            txtCharge.Clear();
        }

        private void win_loaded(object sender, RoutedEventArgs e)
        {
            pickerDate.SelectedDate = DateTime.Now.Date;
            txtHour.Text = 8.ToString();
            string paths = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(paths);
            MySqlConnection con1 = new MySqlConnection(paths);
            MySqlConnection con2 = new MySqlConnection(paths);
            try
            {
                con.Open();
                con1.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code,dept_name from dept", con1);
                DataSet ds = new DataSet();
                adp.Fill(ds, "dept");

                adp = new MySqlDataAdapter("select staff_type from staff", con1);
                DataSet dt = new DataSet();
                adp.Fill(dt, "dept");

                txtPosition.ItemsSource = dt.Tables[0].DefaultView;
                txtPosition.DisplayMemberPath = dt.Tables[0].Columns[0].ToString();
                txtPosition.SelectedValuePath = dt.Tables[0].Columns[0].ToString();

                comboDept.ItemsSource = ds.Tables[0].DefaultView;
                comboDept.DisplayMemberPath = ds.Tables[0].Columns[1].ToString();
                comboDept.SelectedValuePath = ds.Tables[0].Columns[0].ToString();

                MySqlCommand cmd = new MySqlCommand("select distinct(tax) from employee", con);
                MySqlDataReader taxRead = cmd.ExecuteReader();
                while (taxRead.Read())
                {
                    txtTax.Text = taxRead[0].ToString();
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

        private void posi_changed(object sender, TextChangedEventArgs e)
        {

            string paths = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(paths);
            
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select salary,hourly_charge from staff where staff_type = '" + txtPosition.Text + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtSalary.Text = reader[0].ToString();
                    txtCharge.Text = reader[1].ToString();
                    
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

        private void position_changed(object sender, SelectionChangedEventArgs e)
        {
            string paths = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(paths);

            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select salary,hourly_charge from staff where staff_type = '" + txtPosition.SelectedValue + "'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtSalary.Text = reader[0].ToString();
                    txtCharge.Text = reader[1].ToString();

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
        
    }

}
