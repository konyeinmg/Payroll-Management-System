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
    /// Interaction logic for TemporaryKick.xaml
    /// </summary>
    public partial class TemporaryKick : Window
    {
        public TemporaryKick()
        {
            InitializeComponent();
        }

        private void kick_click(object sender, RoutedEventArgs e)
        {
            string[] testingnull = { txtName.Text };
            if (MainWindow.testnull(testingnull))
            {
                MessageBoxResult result = MessageBox.Show("Are you sure", "Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if(result == MessageBoxResult.Yes)
                {
                    string name = txtName.Text;
                    string path = "server=localhost;uid=root;pwd=root;database=payroll";
                    MySqlConnection con = new MySqlConnection(path);
                    try
                    {
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("delete from curriculum_vitae where employee_id is null" + " and name = '" + name + "'", con);
                        int row = cmd.ExecuteNonQuery();
                        if (row > 0) MessageBox.Show("Successful");
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
                MessageBox.Show("Please Enter Name");
            }
            
        }
    }
}
