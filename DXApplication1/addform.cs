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
    public partial class addform : Form
    {
        string connection_string = "Data Source =orcl  ;User Id = hr ; password =hr";
        OracleConnection connection;
        string email;
        string chooser; 

        public addform(string admin_email , string choose)
        {
            email = admin_email;
            chooser = choose; 
            InitializeComponent();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            bool a = false, b = false; 
            if (text_name.Text == "")
            {
                MessageBox.Show("Please Fill The Name Field !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                a = true;

            }
            else if (text_location.Text == "")
            {
                MessageBox.Show("Please Fill The Location Field !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                b = true;
            }

            else if (a == false && b == false )
            {
                
                try
                {
                    if (chooser == "dep")
                    {
                        add_departments();
                    }
                    if (chooser == "addhall")
                    {
                        addhalls();
                    }
                    if (chooser == "addman")
                    {
                        add_managments();
                    }

                    if (chooser == "addDoc")
                    {
                        add_Doctor();
                    }
                    
                }
                catch
                {
                    MessageBox.Show("This Name Oready Exist !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                text_name.Text = "";
                text_location.Text = "";
                txt_lastname.Text = "";
                pictureBox1.Image = null;
            }

        }
        void add_managments ()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "insert into MANAGMENTS values (:name,:location,:email)";
            command.CommandType = CommandType.Text;

            command.Parameters.Add("name", text_name.Text.ToString());
            command.Parameters.Add("location", text_location.Text.ToString());
            command.Parameters.Add("email",email);

            int i = command.ExecuteNonQuery();
            if (i != -1)
            {
                MessageBox.Show("Managments Added ^_^", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
        
        void add_departments()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "dep_insert ";
            command.CommandType = CommandType.StoredProcedure;

           // command.Parameters.Add("id", Convert.ToInt32(comboBox1.Text));
            command.Parameters.Add("name", text_name.Text.ToString());
            command.Parameters.Add("location", text_location.Text.ToString());
            //command.Parameters.Add("head", textBox3.Text.ToString());
            command.Parameters.Add("email", email);
            int test; 
            test = command.ExecuteNonQuery();
            if (test == -1 )
            {
                MessageBox.Show("Department Added ^_^ ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        void add_Doctor()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "doc_insert ";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("location", text_location.Text.ToString());
            command.Parameters.Add("f_name", text_name.Text.ToString());
            command.Parameters.Add("L_name", txt_lastname.Text.ToString());
            command.Parameters.Add("A_mail", email);
            int retn = command.ExecuteNonQuery();
            if (retn == -1)
            {
                MessageBox.Show("ADD Doctor Successfully ^_^ ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }


        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login_form = new Login(email);
            login_form.ShowDialog();
        }
        
        void addhalls ()
        {
            OracleDataAdapter adapter;
            DataSet set = new DataSet();
            string commandstr = "insert into halls_labs values (:name , :location , :admin)";
            adapter = new OracleDataAdapter(commandstr, connection_string);

           // adapter.SelectCommand.Parameters.Add("id", .Text);
            adapter.SelectCommand.Parameters.Add("name", text_name.Text);
            adapter.SelectCommand.Parameters.Add("location", text_location.Text);
            adapter.SelectCommand.Parameters.Add("admin", email);

            adapter.Fill(set);

            MessageBox.Show("Halls / Labs  Added Successfly ^_^ ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Image File;
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "jpg files(*.jpg)|*.jpg";
            if (f.ShowDialog() == DialogResult.OK)
            {
                File = Image.FromFile(f.FileName);
                text_location.Text = f.FileName;
                pictureBox1.Image = Image.FromFile(f.FileName);
                // pictureBox1.Image = File;
            }
           // button8.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void addform_Load(object sender, EventArgs e)
        {
            if (chooser == "addDoc")
            {
                txt_lastname.Visible = true;
                label_last.Visible = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
