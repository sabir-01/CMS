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
using System.Drawing;
using MetroFramework;
using projects;

namespace SchoolManagementSystem
{
    public partial class Admission : MetroForm
    {
        public Admission()
        {
            InitializeComponent();
            bindgridview();


        }
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        void bindgridview()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_Admission";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
          

        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetcontrol();
        }
        void resetcontrol()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Text = "";
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";

        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); //ID
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//name
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//phone
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//date
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();//ADDRES
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString(); //GENDER


            textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();//COURCE
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString(); //USERNAME
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();//PASSWORD
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  Admission  where admission_id=@admission_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@admission_id", i);
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
            string query = "insert into Admission values(@student_name,@phone_number,@admission_date,@address,@gender, @course,@user_name,@password)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@student_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@phone_number", textBox2.Text);
            cmd.Parameters.AddWithValue("@admission_date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@course", textBox4.Text);        
            cmd.Parameters.AddWithValue("@user_name", textBox6.Text);        
            cmd.Parameters.AddWithValue("@password", textBox7.Text);        
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
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update  Admission set student_name=@student_name ,phone_number=@phone_number,admission_date=@admission_date,address=@address,gender=@gender,course=@course ,user_name=@user_name,password=@password where admission_id=@admission_id";
            SqlCommand cmd = new SqlCommand(query, con);        
            con.Open();
            cmd.Parameters.AddWithValue("@admission_id", i);
            cmd.Parameters.AddWithValue("@student_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@phone_number", textBox2.Text);
            cmd.Parameters.AddWithValue("@admission_date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@address", textBox3.Text);
            cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
            cmd.Parameters.AddWithValue("@course", textBox4.Text);
            cmd.Parameters.AddWithValue("@user_name", textBox6.Text);
            cmd.Parameters.AddWithValue("@password", textBox7.Text);

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
    }
}
