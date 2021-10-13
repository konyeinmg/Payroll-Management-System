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
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Page
    {
        private static string path = "server=localhost;uid=root;pwd=root;database=payroll";
        MySqlConnection con = new MySqlConnection(path);
        public View()
        {
            InitializeComponent();
        }

        private void allowance_click(object sender, RoutedEventArgs e)
        {
            try {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select allowance_no as No, name, allowance_type as Type, begin_month as Begin, end_month as End, allowance_length as Length, allowance_amount as Amount, employee_id as ID from allowance", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "allowance");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 1;
            }
            catch (NullReferenceException nex)
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select allowance_no as No, name, allowance_type as Type, begin_month as Begin, end_month as End, allowance_length as Length, allowance_amount as Amount, employee_id as ID from allowance", con);
                DataSet dt = new DataSet();
                myAdp.Fill(dt, "allowance");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = dt.Tables[0].DefaultView;
                Search.table = 1;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void deduction_click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select deduction_no as No, name, deduction_type as Type, begin_month as Begin, end_month as End, deduction_length as Length, deduction_amount as Amount, employee_id as ID from deduction", con);
                DataSet dt = new DataSet();
                myAdp.Fill(dt, "deduction");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = dt.Tables[0].DefaultView;
                Search.table = 2;
            }
            catch (NullReferenceException nex)
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select deduction_no as No, name, deduction_type as Type, begin_month as Begin, end_month as End, deduction_length as Length, deduction_amount as Amount, employee_id as ID from deduction", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "deduction");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 2;
            }
            catch (Exception ex)
            {
                con.Close();
                 MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void overtime_click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select overtime_no as No, overtime_date as Date, employee_id as ID, name as Name, overtime as Hour from dailyovertime", con);
                DataSet dt = new DataSet();
                myAdp.Fill(dt, "overtime");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = dt.Tables[0].DefaultView;
                Search.table = 3;
            }
            catch (NullReferenceException nex)
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select overtime_no as No, overtime_date as Date, employee_id as ID, name as Name, overtime as Hour from dailyovertime", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "overtime");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 3;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void leave_click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select leave_no as No, employee_id as ID, name as Name, begin_date as Begin, end_date as End,length as Length, leave_type as Type from leavelist,leave_ty where leavelist.leave_code = leave_ty.leave_code", con);
                DataSet dt = new DataSet();
                myAdp.Fill(dt, "Leave");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = dt.Tables[0].DefaultView;
                Search.table = 4;
            }
            catch (NullReferenceException nex)
            {
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select leave_no as No, employee_id as ID, name as Name, begin_date as Begin, end_date as End, leave_type as Type from leavelist,leave_ty where leavelist.leave_code = leave_ty.leave_code", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "Leave");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 4;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void paychange_click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select paychange_no as No, employee_id as ID, name as Name, change_amount  as Change_Amount, previous_amount as Pervious_Amount, paychange_type as Type, month as Month from paychange", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "paychange");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 5;
            }
            catch (NullReferenceException)
            {
                con.Open();
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select paychange_no as No, employee_id as ID, name as Name, change_amount as Change_Amount, previous_amount as Pervious_Amount, paychange_type as Type, month as Month from paychange", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "paychange");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 5;
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void atten_click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select attendance_date as Date, employee_id as ID, name as Name, latetime as Late_Minute, preexit_time as Preexit_Minute, totalhour as TotalHour from daily_attendance", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "attendance");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 6;
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void staff_click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select name as Name, role as ApplyFor, education as Degree, expected_salary as ExceptedSalary, experience as Experience from curriculum_vitae where employee_id is null", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "temporary");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
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

        private void viewpay_click(object sender, RoutedEventArgs e)
        {
            PaySlip slip = new PaySlip();
            slip.Show();
        }

        private void find_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void find_click(object sender, RoutedEventArgs e)
        {
            try
            {
                    switch (Search.table)
                    {
                        case 1: Allowance(); break;
                        case 2: Deduction(); break;
                        case 3: Overtime(); break;
                        case 4: Leavelist(); break;
                        case 5: Paychange(); break;
                        default: break;
                    }
                
            }catch(Exception ex)
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).frame.Content = new View();
            }
              
        }
        public void Allowance()
        {
                string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
                string type = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
                string begin = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
                string end = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
                string amount = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[6].ToString();
                string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[7].ToString();
                ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new AllowanceUpdate(name, type, begin, end, Convert.ToDecimal(amount), Convert.ToInt32(id));
                MainWindow.global = 0;
            
        }
        public void Deduction()
        {
            string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
            string type = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
            string begin = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
            string end = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
            string amount = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[6].ToString();
            string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[7].ToString();
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new DeductionUpdate(name, type, begin, end, Convert.ToDecimal(amount), Convert.ToInt32(id));
            MainWindow.global = 0;
        }
        public void Overtime()
        {
            string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
            string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
            string overtime = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
            string date = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new OvertimeUpdate(name, Convert.ToInt16(id), Convert.ToInt16(overtime), date);
            MainWindow.global = 0;
        }
        public void Leavelist()
        {
            string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
            string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
            string begin = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
            string end = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
            string type = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[5].ToString();
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new LeavelistUpdate(name, Convert.ToInt16(id), begin, end, type);
            MainWindow.global = 0;
        }
        public void Paychange()
        {
            string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
            string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
            string change_amount = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
            string previous_amount = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
            string type = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[5].ToString();
            string month = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[6].ToString();
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new PayUpdate(name, Convert.ToInt16(id), Convert.ToDecimal(change_amount), Convert.ToDecimal(previous_amount), type, month);
            MainWindow.global = 0;
        }
    }
}
