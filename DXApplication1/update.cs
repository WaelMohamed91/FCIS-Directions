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
   
    public partial class update : Form
    {
        string connection_string = "Data Source =orcl  ;User Id = hr ; password =hr";

        OracleConnection connection;
        string update_chooser;
        string update_name;
        string update_location;
        string admin_email;
        public update(string chooser , string name  , string location , string email)
        {
            update_name = name;
            update_location = location;
            update_chooser = chooser;
            admin_email = email;
            InitializeComponent();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            bool a = false, b = false;
           if (text_location.Text == "")
            {
                MessageBox.Show("Please Fill Location Field ..","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                a = true;
            }
            else if (text_name.Text == "")
            {
                MessageBox.Show("Please Fill Name Field ..","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                b = true;
            }
            if (a == false && b == false )
            {
                if (update_chooser == "dep")
                    update_dep();
                if (update_chooser == "hall")
                    update_halls();
                if (update_chooser == "update_man")
                    update_managments();
                if(update_chooser=="Doc")
                    update_Doctor();
            }
            text_name.Text = "";
            text_location.Text = "";
            txt_lastname.Text = "";
            picture_box.Image = null;
        }
       void update_managments()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = @"update MANAGMENTS
                                set MANAGMENTS.MANAGMENTS_NAME = :name , MANAGMENTS.MANAGMENTS_LOCATION = :location , MANAGMENTS.ADMIN_MAIL = :email
                                where MANAGMENTS.MANAGMENTS_NAME = :name2";
            command.Parameters.Add("name", text_name.Text);
            command.Parameters.Add("location", text_location.Text);
            command.Parameters.Add("email", admin_email);
            command.Parameters.Add("name2", text_name.Text);
            int test = command.ExecuteNonQuery();
            if (test != -1)
            {
                MessageBox.Show("Managment Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        void update_dep ()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DEP_UPDATE";
            command.Parameters.Add("name" , text_name.Text);
            command.Parameters.Add("location" , text_location.Text);
            command.Parameters.Add("email" , admin_email);

            int test = command.ExecuteNonQuery();
            if (test == -1)
            {
                MessageBox.Show("Department Updated !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

          void update_halls()
        {
          
                OracleDataAdapter adapter;
                DataSet set = new DataSet();
                string str = "select * from HALLS_LABS ";
                adapter = new OracleDataAdapter(str, connection_string);
                adapter.Fill(set, "halls");


                string update = @"update HALLS_LABS
                            set HALLS_LABS.HALL_LABS_LOCATION = :location,HALLS_LABS.ADMIN_MAIL=:mail 
                           where HALLS_LABS.HALL_LABS_NAME = :name2";
                adapter = new OracleDataAdapter(update, connection_string);
                adapter.SelectCommand.Parameters.Add("location", text_location.Text);
                adapter.SelectCommand.Parameters.Add("mail", admin_email);
                adapter.SelectCommand.Parameters.Add("name2", text_name.Text);
                adapter.Fill(set, "halls");
                OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
                adapter.Update(set, "halls");
                MessageBox.Show("Updated ^_^", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
   

        }

        
        void Doctor_Fillcontrol()
        {
            //Image file;

            string[] txtname = update_name.Split();
            text_name.Text = txtname[0];
            text_name.Enabled = false;
            txt_lastname.Enabled = false;
            txt_lastname.Text = txtname[1];
            text_location.Text = update_location;
            Image image = Image.FromFile(text_location.Text);
            this.picture_box.Image = image;
        }

        void update_Doctor()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "update DOCTORS_TAS set D_TA_LOCATION=:locn, ADMIN_MAIL =:admin where D_TA_FRISTNAME =:name and D_TA_LASTNAME=:lname";
            command.CommandType = CommandType.Text;
            command.Parameters.Add("locn", text_location.Text);
            command.Parameters.Add("admin", admin_email);
            command.Parameters.Add("name", text_name.Text);
            command.Parameters.Add("lname", txt_lastname.Text);

            int test = command.ExecuteNonQuery();
            if (test != -1)
            {
                MessageBox.Show("Update Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
        }

        private void update_Load(object sender, EventArgs e)
        {
            if (update_chooser == "Doc")
            {
                txt_lastname.Visible = true;
                label_last.Visible = true;
                Doctor_Fillcontrol();
            }

            else
            {
                text_name.Text = update_name;
                text_location.Text = update_location;
                picture_box.Image = Image.FromFile(update_location);
            }
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

                picture_box.Image = Image.FromFile(f.FileName);
            }
           // button8.Enabled = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log_form = new Login(admin_email);
            log_form.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
