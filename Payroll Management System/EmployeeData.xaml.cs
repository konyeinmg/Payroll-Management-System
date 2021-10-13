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
    /// Interaction logic for EmployeeData.xaml
    /// </summary>
    public partial class EmployeeData : Window
    {
        string name;
        int id;
        public EmployeeData()
        {
            InitializeComponent();
            
        }
        public EmployeeData(string name,int id)
        {
            InitializeComponent();
            this.name = name;
            this.id = id;
        }
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            textBox1.IsReadOnly = true;
            textBox2.IsReadOnly = true;
            textBox3.IsReadOnly = true;
            textBox4.IsReadOnly = true;
            textBox5.IsReadOnly = true;
            textBox6.IsReadOnly = true;
            textBox7.IsReadOnly = true;
            textBox8.IsReadOnly = true;
            textBox9.IsReadOnly = true;
            textBox10.IsReadOnly = true;
            textBox11.IsReadOnly = true;
            textBox12.IsReadOnly = true;
            textBox13.IsReadOnly = true;
            textBox14.IsReadOnly = true;
            textBox15.IsReadOnly = true;
            textBox16.IsReadOnly = true;
            textBox17.IsReadOnly = true;
            textBox18.IsReadOnly = true;
            textBox19.IsReadOnly = true;
            textBox20.IsReadOnly = true;
            textBox21.IsReadOnly = true;
            textBox22.IsReadOnly = true;
            textBox23.IsReadOnly = true;
            textBox24.IsReadOnly = true;
            textBox25.IsReadOnly = true;
            string paths = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(paths);
            string command = "select * from curriculum_vitae,employee,dept where curriculum_vitae.employee_id = employee.employee_id and employee.dept_code = dept.dept_code and employee.employee_id = "+id+" and employee.name = '"+name+"'";
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(command, con);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    textBox1.Text = reader[2].ToString();
                    textBox2.Text = reader[23].ToString();
                    textBox3.Text = reader[30].ToString();

                    string[] test = (reader[28].ToString()).Split(' ');
                    textBox4.Text = test[0];

                    textBox5.Text = reader[34].ToString();
                    textBox6.Text = reader[26].ToString();
                    textBox7.Text = reader[7].ToString();
                    textBox8.Text = reader[21].ToString();
                    textBox9.Text = reader[8].ToString();
                    textBox10.Text = reader[3].ToString();
                    textBox11.Text = reader[14].ToString();
                    textBox12.Text = reader[9].ToString();
                    textBox13.Text = reader[6].ToString();


                    int h = Convert.ToInt16(reader[16].ToString());
                    textBox14.Text = (h / 12).ToString() + " ft " + (h % 12).ToString() + " inches";
                    textBox15.Text = reader[19].ToString();
                    textBox16.Text = reader[15].ToString();
                    textBox17.Text = reader[17].ToString();
                    textBox18.Text = reader[11].ToString();

                   // string[] tests = (reader[5].ToString()).Split(' ');
                    textBox19.Text = reader[5].ToString();
                    string[] testing = reader[5].ToString().Split('/');
                    int birth = Convert.ToInt16(testing[2]);
                    textBox20.Text = (DateTime.Now.Year - birth).ToString();

                    textBox21.Text = reader[4].ToString();
                    textBox22.Text = reader[10].ToString();
                    textBox23.Text = reader[12].ToString();
                   textBox24.Text = reader[22].ToString();
                    textBox25.Text = reader[13].ToString();

                }

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

        //private void edit_click(object sender, RoutedEventArgs e)
        //{


        //    textBox1.IsReadOnly = true;
        //    textBox2.IsReadOnly = true;
        //    textBox3.IsReadOnly = true;
        //    textBox4.IsReadOnly = true;
        //    textBox5.IsReadOnly = true;
        //    textBox6.IsReadOnly = false;
        //    textBox7.IsReadOnly = true;
        //    textBox8.IsReadOnly = false;
        //    textBox9.IsReadOnly = false;
        //    textBox10.IsReadOnly = true;
        //    textBox11.IsReadOnly = true;
        //    textBox12.IsReadOnly = false;
        //    textBox13.IsReadOnly = true;
        //    textBox14.IsReadOnly = true;
        //    textBox15.IsReadOnly = true;
        //    textBox16.IsReadOnly = true;
        //    textBox17.IsReadOnly = false;
        //    textBox18.IsReadOnly = false;
        //    textBox19.IsReadOnly = true;
        //    textBox20.IsReadOnly = false;
        //    textBox21.IsReadOnly = false;
        //    textBox22.IsReadOnly = false;
        //    textBox23.IsReadOnly = true;
        //    textBox24.IsReadOnly = false;
        //    textBox25.IsReadOnly = false;

        //}

        private void save_click(object sender, RoutedEventArgs e)
        {
            string section = textBox6.Text;
            string salary = textBox3.Text;
            string email = textBox8.Text;
            string priPhone = textBox9.Text;
            string secPhone = textBox12.Text;
            string temAddress = textBox18.Text;
            string marital = textBox21.Text;
            string township = textBox22.Text;
            string experience = textBox25.Text;
            string language = textBox24.Text;
            string weight = textBox17.Text;
            string paths = "server=localhost;uid=root;pwd=root;database=payroll";
            MySqlConnection con = new MySqlConnection(paths);
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("update employee,curriculum_vitae set language ='" + language + "',  position = '" + section + "' ,expected_salary='" + salary + "',email='" + email + "',permanent_phone='" + priPhone + "',secondary_phone='" + secPhone + "',tem_address='" + temAddress + "',marital='" + marital + "',weight='" + weight + "', township='" + township + "',experience='" + experience + "' where employee.employee_id = curriculum_vitae.employee_id and employee.employee_id = " + id + " and employee.name = '" + name + "'", con);
                int row = cmd.ExecuteNonQuery();
                if (row > 0) MessageBox.Show("successful","success",MessageBoxButton.OK);
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

        private void edit_checked(object sender, RoutedEventArgs e)
        {
            textBox1.IsReadOnly = true;
            textBox2.IsReadOnly = true;
            textBox3.IsReadOnly = true;
            textBox4.IsReadOnly = true;
            textBox5.IsReadOnly = true;
            textBox6.IsReadOnly = false;
            textBox7.IsReadOnly = true;
            textBox8.IsReadOnly = false;
            textBox9.IsReadOnly = false;
            textBox10.IsReadOnly = true;
            textBox11.IsReadOnly = true;
            textBox12.IsReadOnly = false;
            textBox13.IsReadOnly = true;
            textBox14.IsReadOnly = true;
            textBox15.IsReadOnly = true;
            textBox16.IsReadOnly = true;
            textBox17.IsReadOnly = false;
            textBox18.IsReadOnly = false;
            textBox19.IsReadOnly = true;
            textBox20.IsReadOnly = false;
            textBox21.IsReadOnly = false;
            textBox22.IsReadOnly = false;
            textBox23.IsReadOnly = true;
            textBox24.IsReadOnly = false;
            textBox25.IsReadOnly = false;
        }
    }
}
