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

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for PaySalary.xaml
    /// </summary>
    public partial class PaySalary : Page
    {
        string naming, months;
        int Id;
        public PaySalary()
        {
            InitializeComponent();
        }

        private void page_load(object sender, RoutedEventArgs e)
        {
            string allowance_amount = null, deduction_amount = null, overtimehour = null, tax_amount = null, totalLeave = null, paysalary = null;
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from payroll_month where employee_id = "+Id+" and pay_month = '"+months+"'", con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    allowance_amount = reader[3].ToString();
                    deduction_amount = reader[4].ToString();
                    overtimehour = reader[6].ToString();
                    tax_amount = reader[7].ToString();
                    totalLeave = reader[8].ToString();
                    paysalary = reader[9].ToString();
                }

                name.Text = naming;
                id.Text = Id.ToString();
                month.Text = months;
                allowance.Text = allowance_amount+" Ks";
                deduction.Text = deduction_amount + " Ks";
                tax.Text = tax_amount+" %";
                leave.Text = totalLeave+" days";
                salary.Text = paysalary + " Ks";
                overtime.Text = overtimehour+" hours";
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

        public PaySalary(string name, int id, string month)
        {
            InitializeComponent();
            naming = name;
            Id = id;
            months = month;
            
        }
    }
}
