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
    /// Interaction logic for Allowance.xaml
    /// </summary>
    public partial class Allowance : Page
    {
        private string type;
        private string beginMonth;
        private string endMonth;
        public Allowance()
        {
            InitializeComponent();
        }

        private void pay_click(object sender, RoutedEventArgs e)
        {
            string[] testingnull = { txtName.Text, txtAmount.Text, txtBegin.Text, txtEnd.Text };
            if (MainWindow.testnull(testingnull))
            {
                string name = txtName.Text;
                string id = txtID.Text;
                decimal amount = Convert.ToDecimal(txtAmount.Text);
                int beginMonthIndex = txtBegin.SelectedIndex + 1;
                int endMonthIndex = txtEnd.SelectedIndex + 1;
                int length = (beginMonthIndex == endMonthIndex) ? 1 : (endMonthIndex - beginMonthIndex + 1);

                string cmmd = string.Format("insert into allowance(name,allowance_type,begin_month,end_month,allowance_length,allowance_amount,employee_id) values('{0}','{1}','{2}','{3}',{4},{5},{6})", name, txtType.Text, txtBegin.Text, txtEnd.Text, length, amount, Convert.ToInt16(id));
                string path = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con = new MySqlConnection(path);
                try
                {
                    //string name = textBoxName.Text;

                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(cmmd, con);
                    int row = cmd.ExecuteNonQuery();
                    if (row > 0) MessageBox.Show("Successful", "Success", MessageBoxButton.OK);
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
            else
            {
                MessageBox.Show("Please Enter Completely");
            }
            
        }

        private void type_selectionchanged(object sender, SelectionChangedEventArgs e)
        {
            type = ((ComboBoxItem)txtType.SelectedItem).Content.ToString();
        }

        private void begin_changed(object sender, SelectionChangedEventArgs e)
        {
            beginMonth = ((ComboBoxItem)txtBegin.SelectedItem).Content.ToString();
        }

        private void end_changed(object sender, SelectionChangedEventArgs e)
        {
            endMonth = ((ComboBoxItem)txtEnd.SelectedItem).Content.ToString();
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
            txtAmount.Clear();
            txtBegin.SelectedIndex = -1;
            txtEnd.SelectedIndex = -1;
            txtType.SelectedIndex = -1;
        }
    }
}
