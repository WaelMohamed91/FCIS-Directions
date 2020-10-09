using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class Reportform : Form
    {
        string chooser;
        Managment Cr;
     //   Dep_Report Dp_cr;
      //  Lap_Report1 Lab_cr;
       // DocReport1 Doc_cr;
        public Reportform(string choose)
        {
            chooser = choose; 
            InitializeComponent();
        }

        private void Reportform_Load(object sender, EventArgs e)
        {
         /*   if (chooser == "mang")
            {
                Cr = new Managment();
                crystalReportViewer1.ReportSource = Cr;
                labelControl2.Text = " Managment Report";
            }
            else if (chooser == "Dep")
            {
                Dp_cr = new Dep_Report();
                crystalReportViewer1.ReportSource = Dp_cr;
                labelControl2.Text = " Department Report";
            }

            else if (chooser == "Lab")
            {
                Lab_cr = new Lap_Report1();
                crystalReportViewer1.ReportSource = Lab_cr;
                labelControl2.Text = " Halls/Labs Report";
            }
            else if (chooser == "Doc")
            {
                Doc_cr = new DocReport1();
                crystalReportViewer1.ReportSource = Doc_cr;
                labelControl2.Text = " Doctors/TAs Report";
            }
            */

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
