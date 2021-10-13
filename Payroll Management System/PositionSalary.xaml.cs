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
    /// Interaction logic for PositionSalary.xaml
    /// </summary>
    public partial class PositionSalary : Window
    {
        private static string path = "server=localhost;uid=root;pwd=root;database=payroll";
        MySqlConnection con = new MySqlConnection(path);
        public PositionSalary()
        {
            InitializeComponent();
        }


        private void win_loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select staff_type as Staff, salary as Salary, hourly_charge as HourlyCharge from staff", con);
                DataSet ds = new DataSet();
                adp.Fill(ds, "staff");
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

        private void save_click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtPosition.Text) && !String.IsNullOrEmpty(txtSalary.Text))
            {
                try
                {
                    decimal hourlycharge = Convert.ToDecimal(txtSalary.Text)/(decimal)173.33;
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into staff(staff_type,salary,hourly_charge) values('" + txtPosition.Text + "'," + Convert.ToDecimal(txtSalary.Text) + "," + hourlycharge + ")", con);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0) MessageBox.Show("Successful");

                    MySqlDataAdapter adp = new MySqlDataAdapter("select staff_type as Staff, salary as Salary, hourly_charge as HourlyCharge from staff", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "staff");
                    dataGrid.DataContext = ds.Tables[0].DefaultView;
                }
                catch(NullReferenceException ex)
                {
                    MySqlDataAdapter adp = new MySqlDataAdapter("select staff_type as Staff, salary as Salary, hourly_charge as HourlyCharge from staff", con);
                    DataSet dt = new DataSet();
                    adp.Fill(dt, "staff");
                    dataGrid.DataContext = dt.Tables[0].DefaultView;

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
            else
            {
                MessageBox.Show("Please enter position and salary");
            }
        }

        private void updatet_click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPosition.Text) && !String.IsNullOrEmpty(txtSalary.Text))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure?", "Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        decimal hourlycharge = Convert.ToDecimal(txtSalary.Text) / (decimal)173.33;
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("update staff set salary = " + Convert.ToDecimal(txtSalary.Text)+", hourly_charge = "+hourlycharge+" where staff_type = '"+txtPosition.Text+"'", con);
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0) MessageBox.Show("Successful");
                        else MessageBox.Show("Please position correctly");

                        MySqlDataAdapter adp = new MySqlDataAdapter("select staff_type as Staff, salary as Salary, hourly_charge as HourlyCharge from staff", con);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "staff");
                        dataGrid.DataContext = ds.Tables[0].DefaultView;
                    }
                    catch (NullReferenceException ex)
                    {
                        MySqlDataAdapter adp = new MySqlDataAdapter("select staff_type as Staff, salary as Salary, hourly_charge as HourlyCharge from staff", con);
                        DataSet dt = new DataSet();
                        adp.Fill(dt, "staff");
                        dataGrid.DataContext = dt.Tables[0].DefaultView;

                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Please enter position correctly");
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please selete position and salary");
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPosition.Text) && !String.IsNullOrEmpty(txtSalary.Text))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure?", "Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    try
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("delete from staff where staff_type = '" + txtPosition.Text + "'", con);
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0) MessageBox.Show("Successful");
                        else MessageBox.Show("Please enter position correctly");

                        MySqlDataAdapter adp = new MySqlDataAdapter("select staff_type as Staff, salary as Salary, hourly_charge as HourlyCharge from staff", con);
                        DataSet dt = new DataSet();
                        adp.Fill(dt, "staff");
                        dataGrid.DataContext = dt.Tables[0].DefaultView;
                    }
                    catch (NullReferenceException ex)
                    {
                        MySqlDataAdapter adp = new MySqlDataAdapter("select staff_type as Staff, salary as Salary, hourly_charge as HourlyCharge from staff", con);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "staff");
                        dataGrid.DataContext = ds.Tables[0].DefaultView;

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
            else
            {
                MessageBox.Show("Please selete to delete");
            }
        }

        private void grid_selection(object sender, SelectionChangedEventArgs e)
        {
            txtSalary.Text = ((DataRowView)((PositionSalary)this).dataGrid.SelectedItem).Row[1].ToString();
            txtPosition.Text = ((DataRowView)((PositionSalary)this).dataGrid.SelectedItem).Row[0].ToString();
        }
    }
}
