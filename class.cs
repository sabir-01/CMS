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

    public partial class @class : MetroForm
    {
        public @class()
        {
            InitializeComponent();
          
            bindgridview();
            getteacherid();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        int i;
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
                comboBox1.ValueMember = "teacher_id";
                comboBox1.DataSource = data;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "college Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void getbranchid()
        {
            try
            {
                SqlConnection con = new SqlConnection(cs);

                con.Open();
                SqlCommand cmd = new SqlCommand("Select branch_id from Branch", con);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("branch_id", typeof(int));
                data.Load(Reader);
                comboBox1.ValueMember = "branch_id";
                comboBox1.DataSource = data;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "college Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  class  where class_id=@class_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@class_id", i);
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
            string query = "insert into class values(@class_name,@department,@start_time,@end_time,@teacher_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@class_name", textBox4.Text);
            cmd.Parameters.AddWithValue("@department", textBox3.Text);
            cmd.Parameters.AddWithValue("@start_time", DateTime.Now.ToString("hh:mm:ss tt"));
            cmd.Parameters.AddWithValue("@end_time",textBox1.Text);
            cmd.Parameters.AddWithValue("@teacher_id", comboBox1.SelectedValue.ToString());


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
            comboBox1.Text = "";
            textBox4.Clear();
          

        }

        void bindgridview()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_Class";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bindgridview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update  class set @class_name=class_name,@department=department,@start_time=start_time,@end_time=end_time,@teacher_id=@teacher_id where class_id=class_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@class_id", i);
            cmd.Parameters.AddWithValue("@class_name", textBox4.Text);
            cmd.Parameters.AddWithValue("@department", textBox3.Text);
            cmd.Parameters.AddWithValue("@start_time", textBox2.Text);
            cmd.Parameters.AddWithValue("@end_time", textBox1.Text);
            cmd.Parameters.AddWithValue("@teacher_id", comboBox1.Text);



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

        private void button5_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher();
            t.Show();
            this.Hide();
        }
    } 
}
