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
    /// Interaction logic for Browse.xaml
    /// </summary>
    public partial class Browse : Window
    {
        public Browse()
        {
            InitializeComponent();
        }

        private void browse_load(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            try
            {
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select employee_id as ID, name as Name from employee", con);
                DataSet ds = new DataSet();
                adp.Fill(ds, "employee");
                dataGridbrowse.DataContext = ds.Tables[0].DefaultView;
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
