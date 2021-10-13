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
    /// Interaction logic for Leavelist.xaml
    /// </summary>
    public partial class Leavelist : Page
    {
        public Leavelist()
        {
            InitializeComponent();
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            string[] testingnull = { txtName.Text, txtType.Text, txtPicker1.Text };
            if (MainWindow.testnull(testingnull))
            {
                string name = txtName.Text;
                string id = txtID.Text;
                string type = txtType.Text;
                string begin = txtPicker.Text;
                string end = txtPicker1.Text;
                string[] beginarr = begin.Split('/');
                string[] endarr = end.Split('/');
                int length = 1 + (Convert.ToInt16(endarr[1]) - Convert.ToInt16(beginarr[1]));


                string todayDate = (DateTime.Now.Date).ToShortDateString();
                string[] today = todayDate.Split('/');

                int index = txtType.SelectedIndex;
                int leave_code = 0;
                switch (index)
                {
                    case 0: leave_code = 2201; break;
                    case 1: leave_code = 2202; break;
                    case 2: leave_code = 2203; break;
                    case 3: leave_code = 2204; break;
                    case 4: leave_code = 2205; break;
                    case 5: leave_code = 2206; break;
                    case 6: leave_code = 2207; break;
                    case 7: leave_code = 2208; break;
                    default: break;
                }
                string path = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con = new MySqlConnection(path);
                
                    try
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("insert into leavelist(employee_id,name,begin_date,end_date,leave_code,length,end) values (" + Convert.ToInt16(id) + ",'" + name + "','" + begin + "','" + end + "'," + leave_code + "," + length + "," + Convert.ToInt16(endarr[1]) + ")", con);
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0) MessageBox.Show("Successful", "Success", MessageBoxButton.OK);
                        MySqlDataAdapter myAdp = new MySqlDataAdapter("select leave_no as No, employee_id as ID, name as Name, begin_date as Begin, end_date as End,length as Length, leave_type as Type from leavelist,leave_ty where leavelist.leave_code = leave_ty.leave_code", con);
                        DataSet ds = new DataSet();
                        myAdp.Fill(ds, "Leave");
                        ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                        Search.table = 4;
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
            txtPicker.DisplayDateStart = DateTime.Now.Date;
            txtPicker.SelectedDate = DateTime.Now.Date;
            txtPicker1.DisplayDateStart = DateTime.Now.Date;
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
            txtName.Clear();
            txtID.Clear();
            txtType.SelectedIndex = -1;
            txtPicker1.SelectedDate = null;
        }
    }
}
