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
    /// Interaction logic for OvertimeUpdate.xaml
    /// </summary>
    public partial class OvertimeUpdate : Page
    {
        string name, date;
        int id, overtime;

        private void page_loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = name;
            txtID.Text = id.ToString();
            txtHour.Text = overtime.ToString();
            txtPicker.SelectedDate = DateTime.Parse(date);
        }

        private void submit_changed(object sender, RoutedEventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("update dailyovertime set overtime_date='"+date+"',employee_id="+id+",name='"+name+"',overtime="+overtime+" where employee_id="+id, con);
                int row = cmd.ExecuteNonQuery();
                if (row > 0) MessageBox.Show("Successful","Success",MessageBoxButton.OK);
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

        public OvertimeUpdate()
        {
            InitializeComponent();
        }
        public OvertimeUpdate(string name, int id,int overtime, string date)
        {
            InitializeComponent();
            this.name = name;
            this.id = id;
            this.overtime = overtime;
            this.date = date;
        }
    }
}
