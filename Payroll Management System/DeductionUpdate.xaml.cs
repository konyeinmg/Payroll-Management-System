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
    /// Interaction logic for DeductionUpdate.xaml
    /// </summary>
    public partial class DeductionUpdate : Page
    {
        string name, type, begin, end;
        decimal amount;
        int id;
        string[] dedu_type = { "Late", "Absence","Un Uniform","Break Discipline","Ravage","Miscellaneous","Charitable gift" };

        private void page_load(object sender, RoutedEventArgs e)
        {
            txtName.Text = name;
            txtType.Items.Clear();
            txtType.ItemsSource = dedu_type;
            txtType.Text = type;
            txtBegin.Text = begin;
            txtEnd.Text = end;
            txtAmount.Text = amount.ToString();
            txtID.Text = id.ToString();
        }

        private void update_click(object sender, RoutedEventArgs e)
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
                MySqlCommand cmd = new MySqlCommand("update deduction set name='" + txtName.Text + "',employee_id=" + txtID.Text + ",deduction_type='" + txtType.Text + "',begin_month='" + txtBegin.Text + "',end_month='" + txtEnd.Text + "',deduction_amount=" + Convert.ToDecimal(txtAmount.Text) + ",deduction_length=" + length + " where employee_id = " + id, con);
                int row = cmd.ExecuteNonQuery();
                if (row > 0) MessageBox.Show("Successful", "Success",MessageBoxButton.OK);
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select deduction_no as No, name, deduction_type as Type, begin_month as Begin, end_month as End, deduction_length as Length, deduction_amount as Amount, employee_id as ID from deduction", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "deduction");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 2;
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

    

        public void load()
    {

    }

      
        public DeductionUpdate()
        {
            InitializeComponent();
        }
        public DeductionUpdate(string name, string type, string begin, string end, decimal amount, int id)
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
