using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
namespace DXApplication1
{
    public partial class mainform : DevExpress.XtraEditors.XtraForm
    {
        int mov;
        int movX;
        int movY;
        string connection_string = "Data Source =orcl  ;User Id = hr ; password =hr";
        OracleConnection connection;
        public mainform()
        {
            InitializeComponent();
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            view_name_departments();
            view_name_halls();
            view_names_managements();
            view_name_doctors();
        }
        void view_names_managements()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "select MANAGMENTS_NAME from MANAGMENTS ";

            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                combo_managment.Items.Add(reader[0]);
            }
        }
        void view_name_departments()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DEP_NAMES";
            command.Parameters.Add("rows", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                combo_depart.Items.Add(reader[0]);
            }
        }
        void view_name_halls()
        {
            string command_string = "select HALL_LABS_NAME from HALLS_LABS";
            OracleDataAdapter adapter = new OracleDataAdapter(command_string, connection_string);
            DataSet set = new DataSet();
            adapter.Fill(set);

            //halls_list.DataSource = set.Tables[0];
            //halls_list.DisplayMember = "HALL_LABS_NAME";
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                object obj = set.Tables[0].Rows[i][0];
                combo_hall.Items.Add(obj.ToString());
            }
        }

        private void sidePanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y; 

        }

        private void sidePanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ( mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX , MousePosition.Y - movY);
            }
        }

        private void sidePanel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            admin admin_form = new admin();
            this.Hide();
            admin_form.ShowDialog();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            name.Text = "";
            combo_managment.Text = "";
            combo_hall.Text = "";
            combo_doctors.Text = "";
            combo_depart.Text = "";
            pictureEdit1.Image = Image.FromFile(@"C:\Users\MASHHOUR\Documents\Visual Studio 2015\Projects\DXApplication1\DXApplication1\bin\Debug\FCIS Directions\defaultMap.jpg");
        }
        /////////////////////////////
        string select_location(string name)
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = @"SELECT DEPARTMENT.department_location
                                    FROM DEPARTMENT
                                    where DEPARTMENT.DEPARTMENT_NAME = :name";
            command.CommandType = CommandType.Text;
            command.Parameters.Add("name", name.ToString());
            // command.Parameters.Add("row", OracleDbType.Varchar2, ParameterDirection.Output);

            OracleDataReader reader = command.ExecuteReader();
            //object obj = reader[0].ToString();
            reader.Read();
            string location = reader[0].ToString();
            // MessageBox.Show("loc = " + location);
            return location;
        }

        private void combo_depart_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_hall.Text = "";
            combo_managment.Text = "";
            combo_doctors.Text = ""; 
           string path =  select_location(combo_depart.SelectedItem.ToString());
            pictureEdit1.Image = Image.FromFile(path);
            name.Text = combo_depart.Text;
            
        }
        ///////////////////////////
        string get_location_managments()
        {
            string selected = combo_managment.SelectedItem.ToString();
            //MessageBox.Show(selected);
            string command_string = "select MANAGMENTS_LOCATION from  MANAGMENTS where MANAGMENTS_NAME = :name ";
            OracleDataAdapter adapter;
            adapter = new OracleDataAdapter(command_string, connection_string);
            DataSet set = new DataSet();
            adapter.SelectCommand.Parameters.Add("name", selected);
            adapter.Fill(set);
            object obj = set.Tables[0].Rows[0][0];
            return obj.ToString();
        }
        private void combo_managment_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_depart.Text = "";
            combo_doctors.Text = "";
            combo_hall.Text= "";
            string path = get_location_managments();
            name.Text = combo_managment.Text;
            pictureEdit1.Image = Image.FromFile(path);
        }
        //////////////////////////
        string select_location_halls()
        {
            string selected_hall = combo_hall.SelectedItem.ToString();
            OracleDataAdapter adapter;
            DataSet set = new DataSet();
            string commandstr = "select HALL_LABS_LOCATION from HALLS_LABS where HALL_LABS_NAME = :name";
            adapter = new OracleDataAdapter(commandstr, connection_string);

            // adapter.SelectCommand.Parameters.Add("id", .Text);
            adapter.SelectCommand.Parameters.Add("name", selected_hall);
            adapter.Fill(set);

            object obj = set.Tables[0].Rows[0][0];
            return obj.ToString();
        }
        private void combo_hall_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_doctors.Text = "";
            combo_managment.Text = "";
            combo_depart.Text = "";
            string path = select_location_halls();
            pictureEdit1.Image = Image.FromFile(path);
            name.Text = combo_hall.Text;
        }
        ////////////////////////////
        void view_name_doctors()
        {
           // connection.Open();
            OracleCommand command = new OracleCommand(connection_string);
            command.Connection = connection;
            command.CommandText = "select D_TA_FRISTNAME,D_TA_LASTNAME from DOCTORS_TAS  ";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string frist = reader[0].ToString();
                string last = reader[1].ToString();
                string all = frist + " " + last;
                combo_doctors.Items.Add(all);
            }

        }
        ////////////////////////////
        string select_location_doctors()
        {
            string up_val = combo_doctors.SelectedItem.ToString();
            string[] selected = up_val.Split();
            string Formloc;
            string locat;
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "select D_TA_LOCATION from DOCTORS_TAS where D_TA_FRISTNAME =:name and D_TA_LASTNAME=:lname ";
            command.CommandType = CommandType.Text;
            command.Parameters.Add("name", selected[0]);
            command.Parameters.Add("lname", selected[1]);
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            locat = reader[0].ToString();

            Formloc = locat;

            return Formloc; 
        }
        private void combo_doctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_depart.Text = "";
            combo_hall.Text = "";
            combo_managment.Text = "";
            name.Text = combo_doctors.SelectedItem.ToString();
           string path =  select_location_doctors();
            pictureEdit1.Image = Image.FromFile(path);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sidePanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
