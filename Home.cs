using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

     
     
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Department d = new Department();
            d.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Attendance a = new Attendance();
            a.Show();
            this.Hide();

        }



        private void pictureBox5_Click(object sender, EventArgs e)
        {
            subject s = new subject();
            this.Hide();
            s.Show();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Teacher t = new Teacher();
            t.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

            Admission st = new Admission();
            st.Show();
            this.Hide();
        }

      

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            @class c = new @class();
            c.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ADMIN a = new ADMIN();
            a.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Library l = new Library();
            l.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Fess f = new Fess();
            f.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            accountoffice a = new accountoffice();
            a.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Transport t = new Transport();
            t.Show();
            this.Hide();
        }
    }
}
