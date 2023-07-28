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
using System.Text.RegularExpressions;
using projects;
using DSAProject;
using SchoolManagementSystem;

namespace DSAProject
{
    public partial class SINGUP : MetroForm
    {
        string pattern= "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        string passpattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
        int i;
        public SINGUP()
        {
            InitializeComponent();
        }

        private void metroTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == true)
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

      
        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void metroTextBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroTextBox2.Text) == true)
            {
                metroTextBox2.Focus();
                errorProvider2.SetError(this.metroTextBox2, "Plz Enter Name");
            }
            else
            {
                errorProvider2.Clear();
            }

        }

        private void metroTextBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void metroTextBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(metroTextBox3.Text) == true)
            {
                metroTextBox3.Focus();
                errorProvider3.SetError(this.metroTextBox3, "Plz Enter Name");
            }
            else
            {
                errorProvider3.Clear();
            }
        }



        private void metroTextBox4_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(metroTextBox4.Text,pattern)==false)
            {
                metroTextBox4.Focus();
                errorProvider5.SetError(this.metroTextBox4, "Plz Enter Valid Email");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void metroTextBox5_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(metroTextBox5.Text,passpattern)==false)
            {
                metroTextBox5.Focus();
                errorProvider6.SetError(this.metroTextBox5, "Chose Strong Password");
            }
            else
            {
                errorProvider6.Clear();
            }
        }

       

        private void metroTextBox6_Leave(object sender, EventArgs e)
        {
            if (metroTextBox5.Text  !=   metroTextBox6.Text)
            {
                metroTextBox6.Focus();
                errorProvider7.SetError(this.metroTextBox6,"Password are not identical...!!");
            }
            else
            {
                errorProvider7.Clear();
            }
        }

        private void metroComboBox1_Leave(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedItem==null)
            {
                metroComboBox1.Focus();
                errorProvider4.SetError(this.metroComboBox1, "Plz select gender");
            }
            else
            {
                errorProvider4.Clear();
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
          
            metroTextBox2.Clear();
            metroTextBox3.Clear();
            metroComboBox1.SelectedItem = null;
            metroTextBox4.Clear();
            metroTextBox5.Clear();
            metroTextBox6.Clear();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            
             if (string.IsNullOrEmpty(metroTextBox2.Text) == true)
            {
                metroTextBox2.Focus();
                errorProvider2.SetError(this.metroTextBox2, "Plz Enter Name");
            }
            else if (string.IsNullOrEmpty(metroTextBox3.Text) == true)
            {
                metroTextBox3.Focus();
                errorProvider3.SetError(this.metroTextBox3, "Plz Enter Name");
            }


            else if (metroComboBox1.SelectedItem == null)
            {
                metroComboBox1.Focus();
                errorProvider4.SetError(this.metroComboBox1, "Plz select gender");
            }
            else if (Regex.IsMatch(metroTextBox4.Text, pattern) == false)
            {
                metroTextBox4.Focus();
                errorProvider5.SetError(this.metroTextBox4, "Plz Enter Valid Email");
            }

            else if (Regex.IsMatch(metroTextBox5.Text, passpattern) == false)
            {
                metroTextBox5.Focus();
                errorProvider6.SetError(this.metroTextBox5, "Chose Strong Password");
            }
            else if (metroTextBox5.Text != metroTextBox6.Text)
            {
                metroTextBox6.Focus();
                errorProvider7.SetError(this.metroTextBox6, "Password are not identical...!!");
            }
            else
            {
                // MetroFramework.MetroMessageBox.Show(this,"Wellcome");

                string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string query2 = "select * from signup where fname=@fname  ";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.AddWithValue("@fname", metroTextBox2.Text);
                con.Open();
                SqlDataReader dr = cmd2.ExecuteReader();

                if (dr.HasRows == true)
                {

                    //MetroFramework.MetroMessageBox.Show(this, metroTextBox1.Text + "Id Already Exist", "Faliure", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {

                    con.Close();
                     
                    string query = "insert into signup values(@fname,@lname,@gender,@email,@pass)";
                    SqlCommand cmd = new SqlCommand(query, con);
                   // cmd.Parameters.AddWithValue("@id", metroTextBox1.Text);
                    cmd.Parameters.AddWithValue("@fname", metroTextBox2.Text);
                    cmd.Parameters.AddWithValue("@lname", metroTextBox3.Text);
                    cmd.Parameters.AddWithValue("@gender", metroComboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@email", metroTextBox4.Text);
                    cmd.Parameters.AddWithValue("@pass", metroTextBox5.Text);
                    con.Open();

                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Registered Succesful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MetroFramework.MetroMessageBox.Show(this, "YOUR EMAIL IS :"+ metroTextBox4.Text+"\n"+"YOUR PASSWORD IS:"+ metroTextBox5.Text, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Form1 f = new Form1();
                        f.Show();
                    }

                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Registered failed", "Faliure", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admission a = new Admission();
            a.Show();
            this.Hide();
        }

        private void SINGUP_Load(object sender, EventArgs e)
        {
            //metroButton1.Background = Brushes.Red;

            this.metroButton2.BackColor = Color.Yellow;
            this.metroButton1.BackColor = Color.Green;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Userlogin u = new Userlogin();
            u.Show();
            this.Hide();
        }
    }
}
