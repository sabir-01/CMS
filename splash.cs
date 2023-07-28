using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using SchoolManagementSystem;
using projects;

namespace DSAProject
{
    public partial class splash : Form
    {
        List<Color> colors = new List<Color>();

        public splash()
        {
            colors.Add(Color.FromArgb(0, 158, 71));
            colors.Add(Color.FromArgb(112, 191, 83));
            colors.Add(Color.FromArgb(216, 155, 40));
            colors.Add(Color.FromArgb(217, 102, 42));
            colors.Add(Color.FromArgb(217, 102, 42));
            colors.Add(Color.FromArgb(235, 83, 104));
            colors.Add(Color.FromArgb(223, 128, 255));
            colors.Add(Color.FromArgb(112, 48, 160));
            colors.Add(Color.FromArgb(107, 122, 187));
            colors.Add(Color.FromArgb(95, 136, 176));
            colors.Add(Color.FromArgb(70, 175, 227));
            colors.Add(Color.FromArgb(0, 158, 71));
            InitializeComponent();
        }
        int curcolor = 0;
        int loop = 0;

        private void fader_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (curcolor < colors.Count - 1)
            {
              
               //this.BackColor = Bunifu.Framework.UI.BunifuColorTransition.getColorScale(loop, colors[curcolor], colors[curcolor + 1]);
                if (loop < 50)
                {
                    loop++;
                }
                else
                {
                    loop = 0;
                    curcolor++;
                }
                timer1.Enabled = true;
            }
            else
            {
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }


        }
    }
}
