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
    /// Interaction logic for PermanentKick.xaml
    /// </summary>
    public partial class PermanentKick : Window
    {
        public PermanentKick()
        {
            InitializeComponent();
        }

        private void kick_click(object sender, RoutedEventArgs e)
        {
            string[] testingnull = { txtName.Text, txtid.Text };
            if (MainWindow.testnull(testingnull))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure", "Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    string name = txtName.Text;
                    int id = Convert.ToInt16(txtid.Text);

                    string path = "server=localhost;uid=root;pwd=root;database=payroll";
                    MySqlConnection con = new MySqlConnection(path);
                    MySqlConnection con1 = new MySqlConnection(path);
                    try
                    {
                        con.Open();
                        con1.Open();
                        MySqlCommand cmd = new MySqlCommand("delete from employee where employee_id = " + id + " and name = '" + name + "'", con);
                        int row = cmd.ExecuteNonQuery();

                        cmd = new MySqlCommand("delete from attendance where employee_id =" + id + " and name = '" + name + "'", con1);
                        int r = cmd.ExecuteNonQuery();
                        if (row > 0 && r > 0) MessageBox.Show("Successful");
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        con1.Close();
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                        con1.Close();
                    }
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
            if (txtName.Text != null)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select employee_id from employee where name = '" + txtName.Text + "'", con);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        txtid.Text = reader[0].ToString();
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
}
