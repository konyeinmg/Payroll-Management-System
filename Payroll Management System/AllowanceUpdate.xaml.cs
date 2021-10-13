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
    /// Interaction logic for AllowanceUpdate.xaml
    /// </summary>
    public partial class AllowanceUpdate : Page
    {
        string name, type, begin, end;
        decimal amount;
        int id;
        string[] all_type = { "Special Allowance", "Travelling Allowance","Housing Allowance","Overtime Allowance","Daily Allowance","Research Allowance","Helper Allowance","Uniform Allowance" };
        private void page_loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = name;
            txtType.Items.Clear();
            txtType.ItemsSource = all_type;
            txtType.Text = type;
            txtBegin.Text = begin;
            txtEnd.Text = end;
            txtAmount.Text = amount.ToString();
            txtID.Text = id.ToString();
          
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            int beginMonthIndex = txtBegin.SelectedIndex + 1;
            int endMonthIndex = txtEnd.SelectedIndex + 1;
            int length = (beginMonthIndex == endMonthIndex) ? 1 : (endMonthIndex - beginMonthIndex + 1);
           
           

            try
            {
                //string name = textBoxName.Text;

                con.Open();
                MySqlCommand cmd = new MySqlCommand("update allowance set name='" + txtName.Text + "',employee_id=" + txtID.Text + ",allowance_type='" + txtType.Text + "',begin_month='" + txtBegin.Text +"',end_month='"+txtEnd.Text+"',allowance_amount="+Convert.ToDecimal(txtAmount.Text)+",allowance_length="+length+" where employee_id = "+id, con);
                int row = cmd.ExecuteNonQuery();
                if (row > 0) MessageBox.Show("Successful","Success",MessageBoxButton.OK);
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select allowance_no as No, name, allowance_type as Type, begin_month as Begin, end_month as End, allowance_length as Length, allowance_amount as Amount, employee_id as ID from allowance", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "allowance");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 1;
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

        private void Load()
        {
            
        }
        public AllowanceUpdate()
        {
            InitializeComponent();
            //Load();
        }
        public AllowanceUpdate(string name, string type, string begin, string end, decimal amount, int id)
        {
            InitializeComponent();
            this.name = name;
            this.type = type;
            this.begin = begin;
            this.end = end;
            this.amount = amount;
            this.id = id;
        }
    }
}
