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
using projects;

namespace SchoolManagementSystem
{
    public partial class studentdashboard : MetroForm
    {
        int id;
        public studentdashboard()
        {
            InitializeComponent();
          //  showstudentsubject();
            this.id = id;
            //showStudent();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        //void showStudent()
        //{
        //    label1.Text = "Student Name";
        //    label2.Text = "Student Age";
        //    label3.Text = "Student Gender";
        //    label4.Text = "Student Email";
        //    label5.Text = "Phone Number";
        //    label6.Text = "Branch ID";
        //    label7.Text = "Teacher ID";

        //    SqlConnection con = new SqlConnection(cs);
        //    string query = "select * from Admission ";
        //    SqlDataAdapter sda = new SqlDataAdapter(query, con);

        //    DataTable data = new DataTable();
        //    sda.Fill(data);

        //    foreach (DataRow row in data.Rows)
        //    {
        //        textBox1.Text = row[1].ToString(); //Name
        //        textBox2.Text = row[2].ToString(); 
        //        textBox3.Text = row[4].ToString(); 
        //        textBox4.Text = row[5].ToString(); 
        //        textBox5.Text = row[3].ToString(); 
        //        textBox6.Text = row[6].ToString(); 
        //        textBox7.Text = row[7].ToString();
        //        break;
        //    }                     
        //}


        void showstudentsubject()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from s_Subject";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }
        void showfees()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_Fee";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnshowsubject_Click(object sender, EventArgs e)
        {
            showstudentsubject();
           
        }

        private void btnshowfees_Click(object sender, EventArgs e)
        {
            showfees();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            libraryinformation();
        }
        void libraryinformation()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from v_library";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        void attendanceinformation()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_Attendance";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            attendanceinformation();
        }


    }
}
