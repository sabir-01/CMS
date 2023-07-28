using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using projects;

namespace SchoolManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new DSAProject.splash());
            //Application.Run(new DSAProject.SINGUP());
       //   Application.Run(new Userlogin());

        }
    }
}
