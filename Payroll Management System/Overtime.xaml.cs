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
    /// Interaction logic for Overtime.xaml
    /// </summary>
    public partial class Overtime : Page
    {
        public Overtime()
        {
            InitializeComponent();
        }

        private void submit_changed(object sender, RoutedEventArgs e)
        {
            string[] testingnull = { txtName.Text, txtHour.Text };
            if (MainWindow.testnull(testingnull))
            {
                string name = txtName.Text;
                string id = txtID.Text;
                string date = txtPicker.Text;
                int overtime = Convert.ToInt16(txtHour.Text);
                string path = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con = new MySqlConnection(path);
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into dailyovertime(overtime_date, employee_id, name, overtime) values ('" + date + "'," + Convert.ToInt16(id) + ",'" + name + "'," + overtime + ")", con);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0) MessageBox.Show("Successful", "Success", MessageBoxButton.OK);
                    MySqlDataAdapter myAdp = new MySqlDataAdapter("select overtime_no as No, overtime_date as Date, employee_id as ID, name as Name, overtime as Hour from dailyovertime", con);
                    DataSet ds = new DataSet();
                    myAdp.Fill(ds, "overtime");
                    ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                    Search.table = 3;
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
                MessageBox.Show("Please Enter Completely");
            }
           
        }

        private void page_loaded(object sender, RoutedEventArgs e)
        {
            txtPicker.SelectedDate = DateTime.Now.Date;
        }

        private void name_changed(object sender, TextChangedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            if (txtName.Text != null)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select employee_id from employee where name = '" + txtName.Text + "'", con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        txtID.Text = reader[0].ToString();
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

        private void new_click(object sender, RoutedEventArgs e)
        {
            txtHour.Clear();
            txtID.Clear();
            txtName.Clear();
        }
    }
}
