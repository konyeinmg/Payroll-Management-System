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
using System.Data;
using MySql.Data.MySqlClient;

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for ConfirmPage.xaml
    /// </summary>
    public partial class ConfirmPage : Page
    {
        string[] months = { "Jan", "Feb", "March", "April", "May", "Jun", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };
        public ConfirmPage()
        {
            InitializeComponent();
        }

        private void sureconfirm_click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result =  MessageBox.Show("Are you sure?", "Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                //getting now month index
                string nowmonth = (DateTime.Now.Date).ToShortDateString();
                string[] monthindex = nowmonth.Split('/');
                int monthNowIndex = Convert.ToInt16(monthindex[0]);

                //int monthNowIndex = 7;
                string month = MonthName(monthNowIndex);//to know month name

                string name, dept_name;
                int id, overtime = 0, eindex, totalleave, trow = 0, row = 0;
                decimal totalAttendanceHour, basic_salary, hourly_charge, tax, pay_salary, tax_salary;
                decimal allowance_amount = 0, deduction_amount = 0;

                string path = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con = new MySqlConnection(path);
                MySqlConnection con1 = new MySqlConnection(path);
                MySqlConnection con2 = new MySqlConnection(path);
                MySqlConnection con3 = new MySqlConnection(path);
                MySqlConnection con4 = new MySqlConnection(path);
                MySqlConnection con5 = new MySqlConnection(path);
                MySqlConnection con6 = new MySqlConnection(path);
                MySqlDataReader readRowovertime;
                MySqlDataReader readRowallowance;
                MySqlDataReader readRowdeduction;
                try
                {
                    con.Open();
                    con1.Open();
                    con2.Open();
                    con3.Open();
                    con4.Open();
                    con5.Open();
                    con6.Open();

                    MySqlCommand cmd = new MySqlCommand("select employee.name,employee.employee_id,basic_salary,dept.dept_name,tax,hourlycharge from employee,dept where employee.dept_code = dept.dept_code", con);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        name = reader[0].ToString();
                        id = Convert.ToInt16(reader[1].ToString());
                        basic_salary = Convert.ToDecimal(reader[2].ToString());
                        dept_name = reader[3].ToString();
                        tax = Convert.ToDecimal(reader[4].ToString());
                        hourly_charge = Convert.ToDecimal(reader[5].ToString());
                        // trow = Convert.ToInt16(reader[6].ToString());

                        cmd = new MySqlCommand("select sum(totalhour) from daily_attendance where employee_id = " + id, con1);
                        Object o = cmd.ExecuteScalar();
                        totalAttendanceHour = Convert.ToDecimal(o.ToString());

                        cmd = new MySqlCommand("select sum(overtime) from dailyovertime where employee_id = " + id, con2);
                        readRowovertime = cmd.ExecuteReader();
                        while (readRowovertime.Read())
                        {
                            overtime = Convert.ToInt16(readRowovertime[0].ToString());
                        }

                        cmd = new MySqlCommand("select allowance_amount,begin_month,end_month from allowance where employee_id = " + id, con3);
                        readRowallowance = cmd.ExecuteReader();
                        while (readRowallowance.Read())
                        {
                            eindex = MonthIndex(readRowallowance[2].ToString());//end month index
                            if (eindex >= monthNowIndex)

                            {
                                allowance_amount += Convert.ToDecimal(readRowallowance[0].ToString());
                            }
                        }

                        cmd = new MySqlCommand("select deduction_amount,begin_month,end_month from deduction where employee_id = " + id, con4);
                        readRowdeduction = cmd.ExecuteReader();
                        while (readRowdeduction.Read())
                        {
                            eindex = MonthIndex(readRowdeduction[2].ToString());
                            if (eindex >= monthNowIndex)
                            {

                                deduction_amount += Convert.ToDecimal(readRowdeduction[0].ToString());
                            }
                        }
                        cmd = new MySqlCommand("select sum(length) from leavelist where employee_id = " + id, con5);
                        Object leave = cmd.ExecuteScalar();
                        totalleave = Convert.ToInt16(leave.ToString());

                        //MessageBox.Show(name + " " + id + " " + totalAttendanceHour + " " + overtime + " " + allowance_amount + " " + deduction_amount + " " + totalleave);
                        tax_salary = basic_salary - ((basic_salary * tax) / 100);
                        pay_salary = tax_salary + allowance_amount - deduction_amount + (overtime * hourly_charge);

                        cmd = new MySqlCommand("insert into payroll_month values(" + id + ",'" + name + "'," + basic_salary + "," + allowance_amount + "," + deduction_amount + "," + totalAttendanceHour + "," + overtime + "," + tax + "," + totalleave + "," + pay_salary + ",'" + dept_name + "','" + month + "')", con6);
                        cmd.ExecuteNonQuery();
                        row++;
                        readRowovertime.Close();
                        readRowallowance.Close();
                        readRowdeduction.Close();
                    }
                    if (5 == row) MessageBox.Show("Successful!!!", "Success", MessageBoxButton.OK);
                    else MessageBox.Show("mistake");
                }
                catch (Exception ex)
                {
                    con.Close();
                    con1.Close();
                    con2.Close();
                    con3.Close();
                    con4.Close();
                    con5.Close();
                    con6.Close();
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    con1.Close();
                    con2.Close();
                    con3.Close();
                    con4.Close();
                    con5.Close();
                    con6.Close();
                }
            }
            ////getting now month index
            //string nowmonth = (DateTime.Now.Date).ToShortDateString();
            //string[] monthindex = nowmonth.Split('/');
            //int monthNowIndex = Convert.ToInt16(monthindex[0]);

            ////int monthNowIndex = 7;
            //string month = MonthName(monthNowIndex);//to know month name

            //string name, dept_name;
            //int id, overtime = 0, eindex, totalleave, trow = 0, row = 0;
            //decimal totalAttendanceHour, basic_salary, hourly_charge, tax, pay_salary, tax_salary;
            //decimal allowance_amount = 0, deduction_amount = 0;

            //string path = "server=localhost;uid=root;pwd=root;database=payroll";
            //MySqlConnection con = new MySqlConnection(path);
            //MySqlConnection con1 = new MySqlConnection(path);
            //MySqlConnection con2 = new MySqlConnection(path);
            //MySqlConnection con3 = new MySqlConnection(path);
            //MySqlConnection con4 = new MySqlConnection(path);
            //MySqlConnection con5 = new MySqlConnection(path);
            //MySqlConnection con6 = new MySqlConnection(path);
            //MySqlDataReader readRowovertime;
            //MySqlDataReader readRowallowance;
            //MySqlDataReader readRowdeduction;
            //try
            //{
            //    con.Open();
            //    con1.Open();
            //    con2.Open();
            //    con3.Open();
            //    con4.Open();
            //    con5.Open();
            //    con6.Open();

            //    MySqlCommand cmd = new MySqlCommand("select employee.name,employee.employee_id,basic_salary,dept.dept_name,tax,hourlycharge from employee,dept where employee.dept_code = dept.dept_code", con);
            //    MySqlDataReader reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        name = reader[0].ToString();
            //        id = Convert.ToInt16(reader[1].ToString());
            //        basic_salary = Convert.ToDecimal(reader[2].ToString());
            //        dept_name = reader[3].ToString();
            //        tax = Convert.ToDecimal(reader[4].ToString());
            //        hourly_charge = Convert.ToDecimal(reader[5].ToString());
            //        // trow = Convert.ToInt16(reader[6].ToString());

            //        cmd = new MySqlCommand("select sum(totalhour) from daily_attendance where employee_id = " + id, con1);
            //        Object o = cmd.ExecuteScalar();
            //        totalAttendanceHour = Convert.ToDecimal(o.ToString());

            //        cmd = new MySqlCommand("select sum(overtime) from dailyovertime where employee_id = " + id, con2);
            //        readRowovertime = cmd.ExecuteReader();
            //        while (readRowovertime.Read())
            //        {
            //            overtime = Convert.ToInt16(readRowovertime[0].ToString());
            //        }

            //        cmd = new MySqlCommand("select allowance_amount,begin_month,end_month from allowance where employee_id = " + id, con3);
            //        readRowallowance = cmd.ExecuteReader();
            //        while (readRowallowance.Read())
            //        {
            //            eindex = MonthIndex(readRowallowance[2].ToString());//end month index
            //            if (eindex >= monthNowIndex)

            //            {
            //                allowance_amount += Convert.ToDecimal(readRowallowance[0].ToString());
            //            }
            //        }

            //        cmd = new MySqlCommand("select deduction_amount,begin_month,end_month from deduction where employee_id = " + id, con4);
            //        readRowdeduction = cmd.ExecuteReader();
            //        while (readRowdeduction.Read())
            //        {
            //            eindex = MonthIndex(readRowdeduction[2].ToString());
            //            if (eindex >= monthNowIndex)
            //            {

            //                deduction_amount += Convert.ToDecimal(readRowdeduction[0].ToString());
            //            }
            //        }
            //        cmd = new MySqlCommand("select sum(length) from leavelist where employee_id = " + id, con5);
            //        Object leave = cmd.ExecuteScalar();
            //        totalleave = Convert.ToInt16(leave.ToString());

            //        //MessageBox.Show(name + " " + id + " " + totalAttendanceHour + " " + overtime + " " + allowance_amount + " " + deduction_amount + " " + totalleave);
            //        tax_salary = basic_salary - ((basic_salary * tax) / 100);
            //        pay_salary = tax_salary + allowance_amount - deduction_amount + (overtime * hourly_charge);

            //        cmd = new MySqlCommand("insert into payroll_month values(" + id + ",'" + name + "'," + basic_salary + "," + allowance_amount + "," + deduction_amount + "," + totalAttendanceHour + "," + overtime + "," + tax + "," + totalleave + "," + pay_salary + ",'" + dept_name + "','" + month + "')", con6);
            //        cmd.ExecuteNonQuery();
            //        row++;
            //        readRowovertime.Close();
            //        readRowallowance.Close();
            //        readRowdeduction.Close();
            //    }
            //    if (5 == row) MessageBox.Show("Successful!!!","Success",MessageBoxButton.OK);
            //    else MessageBox.Show("mistake");
            //}
            //catch (Exception ex)
            //{
            //    con.Close();
            //    con1.Close();
            //    con2.Close();
            //    con3.Close();
            //    con4.Close();
            //    con5.Close();
            //    con6.Close();
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //    con1.Close();
            //    con2.Close();
            //    con3.Close();
            //    con4.Close();
            //    con5.Close();
            //    con6.Close();
            //}
        }
        public int MonthIndex(string month)
        {
            int result = 0;
            for (int i = 0; i < 12; i++)
            {
                if (month == months[i])
                {
                    result = i + 1;
                    break;
                }
            }
            return result;

        }
        public string MonthName(int index)
        {
            return months[index - 1];
        }

        public int EndofMonth(int index)
        {
            if (index == 9 || index == 4 || index == 6 || index == 11)
                return 31;

            else if (index == 2) { 
                if (DateTime.Now.Year % 4 == 0) return 29;
                else return 28; }
            else return 31;
        }

        private void page_loaded(object sender, RoutedEventArgs e)
        {
            string nowmonth = (DateTime.Now.Date).ToShortDateString();
            string[] monthindex = nowmonth.Split('/');
            int monthNowIndex = Convert.ToInt16(monthindex[0]);
            int day = Convert.ToInt16(monthindex[1]);

            if (day != EndofMonth(monthNowIndex))
            {
                confirm.IsEnabled = false;
            }
        }
    }
}
