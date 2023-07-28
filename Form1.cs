
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DSAProject;
using SchoolManagementSystem;

namespace projects
{
    public partial class Form1 :  MetroForm
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
            metroTextBox2.UseSystemPasswordChar = true;
            metroComboBox1.SelectedIndex = 0;

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool check = checkBox1.Checked;
            switch (check)

            {
                case true:
                    metroTextBox2.UseSystemPasswordChar = false;
                    break;
                case false:

                    metroTextBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (metroComboBox1.SelectedIndex == 0)
            {
                metroComboBox1.Focus();
                errorProvider1.SetError(this.metroComboBox1, "Please Enter Your type ");
                return;
            }
            if (string.IsNullOrEmpty( metroTextBox1.Text))
            {

                metroComboBox1.Focus();
                errorProvider1.SetError(this.metroTextBox1, "Please Enter Details ");
                return;
            }
            if (string.IsNullOrEmpty( metroTextBox2.Text))
            {
                metroComboBox1.Focus();
                errorProvider1.SetError(this.metroTextBox2, "Please Enter Details ");
                return;
            }
            errorProvider1.Clear();

            if (metroComboBox1.SelectedItem == "ADMIN")
            {
              
                    string userName = "";
                    string userPassword = "";
                    SqlConnection con = new SqlConnection(cs);
                    string query = "select * from userss where username=@username and password=@password";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", metroTextBox1.Text);
                    cmd.Parameters.AddWithValue("@password", metroTextBox2.Text);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        
                        MetroFramework.MetroMessageBox.Show(this, "Login Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                        this.Hide();
                        Home dashboard = new Home();
                        dashboard.Show();
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Username And Password Incorrect\nPlease Double Check Your UserName And Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                

            }
            else if (metroComboBox1.SelectedItem == "Teacher")
            {
                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "select * from signup where email=@email and Pass=@Pass";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@email", metroTextBox1.Text);
                cmd2.Parameters.AddWithValue("@Pass", metroTextBox2.Text);
                con2.Open();
                SqlDataReader rd = cmd2.ExecuteReader();
              
                if (rd.HasRows == true)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Login Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                   Teacherdashboard dashboard = new Teacherdashboard();
                    dashboard.Show();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Login Failed", "faluire", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con2.Close();

                }

            }
            else if (metroComboBox1.SelectedItem == "Student")
            {

                SqlConnection con3 = new SqlConnection(cs);
                string query3 = "select * from Admission where user_name=@user_name and password=@password";
                SqlCommand cmd3 = new SqlCommand(query3, con3);
                cmd3.Parameters.AddWithValue("@user_name", metroTextBox1.Text);
                cmd3.Parameters.AddWithValue("@password", metroTextBox2.Text);
                con3.Open();
                SqlDataReader rd = cmd3.ExecuteReader();
                rd.Read();
                int id = Convert.ToInt32(rd[0].ToString());
                if (rd.HasRows == true)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Login Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    studentdashboard s = new studentdashboard();
                    s.Show();
                   
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Login Failed", "faluire", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    con3.Close();

                }
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }



        private void metroLabel3_Click(object sender, EventArgs e)
        {
            SINGUP s = new SINGUP();
            this.Hide();
            s.Show();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsLetter(ch) == true)
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;

            }
            else if (ch == 32)
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;

            }
        }

        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsDigit(ch))
            {
                e.Handled = false;
            }
            else if (ch == 8)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled = true;

            }
        }
    }
}