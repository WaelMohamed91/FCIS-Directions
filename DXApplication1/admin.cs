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
    public partial class admin : Form
    {
        OracleConnection connection;
        public admin()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            /////////////////// connected (procedure) login admin
            login();
        }
        void login ()
        {
            bool a = false, b = false;
            if (email_text.Text == "")
            {
                MessageBox.Show("Please Enter Your Email .. ","Sorry",MessageBoxButtons.OK,MessageBoxIcon.Error);
                a = true;
            }
            if (password_text.Text == "")
            {
                MessageBox.Show("Please Enter Your PassWord .. ","Sorry",MessageBoxButtons.OK,MessageBoxIcon.Error);
                b = true;
            }

            if (a == false && b == false)
            {
                string string_connection = "Data Source =orcl  ;User Id = hr ; password =hr";
                OracleConnection con = new OracleConnection(string_connection);
                con.Open();

                OracleCommand command = new OracleCommand();
                command.Connection = con;
                command.CommandType = CommandType.StoredProcedure;

                command.CommandText = "login";
                command.Parameters.Add("email", email_text.Text);
                command.Parameters.Add("pass", password_text.Text);
                command.Parameters.Add("bool", OracleDbType.Int32, ParameterDirection.Output);



                try
                {
                    command.ExecuteNonQuery();

                    int x = Convert.ToInt32(command.Parameters["bool"].Value.ToString());
                    if (x != 0)
                    {
                        //MessageBox.Show("Welocme ^_^ ");
                        Login login_form = new Login(email_text.Text);
                        this.Hide();
                        login_form.ShowDialog();

                    }
                }
                catch
                {
                    MessageBox.Show("Not Found !!","Sorry",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }


        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
