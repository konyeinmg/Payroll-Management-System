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
    /// Interaction logic for PayUpdate.xaml
    /// </summary>
    public partial class PayUpdate : Page
    {
        string months,name,type;
        decimal change_amount, previous_amount;
        int id;
        string[] pay_type = { "increase", "decrease" };
        string[] pay_month = { "Jan", "Feb", "Mar", "April", "May", "June", "July", "August", "Sept", "Oct", "Nov", "Dec" };
        private void page_load(object sender, RoutedEventArgs e)
        {
            txtName.Text = name;
            txtID.Text = id.ToString();
            txtPrevious.Text = previous_amount.ToString();
            txtNow.Text = change_amount.ToString();
            comboBox.Items.Clear();
            comboBox.ItemsSource = pay_type;
            comboBox.Text = type;
            comboBoxMonth.Items.Clear();
            comboBoxMonth.ItemsSource = pay_month;
            comboBoxMonth.Text = months;
        }

        public PayUpdate()
        {
            InitializeComponent();
        }
        public PayUpdate(string name, int id, decimal change_amount, decimal previous_amount, string type, string month)
        {
            InitializeComponent();
            this.name = name;
            this.id = id;
            this.change_amount = change_amount;
            this.previous_amount = previous_amount;
            this.type = type;
            months = month;
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con1 = new MySqlConnection(path);
            MySqlConnection con2 = new MySqlConnection(path);

            string month = comboBoxMonth.Text;
            string type = comboBox.Text;
            decimal previous = Convert.ToDecimal(txtPrevious.Text);
            decimal now = Convert.ToDecimal(txtNow.Text);
            try
            {
                con1.Open();
                con2.Open();
                MySqlCommand cmd = new MySqlCommand("update paychange set month = '" + month + "', change_amount = " + now + ", paychange_type = '" + type + "', previous_amount = " + previous + " where employee_id = " + id, con1);
                int row = cmd.ExecuteNonQuery();
                cmd = new MySqlCommand("update employee set basic_salary = " + now + " where employee_id = " + id, con2);
                int r = cmd.ExecuteNonQuery();
                if (r > 0 && row > 0) MessageBox.Show("Successful","Success",MessageBoxButton.OK);
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select paychange_no as No, employee_id as ID, name as Name, change_amount as Change_Amount, previous_amount as Previous_Amount, paychange_type as Type, month as Month from paychange", con1);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "paychange");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 5;
            }
            catch(Exception ex)
            {
                con1.Close();
                con2.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.Close();
                con2.Close();
            }
        }
    }
    }

