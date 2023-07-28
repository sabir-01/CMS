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
    public partial class accountoffice : MetroForm
    {
        public accountoffice()
        {
            InitializeComponent();
            getadminid();
            bindgridview();
            resetcontrol();
        }
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

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
                comboBox1.ValueMember = "admin_id";
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
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
        void resetcontrol()
        {

            textBox1.Clear();
            textBox2.Clear();
        
            comboBox1.Text = "";



        }

        void bindgridview()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_AccountsOffice";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);

            DataTable data = new DataTable();
            sda.Fill(data);

            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  AccountsOffice  where accounts_office_id=@accounts_office_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@accounts_office_id", i);
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

            if (textBox1.Text!=string.Empty && textBox2.Text != string.Empty && comboBox1.Text != string.Empty)
            {


            SqlConnection con = new SqlConnection(cs);
            string query = "insert into AccountsOffice values(@name,@location,@admin_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@location", textBox2.Text);
            cmd.Parameters.AddWithValue("@admin_id", comboBox1.SelectedValue.ToString());

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
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Plz fill textbox", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update  AccountsOffice set name=@name,location=@location,admin_id=@admin_id where accounts_office_id=@accounts_office_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@accounts_office_id", i);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@location", textBox2.Text);
            cmd.Parameters.AddWithValue("@admin_id", comboBox1.Text);


            con.Open();


            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "UPDATION  Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindgridview();
                resetcontrol();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Updation  Faield", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }
    }

}
