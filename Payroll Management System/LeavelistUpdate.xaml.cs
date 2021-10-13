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
    /// Interaction logic for LeavelistUpdate.xaml
    /// </summary>
    public partial class LeavelistUpdate : Page
    {
        string name, begin, end, type;
        string[] lea_type = { "Casual Leave", "Annual Leave", "Medical Leave", "Parental Leave", "Study & Training Leave", "Adverse Weather Leave", "Absence", "Personal Leave" };

        private void page_loaded(object sender, RoutedEventArgs e)
        {
            txtName.Text = name;
            txtID.Text = id.ToString();
            txtPicker.SelectedDate = DateTime.Parse(begin);
            txtPicker1.SelectedDate = DateTime.Parse(end);
            txtType.Items.Clear();
            txtType.ItemsSource = lea_type;
            txtType.Text = type;
            //for (int i = 0; i < lea_type.Length; i++)
            //{
            //    if (type == lea_type[i])
            //    {
            //        txtType.SelectedIndex = i; break;
            //    }
            //}
        }

        private void submit_click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string id = txtID.Text;
            string type = txtType.Text;
            string begin = txtPicker.Text;
            string end = txtPicker1.Text;
            string[] beginarr = begin.Split('/');
            string[] endarr = end.Split('/');
            int length = 1 + (Convert.ToInt16(endarr[1]) - Convert.ToInt16(beginarr[1]));
            int index = txtType.SelectedIndex;
            int leave_code = 0;
            switch (index)
            {
                case 0: leave_code = 2201; break;
                case 1: leave_code = 2202; break;
                case 2: leave_code = 2203; break;
                case 3: leave_code = 2204; break;
                case 4: leave_code = 2205; break;
                case 5: leave_code = 2206; break;
                case 6: leave_code = 2207; break;
                case 7: leave_code = 2208; break;
                default: break;
            }
            string path = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(path);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update leavelist set employee_id="+id+",name='"+name+"',begin_date='"+begin+"',end_date='"+end+"',leave_code="+leave_code+", length = "+length+" where employee_id="+id , con);
                int row = cmd.ExecuteNonQuery();
                if (row > 0) MessageBox.Show("Successful","Success",MessageBoxButton.OK);
                MySqlDataAdapter myAdp = new MySqlDataAdapter("select leave_no as No, employee_id as ID, name as Name, begin_date as Begin, end_date as End,length as Length, leave_type as Type from leavelist,leave_ty where leavelist.leave_code = leave_ty.leave_code", con);
                DataSet ds = new DataSet();
                myAdp.Fill(ds, "Leave");
                ((MainWindow)System.Windows.Application.Current.MainWindow).dataGrid.DataContext = ds.Tables[0].DefaultView;
                Search.table = 4;
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

        int id;
        public LeavelistUpdate()
        {
            InitializeComponent();
        }
        public LeavelistUpdate(string name, int id, string begin, string end, string type)
        {
            InitializeComponent();
            this.name = name;
            this.id = id;
            this.begin = begin;
            this.end = end;
            this.type = type;
        }
    }
}
