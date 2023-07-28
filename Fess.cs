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
    public partial class Fess : MetroForm
    {
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Fess()
        {
            InitializeComponent();
            getadminid();            
            getstudentid();
            bindgridview();
            resetcontrol();


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
                comboBox2.ValueMember = "admin_id";
                comboBox2.DataSource = data;
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
                    comboBox1.ValueMember = "admission_id";
                    comboBox1.DataSource = data;
                    con.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "college Management System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            void resetcontrol()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            dateTimePicker1.Text = "";
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";



        }

        void bindgridview()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from E_Fee";
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
            string query = "delete from  Fee  where fee_id=@fee_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fee_id", i);
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
            string query = "update  Fee set  amount=@amount,payment_date=@payment_date,payment_status=@payment_status,fee_type=@fee_type,admission_id=@admission_id,@admin_id=@admin_id where fee_id=@fee_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@fee_id",        i);
            cmd.Parameters.AddWithValue("@amount",           textBox4.Text);
            cmd.Parameters.AddWithValue("@payment_date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@payment_status",   textBox2.Text);
            cmd.Parameters.AddWithValue("@fee_type",         textBox1.Text);
            cmd.Parameters.AddWithValue("@admission_id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@admin_id", comboBox2.Text);


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
            string query = "insert into Fee values(@amount,@payment_date,@payment_status,@fee_type,@admission_id,@admin_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@amount",         textBox4.Text);
            cmd.Parameters.AddWithValue("@payment_date", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@payment_status", textBox2.Text);
            cmd.Parameters.AddWithValue("@fee_type",       textBox1.Text);
            cmd.Parameters.AddWithValue("@admission_id",     comboBox1.Text);
            cmd.Parameters.AddWithValue("@admin_id",       comboBox2.SelectedValue.ToString());

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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            i = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }
    }
}
