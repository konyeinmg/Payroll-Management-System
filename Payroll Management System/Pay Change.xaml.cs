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
    /// Interaction logic for Pay_Change.xaml
    /// </summary>
    public partial class Pay_Change : Page
    {
        public Pay_Change()
        {
            InitializeComponent();
        }

        private void id_changed(object sender, TextChangedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select basic_salary from employee where employee_id = " + Convert.ToInt16(txtID.Text) + " and name = '" + txtName.Text + "'", con);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                    txtPrevious.Text = read[0].ToString();
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

        private void submit_click(object sender, RoutedEventArgs e)
        {
            string[] testingnull = { txtName.Text, comboBoxMonth.Text, comboBox.Text, txtNow.Text };
            if (MainWindow.testnull(testingnull))
            {
                string path = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con1 = new MySqlConnection(path);
                MySqlConnection con2 = new MySqlConnection(path);

                string name = txtName.Text;
                int id = Convert.ToInt16(txtID.Text);
                string month = comboBoxMonth.Text;
                string type = comboBox.Text;
                decimal previous = Convert.ToDecimal(txtPrevious.Text);
                decimal now = Convert.ToDecimal(txtNow.Text);
                string command = string.Format("insert into paychange(employee_id,name,change_amount,month,paychange_type,previous_amount) values({0},'{1}',{2},'{3}','{4}',{5})", id, name, now, month, type, previous);

                try
                {
                    con1.Open();
                    con2.Open();
                    MySqlCommand cmd = new MySqlCommand(command, con1);
                    int row = cmd.ExecuteNonQuery();

                    cmd = new MySqlCommand("update employee set basic_salary = " + now + ", hourlycharge = " + now / (decimal)173.33 + " where employee_id = " + id, con2);
                    int r = cmd.ExecuteNonQuery();
                    if (r > 0 && row > 0) MessageBox.Show("Successful", "Success", MessageBoxButton.OK);

                    MySqlDataAdapter adp = new MySqlDataAdapter("select paychange_no as No, employee_id as ID, name as Name, change_amount as Change_Amount, previous_amount as Previous_Amount, month as Month, paychange_type as Type from paychange", con1);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "paychange");
                    ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                }
                catch (Exception ex)
                {
                    con1.Close();
                    con2.Close();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con1.Close();
                    con2.Close();
                }
            }
            else
            {
                MessageBox.Show("Please Enter Completely");
            }

            
        }

        private void name_changed(object sender, TextChangedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
           if (txtName.Text != null) {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select employee_id from employee where name = '" + txtName.Text + "'", con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        txtID.Text = reader[0].ToString();
                } catch (Exception ex)
                {
                    con.Close();
                    MessageBox.Show(ex.Message);

                 }
            finally {
                    con.Close();
                } }
        }

        private void new_click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtID.Clear();
            txtPrevious.Clear();
            txtNow.Clear();
            comboBox.SelectedIndex = -1;
            comboBoxMonth.SelectedIndex = -1;
        }
    }
}
    