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
    /// Interaction logic for PaySlip.xaml
    /// </summary>
    public partial class PaySlip : Window
    {
        public PaySlip()
        {
            InitializeComponent();
        }

        private void payslip_click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrEmpty(txtname.Text) && !String.IsNullOrEmpty(txtmonth.Text))
            {
                string name = txtname.Text;
                int id = Convert.ToInt16(txtid.Text);
                string month = txtmonth.Text;

                frame2.Content = new PaySalary(name, id, month);
            }
            else
            {
                MessageBox.Show("Please enter name and ID");
            }
            
        }

        private void win_loaded(object sender, RoutedEventArgs e)
        {
            frame2.Content = new paytest();
        }

        private void name_changed(object sender, TextChangedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            if (txtname.Text != null)
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select employee_id from employee where name = '" + txtname.Text + "'", con);
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
