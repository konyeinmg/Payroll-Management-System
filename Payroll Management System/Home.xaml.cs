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
using System.Collections;

namespace Payroll_Management_System
{
    
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        string[] months = { "Jan", "Feb", "March", "April", "May", "Jun", "July", "Aug", "Sept", "Oct", "Nov", "Dec" };
        public Home()
        {
            InitializeComponent();
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Search();
            MainWindow.global = 0;
        }

        private void new_click(object sender, RoutedEventArgs e)
        {
            switch (MainWindow.global)
            {
                case 1:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Allowance(); break;
                case 2:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Deduction(); break;
                case 3:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Overtime(); break;
                case 4:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Leavelist(); break;
                case 5:
                    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new Pay_Change(); break;
              
                default: break;

            }
        }

        //private void find_click(object sender, RoutedEventArgs e)
        //{
        //    switch (Search.table)
        //    {
        //        case 1:Allowance(); break;
        //        case 2:Deduction(); break;
        //        case 3:Overtime(); break;
        //        case 4:Leavelist(); break;
        //        case 5:Paychange(); break;
        //        default: break;
        //    }
        //}
        //public void Allowance()
        //{ 
        //        string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
        //        string type = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
        //        string begin = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
        //        string end = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
        //        string amount = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[6].ToString();
        //        string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[7].ToString();
        //        ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new AllowanceUpdate(name, type, begin, end, Convert.ToDecimal(amount), Convert.ToInt32(id));
        //        MainWindow.global = 0;
        //}
        //public void Deduction()
        //{
        //    string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
        //    string type = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
        //    string begin = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
        //    string end = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
        //    string amount = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[6].ToString();
        //    string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[7].ToString();
        //    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new DeductionUpdate(name, type, begin, end, Convert.ToDecimal(amount), Convert.ToInt32(id));
        //    MainWindow.global = 0;
        //}
        //public void Overtime()
        //{
        //    string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
        //    string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
        //    string overtime = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
        //    string date = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
        //    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new OvertimeUpdate(name, Convert.ToInt16(id), Convert.ToInt16(overtime), date);
        //    MainWindow.global = 0;
        //}
        //public void Leavelist()
        //{
        //   string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
        //    string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
        //    string begin = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
        //    string end = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
        //    string type = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[5].ToString();
        //    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new LeavelistUpdate(name, Convert.ToInt16(id), begin, end, type);
        //    MainWindow.global = 0;
        //}
        //public void Paychange()
        //{
        //    string name = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[2].ToString();
        //    string id = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[1].ToString();
        //    string change_amount = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[3].ToString();
        //    string previous_amount = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[4].ToString();
        //    string type = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[5].ToString();
        //    string month = ((DataRowView)((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.SelectedItem).Row[6].ToString();
        //    ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new PayUpdate(name, Convert.ToInt16(id), Convert.ToDecimal(change_amount), Convert.ToDecimal(previous_amount), type, month);
        //    MainWindow.global = 0;
        //}

        private void appointment_Click(object sender, RoutedEventArgs e)
        {
            New_Appointment app = new New_Appointment();
            app.Show();
        }

        private void cv_Click(object sender, RoutedEventArgs e)
        {
            CurriculumVitae cv = new CurriculumVitae();
            cv.Show();
            
        }

        private void kickout_Click(object sender, RoutedEventArgs e)
        {
            Kickout kout = new Kickout();
            kout.Show();
        }

        //private void confirm_click(object sender, ContextMenuEventArgs e)
        //{
        //    //getting now month index
        //    string nowmonth = (DateTime.Now.Date).ToShortDateString();
        //    string[] monthindex = nowmonth.Split('/');
        //    int monthNowIndex = Convert.ToInt16(monthindex[0]);
        //    string month = MonthName(monthNowIndex);//to know month name

        //    string name;
        //    int id,overtime = 0,eindex,totalleave;
        //    decimal totalAttendanceHour;
        //    decimal allowance_amount = 0, deduction_amount = 0;

        //    string path = "server=localhost;uid=root;pwd=root;database=payroll";
        //    MySqlConnection con = new MySqlConnection(path);
        //    MySqlConnection con1 = new MySqlConnection(path);
        //    MySqlConnection con2 = new MySqlConnection(path);
        //    MySqlConnection con3 = new MySqlConnection(path);
        //    MySqlConnection con4 = new MySqlConnection(path);
        //    MySqlConnection con5 = new MySqlConnection(path);
        //    MySqlConnection con6 = new MySqlConnection(path);
        //    MySqlDataReader readRow;
        //    try
        //    {
        //        con.Open();
        //        con1.Open();
        //        con2.Open();
        //        con3.Open();
        //        con4.Open();
        //        con5.Open();
                 
        //        MySqlCommand cmd = new MySqlCommand("select name,employee_id from employee where employee_id = "+32011, con);
        //        MySqlDataReader reader = cmd.ExecuteReader();
                
        //        while (reader.Read())
        //        {
        //            name = reader[0].ToString();
        //            id = Convert.ToInt16(reader[1].ToString());

        //            cmd = new MySqlCommand("select sum(totalhour) from daily_attendance where employee_id = "+id,con1);
        //            Object o = cmd.ExecuteScalar();
        //            totalAttendanceHour = Convert.ToDecimal(o.ToString());

        //            cmd = new MySqlCommand("select sum(overtime) from dailyovertime where employee_id = " + id, con2);
        //            readRow = cmd.ExecuteReader();
        //            while (readRow.Read())
        //            {
        //                overtime = Convert.ToInt16(readRow[0].ToString());
        //            }

        //            cmd = new MySqlCommand("select allowance_amount,begin_month,end_month from allowance where employee_id = " + id, con3);
        //            readRow = cmd.ExecuteReader();
        //            while (readRow.Read())
        //            {
        //                eindex = MonthIndex(readRow[2].ToString());//end month index
        //                if (eindex >= monthNowIndex)

        //                {
        //                    allowance_amount += Convert.ToDecimal(readRow[0].ToString());
        //                }
        //            }

        //            cmd = new MySqlCommand("select deduction_amount,begin_month,end_month from deduction where employee_id = " + id, con4);
        //            readRow = cmd.ExecuteReader();
        //            while (readRow.Read())
        //            {
        //                eindex = MonthIndex(readRow[2].ToString());
        //                if(eindex >= monthNowIndex)
        //                {
                            
        //                    deduction_amount += Convert.ToDecimal(readRow[0].ToString());
        //                }
        //            }
        //            cmd = new MySqlCommand("select sum(length) from leavelist where employee_id = "+id, con5);
        //            Object leave = cmd.ExecuteScalar();
        //            totalleave = Convert.ToInt16(leave.ToString());

        //            MessageBox.Show(name + " " + id + " " + totalAttendanceHour + " " + overtime + " " + allowance_amount + " " + deduction_amount + " " + totalleave);
                   

        //        }
        //    }catch (Exception ex)
        //    {
        //        con.Close();
        //        con1.Close();
        //        con2.Close();
        //        con3.Close();
        //        con4.Close();
        //        con5.Close();
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con1.Close();
        //        con2.Close();
        //        con3.Close();
        //        con4.Close();
        //        con5.Close();
        //    }
        //}
    

       

        private void confirm_Click_1(object sender, RoutedEventArgs e)
        {
            ((MainWindow)System.Windows.Application.Current.MainWindow).frame1.Content = new ConfirmPage();
        }

        private void employee_click(object sender, RoutedEventArgs e)
        {
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            try
            {
                con.Open();
                MySqlDataAdapter adp = new MySqlDataAdapter("select employee.employee_id as ID, employee.name as Name, position as Position, dept_name as Dept,basic_salary as Salary,start_date as Start_Date from employee,dept where employee.dept_code = dept.dept_code", con);
                DataSet ds = new DataSet();
                adp.Fill(ds, "employee");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
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

        private void browse_click(object sender, RoutedEventArgs e)
        {
            Browse browse = new Browse();
            browse.Show();            
        }
    }
}
