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

namespace SchoolManagementSystem
{
    public partial class Transport : MetroForm
    {
        public Transport()
        {

            this.Style = MetroFramework.MetroColorStyle.Yellow;
            this.Theme = MetroFramework.MetroThemeStyle.Default;

            InitializeComponent();
            bindgridview();
            getteacherid();
            getstudentid();
        }
        int i;
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

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
                comboBox3.ValueMember = "teacher_id";
                comboBox3.DataSource = data;
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
                    comboBox2.ValueMember = "admission_id";
                    comboBox2.DataSource = data;
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
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
             }

        void bindgridview()
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "select * from T_transport";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from  transport  where transport_id=@transport_id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@transport_id", i);
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            i = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);//id
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into transport values(@transport_type,@source_name,@destination_name,@admission_id,@teacher_id)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@transport_type", comboBox1.Text);
            cmd.Parameters.AddWithValue("@source_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@destination_name", textBox2.Text);
            cmd.Parameters.AddWithValue("@admission_id", comboBox2.Text);
            cmd.Parameters.AddWithValue("@teacher_id", comboBox3.Text);

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

        private void Transport_Load(object sender, EventArgs e)
        {
           // this.BackColor = Color.Yellow;
            this.button3.BackColor = Color.Yellow;


           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
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
    }
}
