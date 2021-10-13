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

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for Tax.xaml
    /// </summary>
    public partial class Tax : Window
    {
        public Tax()
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
                MySqlCommand cmd = new MySqlCommand("select distinct(tax) from employee", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtTax.Text = reader[0].ToString();
                }
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

        private void tax_click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtTaxchange.Text))
            {
                string path = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con = new MySqlConnection(path);
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("update employee set tax = " + Convert.ToDecimal(txtTaxchange.Text),con);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0) MessageBox.Show("Successful");

                    txtTax.Text = txtTaxchange.Text;
                    txtTaxchange.Text = null;
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
            else
            {
                MessageBox.Show("Please enter tax to change");
            }
        }
    }
}
