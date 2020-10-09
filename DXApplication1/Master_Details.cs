using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace DXApplication1
{
    public partial class Master_Details : Form
    {
        string Table_choicer;
        string emali;
        public Master_Details(string choic, string mail)
        {
            Table_choicer = choic;
            emali = mail; 

            InitializeComponent();
        }

        private void Master_Details_Load(object sender, EventArgs e)
        {

            string constr = "Data Source =orcl  ;User Id = hr ; password =hr";
            DataSet ds = new DataSet();

            if (Table_choicer == "mang")
            {
                labelControl3.Text = "ManagmentsDetails";
                OracleDataAdapter adapter1 = new OracleDataAdapter("SELECT ADMIN_MAIL from ADMINS", constr);
            adapter1.Fill(ds, "AD");

            OracleDataAdapter adapter2 = new OracleDataAdapter("SELECT * from MANAGMENTS", constr);
            adapter2.Fill(ds, "MANAGMENTS");

            DataRelation r = new DataRelation("fk", ds.Tables[0].Columns["ADMIN_MAIL"],
                                                ds.Tables[1].Columns["ADMIN_MAIL"]);
            ds.Relations.Add(r);

            BindingSource bs_Master = new BindingSource(ds, "AD");
            BindingSource bs_Child = new BindingSource(bs_Master, "fk");

            dataGridView1.DataSource = bs_Master;
            dataGridView2.DataSource = bs_Child;
        }
            else if (Table_choicer == "Doc")
            {
                labelControl3.Text = "Doctors/TAs Details";
                OracleDataAdapter adapter1 = new OracleDataAdapter("SELECT ADMIN_MAIL from ADMINS", constr);
                adapter1.Fill(ds, "AD");

                OracleDataAdapter adapter2 = new OracleDataAdapter("SELECT * from DOCTORS_TAS", constr);
                adapter2.Fill(ds, "Doc");

                DataRelation r = new DataRelation("fk", ds.Tables[0].Columns["ADMIN_MAIL"],
                                                    ds.Tables[1].Columns["ADMIN_MAIL"]);
                ds.Relations.Add(r);

                BindingSource bs_Master = new BindingSource(ds, "AD");
                BindingSource bs_Child = new BindingSource(bs_Master, "fk");

                dataGridView1.DataSource = bs_Master;
                dataGridView2.DataSource = bs_Child;
            }
            else if (Table_choicer == "Dep")
            {
                labelControl3.Text = "Department Details";
                OracleDataAdapter adapter1 = new OracleDataAdapter("SELECT ADMIN_MAIL from ADMINS", constr);
                adapter1.Fill(ds, "AD");

                OracleDataAdapter adapter2 = new OracleDataAdapter("SELECT * from DEPARTMENT", constr);
                adapter2.Fill(ds, "Dep");

                DataRelation r = new DataRelation("fk", ds.Tables[0].Columns["ADMIN_MAIL"],
                                                    ds.Tables[1].Columns["ADMIN_MAIL"]);
                ds.Relations.Add(r);

                BindingSource bs_Master = new BindingSource(ds, "AD");
                BindingSource bs_Child = new BindingSource(bs_Master, "fk");

                dataGridView1.DataSource = bs_Master;
                dataGridView2.DataSource = bs_Child;
            }


        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login main = new Login(emali);
            main.ShowDialog();
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }
    }
}
