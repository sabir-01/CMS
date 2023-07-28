using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DSAProject;
using SchoolManagementSystem;
using projects;

namespace SchoolManagementSystem
{
    public partial class Userlogin : MetroForm
    {
        public Userlogin()
        {
            InitializeComponent();
            bindgridview();
        }
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        SqlConnection  con;

 
SqlCommand  cmd; SqlDataAdapter  da; SqlDataReader  dr;

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
        void bindgridview()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from userss";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {

                SqlConnection con = new SqlConnection(cs);

                cmd = new SqlCommand("InsertUser", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@password  ", textBox2.Text);
                con.Open();
               int a= cmd.ExecuteNonQuery();
                if (a>0)
                {

                MetroFramework.MetroMessageBox.Show(this, "Insertion  Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgridview();
                reset();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Insertion  Faield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

            }

            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Plz fill The textfield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }






                //  SqlConnection con = new SqlConnection(cs);
                //  string query = "insert into userss values(@username,@password)";
                //  SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@username", textBox1.Text);
                //cmd.Parameters.AddWithValue("@password", textBox2.Text);

                //  con.Open();

                //  int a = cmd.ExecuteNonQuery();

                //  if (a > 0)
                //  {
                //      MetroFramework.MetroMessageBox.Show(this, "Insertion  Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //      bindgridview();
                //      reset();                
                //  }

                //  else
                //  {
                //      MetroFramework.MetroMessageBox.Show(this, "Insertion  Faield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //  }
                //  con.Close();
                //  }

                //  else
                //  {
                //      MetroFramework.MetroMessageBox.Show(this, "Plz fill The textfield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  userss  where id=@id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", i);
            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Deletion  Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgridview();
                reset();


            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Deletion  Faield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }
        void reset() {

            textBox1.Clear();
            textBox2.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (Char.IsDigit(ch))
            {
                e.Handled = false;
            }
            else if (ch==8)
            {
                e.Handled = false;

            }

            else
            {
                e.Handled =true;

            }
        }
    }
}
