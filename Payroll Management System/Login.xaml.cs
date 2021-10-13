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

namespace Payroll_Management_System
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private static string path = "server=localhost;uid=root;pwd=root;database=payroll";
        MySqlConnection con = new MySqlConnection(path);
        string name,pwd;
        int id;
        public Login()
        {
            InitializeComponent();
        }

        private void kick_click(object sender, RoutedEventArgs e)
        {
            name = txtName.Text;
            id = Convert.ToInt16(txtid.Text);
            pwd = txtpwd.Password;

            string namedata = null,pwddata = null;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select admin,password,id from login where id = " + id,con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    namedata = reader[0].ToString();
                    pwddata = reader[1].ToString();
                }
                if(namedata == name && pwddata == pwd)
                {
                    MainWindow w = new MainWindow();
                    this.Hide();
                    w.Show();
                }
                else if(pwddata != pwd){
                    txtpwd.Password = null;
                } 
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

        private void sing_click(object sender, RoutedEventArgs e)
        {
            name = txtName.Text;
            id = Convert.ToInt16(txtid.Text);
            pwd = txtpwd.Password;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("insert into login(admin,password,id) values('" + name + "','" + pwd + "'," + id+")", con);
                cmd.ExecuteNonQuery();
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
    }
}
