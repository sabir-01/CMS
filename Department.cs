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
    public partial class Department : MetroForm
    {
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;





        public Department()
        {
            InitializeComponent();
            getteacherid();
            getadminid();
            bindgridview();
        }


        private void getteacherid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);

                con.Open();
                SqlCommand cmd = new SqlCommand("Select teacher_id from Teacher", con);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("teacher_id", typeof(int));
                data.Load(Reader);
                teachercb.ValueMember = "teacher_id";
                teachercb.DataSource = data;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "college Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getadminid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);

                con.Open();
                SqlCommand cmd = new SqlCommand("Select admin_id from Admins", con);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("admin_id", typeof(int));
                data.Load(Reader);
                admincb.ValueMember = "admin_id";
                admincb.DataSource = data;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "college Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            teachercb.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            admincb.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Branch values(@branch_name,@location,@hod_id,@total_students,@established_date,@teacher_id,@admin_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@branch_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@location", textBox2.Text);
            cmd.Parameters.AddWithValue("@hod_id", comboBox2.Text);
            cmd.Parameters.AddWithValue("@total_students", textBox3.Text);
            cmd.Parameters.AddWithValue("@established_date", textBox4.Text);
            cmd.Parameters.AddWithValue("@teacher_id", teachercb.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@admin_id", admincb.SelectedValue.ToString());

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
        void resetcontrol()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update  Branch set branch_name=@branch_name,location=@location,hod_id=@hod_id,total_students=@total_students,established_date=@established_date where branch_id=@branch_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@branch_id", i);
            cmd.Parameters.AddWithValue("@branch_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@location", textBox2.Text);
            cmd.Parameters.AddWithValue("@hod_id", comboBox2.Text);
            cmd.Parameters.AddWithValue("@total_students", textBox3.Text);
            cmd.Parameters.AddWithValue("@established_date", textBox4.Text);
            cmd.Parameters.AddWithValue("@teacher_id", teachercb.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@admin_id", admincb.SelectedValue.ToString());

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
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  Branch  where branch_id=@branch_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@branch_id", i);
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
        void bindgridview()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_Branch";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher();
            t.Show();
            this.Hide();
        }
    }
}
