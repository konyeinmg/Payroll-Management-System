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
    /// Interaction logic for Department.xaml
    /// </summary>
    public partial class Department : Window
    {
        public Department()
        {
            InitializeComponent();
        }

        private void win_loaded(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            try
            {
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code as Dept_Code, dept_name as Dept_Name from dept", con);
                DataSet ds = new DataSet();
                adp.Fill(ds, "dept");
                dataGrid.DataContext = ds.Tables[0].DefaultView;

            }catch(Exception ex)
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
            if (!String.IsNullOrEmpty(txtCode.Text) && !String.IsNullOrEmpty(txtName.Text))
            {
                string path = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con = new MySqlConnection(path);
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("insert into dept values(" + Convert.ToInt16(txtCode.Text) + ",'" + txtName.Text + "')", con);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0) MessageBox.Show("Successful");

                    MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code as Dept_Code, dept_name as Dept_Name from dept", con);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "dept");
                    dataGrid.DataContext = ds.Tables[0].DefaultView;
                }
                catch(NullReferenceException ex)
                {
                    MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code as Dept_Code, dept_name as Dept_Name from dept", con);
                    DataSet dt = new DataSet();
                    adp.Fill(dt, "dept");
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
                MessageBox.Show("please enter new dept name and dept code");
            }
        }

        private void update_click(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);

            if (!String.IsNullOrEmpty(txtCode.Text) && !String.IsNullOrEmpty(txtName.Text))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure?", "Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
              
                    if (result == MessageBoxResult.Yes)
                    {
                    try
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("update dept set dept_name = '" + txtName.Text + "' where dept_code = " + Convert.ToInt16(txtCode.Text), con);
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0) MessageBox.Show("Successful");

                        MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code as Dept_Code, dept_name as Dept_Name from dept", con);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "dept");
                        dataGrid.DataContext = ds.Tables[0].DefaultView;
                    }
                    catch (NullReferenceException ex)
                    {
                        MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code as Dept_Code, dept_name as Dept_Name from dept", con);
                        DataSet dt = new DataSet();
                        adp.Fill(dt, "dept");
                        dataGrid.DataContext = dt.Tables[0].DefaultView;
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
                MessageBox.Show("Please enter dept name and dept code");
            }
        }

        private void delete_click(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);

            if (!String.IsNullOrEmpty(txtCode.Text) && !String.IsNullOrEmpty(txtName.Text))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure?", "Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("delete from dept where dept_name = '" + txtName.Text + "' or dept_code = " + Convert.ToInt16(txtCode.Text), con);
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0) MessageBox.Show("Successful");

                        MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code as Dept_Code, dept_name as Dept_Name from dept", con);
                        DataSet ds = new DataSet();
                        adp.Fill(ds, "dept");
                        dataGrid.DataContext = ds.Tables[0].DefaultView;

                        txtCode.Text = null;
                        txtName.Text = null;
                    }
                    catch (NullReferenceException ex)
                    {
                        MySqlDataAdapter adp = new MySqlDataAdapter("select dept_code as Dept_Code, dept_name as Dept_Name from dept", con);
                        DataSet dt = new DataSet();
                        adp.Fill(dt, "dept");
                        dataGrid.DataContext = dt.Tables[0].DefaultView;

                        txtCode.Text = null;
                        txtName.Text = null;
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
                MessageBox.Show("Please row to delete");
            }

        }

        private void grid_selection(object sender, SelectionChangedEventArgs e)
        {
            txtName.Text = ((DataRowView)((Department)this).dataGrid.SelectedItem).Row[1].ToString();
            txtCode.Text = ((DataRowView)((Department)this).dataGrid.SelectedItem).Row[0].ToString();
        }
    }
}
