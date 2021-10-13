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
    /// Interaction logic for Attendance.xaml
    /// </summary>
    public partial class Attendance : Window
    {
        string paths = "server=localhost;uid=root;pwd=root;database=payroll";
        MySqlConnection con;
        MySqlDataAdapter adp;
        MySqlDataReader reader;
        MySqlCommandBuilder comdl;
        DataSet ds;
        public Attendance()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textdate.Text = (DateTime.Now.Date).ToShortDateString();
            con = new MySqlConnection(paths);
            string date = (DateTime.Now.Date).ToShortDateString();
            string[] datesplit = date.Split('/');
            int dategynn = Convert.ToInt16(datesplit[1]);
            try
            {
                con.Open();
                adp = new MySqlDataAdapter("select employee_id as ID, name as Name, latetime as Late_Minute, preexittime as Preexit_Minute from attendance where employee_id not in(select employee_id from leavelist where endleave >= "+dategynn+" and leave_code in("+2207+","+2208+"))", con);
                ds = new DataSet();
                adp.Fill(ds, "attendance");
                dataGrid.DataContext = ds.Tables[0].DefaultView;
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

        private void save_click(object sender, RoutedEventArgs e)
        {
            con = new MySqlConnection(paths);
            try
            {
                con.Open();
                comdl = new MySqlCommandBuilder(adp);
                adp.Update(ds, "attendance");
                MessageBox.Show("OK");
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

        private void confirm_click(object sender, RoutedEventArgs e)
        {
            con = new MySqlConnection(paths);
            MySqlConnection con1 = new MySqlConnection(paths);
            MySqlConnection con2 = new MySqlConnection(paths);
            int id, latetime, preexit;
            int count = 0;
            decimal totalhour;
            string name;
            string date = (DateTime.Now.Date).ToShortDateString();
            string[] datesplit = date.Split('/');
            int dategynn = Convert.ToInt16(datesplit[1]);
            try
            {
                con.Open();
                con1.Open();
                con2.Open();
                MySqlCommand command = new MySqlCommand("select * from attendance where employee_id not in(select employee_id from leavelist where endleave >= " + dategynn + " and leave_code in(" + 2207 + "," + 2208 + "))", con);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt16(reader[0].ToString());
                    name = reader[1].ToString();
                    latetime = Convert.ToInt16(reader[2].ToString());
                    preexit = Convert.ToInt16(reader[3].ToString());
                    totalhour = 480 - (latetime + preexit);
                    command = new MySqlCommand("insert into daily_attendance values(" + id + ",'" + date + "','" + name + "'," + latetime + "," + preexit + "," + totalhour/60 + ")", con1);
                    command.ExecuteNonQuery();count++;
                }
                command = new MySqlCommand("update attendance set latetime = " + 0 + ", preexittime = " + 0, con2);
                int row = command.ExecuteNonQuery();
                if (count > 0 && row > 0) MessageBox.Show("Successful");

            }catch(Exception ex)
            {
                con.Close();
                con1.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                con1.Close();
            }
        }
    }
}
