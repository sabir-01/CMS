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
    public partial class Teacherdashboard : MetroForm
    {
        public Teacherdashboard()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            Admission s = new Admission();
            s.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            subject s = new subject();
            s.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Attendance a = new Attendance();
            a.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            @class c = new @class();
            c.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Department d = new Department();
            d.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
