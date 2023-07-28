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
    public partial class Attendance : MetroForm
    {
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Attendance()
        {
            InitializeComponent();
            getstudentid();
            getclassid();
            bindgridview();
            getteacherid();


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
                comboBox4.ValueMember = "teacher_id";
                comboBox4.DataSource = data;
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "college Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void getstudentid()
        {
            try
                {
                    SqlConnection con = new SqlConnection(cs);
                    con.Open();
                    SqlCommand cmd = new SqlCommand("Select admission_id from Admission", con);
                    SqlDataReader Reader = cmd.ExecuteReader();
                    DataTable data = new DataTable();
                    data.Columns.Add("admission_id", typeof(int));
                    data.Load(Reader);
                    comboBox3.ValueMember = "admission_id";
                    comboBox3.DataSource = data;
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "college Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
        }
            private void getclassid()
            {
            try
            {
                SqlConnection con = new SqlConnection(cs);           
                con.Open();
                SqlCommand cmd = new SqlCommand("Select class_id from Class", con);
                SqlDataReader Reader = cmd.ExecuteReader();
                DataTable data = new DataTable();
                data.Columns.Add("class_id", typeof(int));
                data.Load(Reader);
                comboBox1.ValueMember = "class_id";
                comboBox1.DataSource = data;
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
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            metroDateTime1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();           
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }
        void resetcontrol()
        {
            metroDateTime1.Value = DateTime.Now;
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
        }
        void bindgridview()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_Attendance";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  Attendance  where attendance_id=@attendance_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@attendance_id", i);
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update  Attendance set class_id=@class_id,date=@date,status=@status,admission_id=@admission_id,teacher_id=@teacher_id where attendance_id=@attendance_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@attendance_id", i);
            cmd.Parameters.AddWithValue("@class_id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", metroDateTime1.Value);
            cmd.Parameters.AddWithValue("@status", comboBox2.Text);
            cmd.Parameters.AddWithValue("@admission_id", comboBox3.Text);         
            cmd.Parameters.AddWithValue("@teacher_id", comboBox4.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into Attendance values(@class_id,@date,@status,@admission_id,@teacher_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@class_id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@date", metroDateTime1.Value);
            cmd.Parameters.AddWithValue("@status", comboBox2.Text);
            cmd.Parameters.AddWithValue("@admission_id", comboBox3.Text);
      
            cmd.Parameters.AddWithValue("@teacher_id", comboBox4.Text);

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

        private void button5_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher();
            t.Show();
            this.Hide();
        }
    }
}
