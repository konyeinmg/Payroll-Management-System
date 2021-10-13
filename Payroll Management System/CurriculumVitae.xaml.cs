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
    /// Interaction logic for CurriculumVitae.xaml
    /// </summary>
    public partial class CurriculumVitae : Window
    {
        string sex;
        string[] religion = { "Budda", "Hindu", "Muslin", "Christian" };
        string[] blood = { "O", "A", "B", "AB" };
        string[] marital = { "Single", "Married", "Widowed", "Divorced" };
        public CurriculumVitae()
        {
            InitializeComponent();
        }
        private void save_click(object sender, RoutedEventArgs e)
        {
            string[] testingnull = { txtApply.Text, txtName.Text, txtMarital.Text, txtDOB.Text, txtNRC.Text, txtFather.Text, txtPrimaryph.Text, txtSecondaryph.Text, txtTown.Text, txtTempaddr.Text, txtEdu.Text, txtExperience.Text, txtBlood.Text, txtReligion.Text, txtWeight.Text, txtPOB.Text, txtExSalary.Text, txtEmail.Text, txtFeet.Text, txtInches.Text, txtLanguage.Text };
            if (MainWindow.testnull(testingnull))
            {
                string role = txtApply.Text;
                string name = txtName.Text;
                string marital = txtMarital.Text;
                string dob = txtDOB.Text;
                //string[] testing = txtDOB.Text.Split('/');
                //int birth = Convert.ToInt16(testing[2]);
                //txtAge.Text = (DateTime.Now.Year - birth).ToString();
                string nrc = txtNRC.Text;
                string father = txtFather.Text;
                string perPh = txtPrimaryph.Text;
                string secPh = txtSecondaryph.Text;
                string township = txtTown.Text;
                string temAddr = txtTempaddr.Text;
                string education = txtEdu.Text;
                string experience = txtExperience.Text;
                string blood = txtBlood.Text;
                string religion = txtReligion.Text;
                string weight = txtWeight.Text;
                string otherName = txtOthername.Text;
                string pob = txtPOB.Text;
                string exSalary = txtExSalary.Text;
                string email = txtEmail.Text;
                decimal feet = Convert.ToDecimal(txtFeet.Text);
                decimal inches = Convert.ToDecimal(txtInches.Text);
                decimal height = (feet * 12) + inches;
                string language = txtLanguage.Text;





                string paths = "server=localhost;uid=root;pwd=root;database=payroll";
                MySqlConnection con = new MySqlConnection(paths);
                string command = "insert into curriculum_vitae(role,name,marital,DOB,NRC,father_name,permanent_phone,secondary_phone,township,tem_address,education,experience,blood,religion,weight,other_name,place_birth,expected_salary,email,height,sex,language) values('" + role + "','" + name + "','" + marital + "','" + dob + "','" + nrc + "','" + father + "','" + perPh + "','" + secPh + "','" + township + "','" + temAddr + "','" + education + "','" + experience + "','" + blood + "','" + religion + "','" + weight + "','" + otherName + "','" + pob + "','" + exSalary + "','" + email + "'," + height + ",'" + sex + "','" + language + "')";
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(command, con);

                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Succeed!");
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
            else MessageBox.Show("Please enter completely");
            //string role = txtApply.Text;
            //string name = txtName.Text;
            //string marital = txtMarital.Text;
            //string dob = txtDOB.Text;
            ////string[] testing = txtDOB.Text.Split('/');
            ////int birth = Convert.ToInt16(testing[2]);
            ////txtAge.Text = (DateTime.Now.Year - birth).ToString();
            //string nrc = txtNRC.Text;
            //string father = txtFather.Text;
            //string perPh = txtPrimaryph.Text;
            //string secPh = txtSecondaryph.Text;
            //string township = txtTown.Text;
            //string temAddr = txtTempaddr.Text;
            //string education = txtEdu.Text;
            //string experience = txtExperience.Text;
            //string blood = txtBlood.Text;
            //string religion = txtReligion.Text;
            //string weight = txtWeight.Text;
            //string otherName = txtOthername.Text;
            //string pob = txtPOB.Text;
            //string exSalary = txtExSalary.Text;
            //string email = txtEmail.Text;
            //decimal feet = Convert.ToDecimal(txtFeet.Text);
            //decimal inches = Convert.ToDecimal(txtInches.Text);
            //decimal height = (feet * 12) + inches;
            //string language = txtLanguage.Text;





            //string paths = "server=localhost;uid=root;pwd=root;database=payroll";
            //MySqlConnection con = new MySqlConnection(paths);
            //string command = "insert into curriculum_vitae(role,name,marital,DOB,NRC,father_name,permanent_phone,secondary_phone,township,tem_address,education,experience,blood,religion,weight,other_name,place_birth,expected_salary,email,height,sex,language) values('" + role + "','" + name + "','" + marital + "','"+dob+"','" + nrc + "','" + father + "','" + perPh + "','" + secPh + "','" + township + "','" + temAddr + "','" + education + "','" + experience + "','" + blood + "','" + religion + "','" + weight + "','" + otherName + "','" + pob + "','" + exSalary + "','" + email + "',"+height+",'"+ sex +"','"+language+"')";
            //try
            //{
            //    con.Open();
            //    MySqlCommand cmd = new MySqlCommand(command, con);

            //    int result = cmd.ExecuteNonQuery();
            //    if (result > 0)
            //    {
            //        MessageBox.Show("Succeed!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    con.Close();
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //}
        }

        private void changed(object sender, SelectionChangedEventArgs e)
        {
            string[] testing = txtDOB.Text.Split('/');
            int birth = Convert.ToInt16(testing[2]);
            txtAge.Text = (DateTime.Now.Year - birth).ToString();
        }
        

        private void male_checked(object sender, RoutedEventArgs e)
        {
            sex = "male";
        }

        private void female(object sender, RoutedEventArgs e)
        {
            sex = "female";
        }

    

        private void cvnew_click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtNRC.Clear();
            txtDOB.SelectedDate = DateTime.Now.Date;
            txtFather.Clear();
            txtApply.Clear();
            txtOthername.Clear();
            txtReligion.Items.Clear();
            txtReligion.ItemsSource = religion;
            txtBlood.Items.Clear();
            txtBlood.ItemsSource = blood;
            txtFeet.Clear();
            txtInches.Clear();
            txtAge.Clear();
            txtWeight.Clear();
            txtExSalary.Clear();
            txtMarital.Items.Clear();
            txtMarital.ItemsSource = marital;
            txtPOB.Clear();
            txtTown.Clear();
            txtEmail.Clear();
            txtPrimaryph.Clear();
            txtSecondaryph.Clear();
            txtTempaddr.Clear();
            txtEdu.Clear();
            txtExperience.Clear();
            txtLanguage.Clear();
            radioMale.IsChecked = false;
            radioFemale.IsChecked = false;

        }

        private void win_loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
