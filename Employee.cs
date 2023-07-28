using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Configuration;
using System.Data.SqlClient;
using DSAProject;
using SchoolManagementSystem;

namespace SchoolManagementSystem
{
    public partial class Employee : MetroForm
    {
        public Employee()
        {
            InitializeComponent();
            getteacherid();
            bindgridview();
        }
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void getteacherid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);

                con.Open();
                SqlCommand cmd = new SqlCommand("Select Admin_id from Admins", con);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("Admin_id", typeof(int));
                data.Load(Reader);
                comboBox2.ValueMember = "Admin_id";
                comboBox2.DataSource = data;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "college Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update  Employees set Employees_name=@Employees_name,Employees_type=@Employees_type,Employees_salary=@Employees_salary,Admin_id=@Admin_id where Employees_id=@Employees_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Employees_id", i);
            cmd.Parameters.AddWithValue("@Employees_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Employees_salary", textBox2.Text);
            cmd.Parameters.AddWithValue("@Employees_type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Admin_id", comboBox2.Text);


            con.Open();


            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Updation  Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgridview();
                resetcontrol();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Updation  Faield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }
        void resetcontrol()
        {

            textBox1.Clear();
            textBox2.Clear();           
            comboBox1.Text = "";
            comboBox2.Text = "";



        }

        void bindgridview()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_Employees";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ADMIN a = new ADMIN();
            a.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  Employees  where Employees_id=@Employees_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Employees_id", i);
            con.Open();
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Deletion  Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgridview();
                resetcontrol();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Deletion  Faield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Employees values(@Employees_name,@Employees_type,@Employees_salary,@Admin_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Employees_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Employees_type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Employees_salary", textBox2.Text);
            cmd.Parameters.AddWithValue("@admin_id", comboBox2.Text);

            con.Open();


            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Insertion  Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgridview();
                resetcontrol();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Insertion  Faield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }
    }
}
