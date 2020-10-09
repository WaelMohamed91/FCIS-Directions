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
using CrystalDecisions.Shared;
namespace DXApplication1
{
    public partial class Login : Form
    {
     //   Param_Manag_Report1 M_cr;
       // Param_DoctorReport D_cr;
        int mov;
        int movX;
        int movY;
        string connection_string = "Data Source =orcl  ;User Id = hr ; password =hr";
        OracleConnection connection;
        string admin_email;
        string name;
        string location;
        public Login(string email_admin)
        {
            admin_email = email_admin; 
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            dep_list.Items.Clear();
            Doc_list.Items.Clear();
            view_name_departments();
            view_name_halls();
            view_names_managements();
            Doc_name();
         //   M_cr = new Param_Manag_Report1();
           // D_cr=new Param_DoctorReport();
            //foreach (ParameterDiscreteValue v in M_cr.ParameterFields[0].DefaultValues)
           // {
           //     Admin_cmb.Items.Add(v.Value);
            //}
           
           

        }
       
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        ///////////////////////////////////////////////////////Department////////////////////////////////////////////
        
        //load Department name 
        private void tabNavigationPage2_Paint(object sender, PaintEventArgs e)
        {
            view_name_departments();
        }
        
        //Function view Department
        void view_name_departments ()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DEP_NAMES";
            command.Parameters.Add("rows", OracleDbType.RefCursor, ParameterDirection.Output);

            OracleDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                dep_list.Items.Add(reader[0]);
            }
        }

        ////////button search Department
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //////////////////////// search by name (connected)(departments)
            update_dep_button.Enabled = false;
            simpleButton4.Enabled = false;
            search_name();
        }


        ///////Function Department Search
        void search_name ()
        {
            dep_list.Items.Clear();
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "select  DEPARTMENT_NAME from DEPARTMENT where DEPARTMENT_NAME = :name";
            command.CommandType = CommandType.Text;
            command.Parameters.Add("name" , name_box.Text);
            OracleDataReader reader = command.ExecuteReader();
            if (reader == null || !reader.HasRows)
            {
                MessageBox.Show("Don't have This", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while (reader.Read())
                {
                    dep_list.Items.Add(reader[0]);
                }
            }
        }

        // Button To Add form Depart
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            addform add = new addform(admin_email, "dep");
            this.Hide();
            add.ShowDialog();
        }

        //Button To Update form Depart
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            name = dep_list.SelectedItem.ToString();
            this.Hide();
            update update_form = new update("dep", name, select_location(name), admin_email);
            update_form.ShowDialog();
        }

        //location for update Depart
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
            OracleDataReader reader = command.ExecuteReader();
            reader.Read();
            string location = reader[0].ToString();
            return location;
        }

      
        //select Department to update or delete
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_dep_button.Enabled = true;
            simpleButton4.Enabled = true;
        }

        //Button Delete Department
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are You Sure You Want To Delete ?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            // MessageBox.Show("selected = " + str)
            if (Res == DialogResult.OK)
            {
                delete_departments();
            }

        }
        
        // Function Delete Depart 
        void delete_departments()
        {
            string name_dep = dep_list.SelectedItem.ToString();
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "dep_delete ";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("name", name_dep);
            int test = command.ExecuteNonQuery();
            if (test == -1)
            {
                MessageBox.Show("Department Deleted ..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dep_list.Items.Remove(name_dep);
            }

        }
      //Master Details Department 
        private void Dep_Details_Click(object sender, EventArgs e)
        {
            Master_Details obj = new Master_Details("Dep", admin_email);
            this.Hide();
            obj.ShowDialog();
        }
        //Department report
        private void print_dep_Click(object sender, EventArgs e)
        {

            Reportform report_form = new Reportform("Dep");
            // this.Hide();
            report_form.ShowDialog();
        }

        
        /// ////////////////////////////////////////////////// EndDepartment////////////////////////
        
       //////////////////////////////////////////////Start Managment///////////////////////////////////
        
        //button to seach mangment
        private void simpleButton12_Click(object sender, EventArgs e)
        {
            search_name_man();
            simpleButton9.Enabled=false;
            simpleButton11.Enabled = false;
        }

        ////search for managments
        void search_name_man()
        {
            ////////////// search proc (connected)
                connection = new OracleConnection(connection_string);
                connection.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "search_managments";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("name", man_text.Text.ToString());

                command.Parameters.Add("cursor", OracleDbType.RefCursor, ParameterDirection.Output);

                OracleDataReader reader = command.ExecuteReader();
                if (reader == null || !reader.HasRows)
                {
                    MessageBox.Show("Don't have This", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    man_list.Items.Clear();
                    while (reader.Read())
                    {
                        man_list.Items.Add(reader[0]);
                    }
                }

           
        }

      //button to add form for managment
        private void simpleButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            addform add = new addform(admin_email , "addman");
            add.ShowDialog();
        }

        //Button to Update form for managment
        private void simpleButton11_Click(object sender, EventArgs e)
        {
            this.Hide();
            string name_managments = man_list.SelectedItem.ToString();
            string location_managments = get_location_managments();
            update update_form = new update("update_man", name_managments, location_managments, admin_email);
            update_form.ShowDialog();
        }
       
        //Function select location for upadate managment
        string get_location_managments()
        {
            string selected = man_list.SelectedItem.ToString();
            string command_string = "select MANAGMENTS_LOCATION from  MANAGMENTS where MANAGMENTS_NAME = :name ";
            OracleDataAdapter adapter;
            adapter = new OracleDataAdapter(command_string, connection_string);
            DataSet set = new DataSet();
            adapter.SelectCommand.Parameters.Add("name", selected);
            adapter.Fill(set);
            object obj = set.Tables[0].Rows[0][0];
            return obj.ToString();
        }
        
        // Button for Delete Managment
        private void simpleButton9_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are You Sure You Want To Delete ?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Res == DialogResult.OK)
            {
                delete_man();
            }

        }
       
        //function Delete Managment
        void delete_man()
        {
            string selected = man_list.SelectedItem.ToString();
            string command_string = "delete from  MANAGMENTS where MANAGMENTS_NAME = :name ";
            OracleDataAdapter adapter;
            adapter = new OracleDataAdapter(command_string, connection_string);
            DataSet set = new DataSet();
            adapter.SelectCommand.Parameters.Add("name", selected);
            adapter.Fill(set);
            MessageBox.Show("deleted succeccfuly","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            man_list.Items.Remove(selected);
        }
       
      //load managment in list
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
                man_list.Items.Add(reader[0]);
            }
        }


        //Master Details Managmente 
        private void Details__Click(object sender, EventArgs e)
        {
            Master_Details obj = new Master_Details("mang", admin_email);
            this.Hide();
            obj.ShowDialog();
        }

        //Manage list
        private void man_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            simpleButton11.Enabled = true;
            simpleButton9.Enabled = true;

        }

        //managment report
        private void Report_manag_Click(object sender, EventArgs e)
        {

            Reportform report_form = new Reportform("mang");
            //this.Hide();
            report_form.ShowDialog();
        }

        /////////////////////////////////////////////////////////End managments/////////////////////////////////////
       
        private void tabNavigationPage5_Paint(object sender, PaintEventArgs e)
        {

        }
       ///////////////////////////////////////////////Start Labs/Halls////////////////////////
        //report lab
        private void Report_lab_Click(object sender, EventArgs e)
        {

            Reportform report_form = new Reportform("Lab");
            //this.Hide();
            report_form.ShowDialog();
        }
        
        //Button search for  halls/labs
        private void search_button_Click(object sender, EventArgs e)
        {
            simpleButton13.Enabled = false;
            simpleButton2.Enabled = false;
            select_hall_name();
        }

        private void tabPane4_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
         ///////////load labs/hall name to display in list
          void view_name_halls ()
        {
            string command_string = "select HALL_LABS_NAME from HALLS_LABS";
            OracleDataAdapter adapter = new OracleDataAdapter(command_string, connection_string);
            DataSet set = new DataSet();
            adapter.Fill(set);
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                object obj = set.Tables[0].Rows[i][0];
                halls_list.Items.Add(obj.ToString());
            }
        }
        
        //Button to Delete Halls/labs
        private void simpleButton13_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are You Sure You Want To Delete ?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Res == DialogResult.OK)
            {
                delete_hall();
            }
          
        }

        //Function Deleete halls/labs
        void delete_hall ()
        {

            string selected = halls_list.SelectedItem.ToString();
            string command_string = "delete from  HALLS_LABS where HALL_LABS_NAME = :name ";
            OracleDataAdapter adapter;
            adapter = new OracleDataAdapter(command_string, connection_string);
            DataSet set = new DataSet();
            adapter.SelectCommand.Parameters.Add("name",selected);
            adapter.Fill(set);

            halls_list.Items.Remove(selected);
        }

        //Button to open add form for labs/halls
        private void simpleButton14_Click(object sender, EventArgs e)
        {
            this.Hide();
            addform add = new addform(admin_email , "addhall");
            add.ShowDialog();

        }

        //Button to open Update form for labs/halls
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            string selected_hall = halls_list.SelectedItem.ToString();
            OracleDataAdapter adapter;
            DataSet set = new DataSet();
            string commandstr = "select HALL_LABS_LOCATION from HALLS_LABS where HALL_LABS_NAME = :name";
            adapter = new OracleDataAdapter(commandstr, connection_string);
            adapter.SelectCommand.Parameters.Add("name", selected_hall);
            adapter.Fill(set);

            object obj = set.Tables[0].Rows[0][0];
            update up = new update("hall", selected_hall , obj.ToString() , admin_email );
            this.Hide();
            up.ShowDialog();

        }

        //selecte hall location for form update
        void select_hall_name()
        {
            string command_string = "select HALL_LABS_NAME from HALLS_LABS where HALL_LABS_NAME = :name";
            OracleDataAdapter adapter = new OracleDataAdapter(command_string, connection_string);
            DataSet set = new DataSet();
            adapter.SelectCommand.Parameters.Add("name", text_hall.Text);
            adapter.Fill(set);
            if (set.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Sorry this not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                halls_list.DataSource = set.Tables[0];
                halls_list.DisplayMember = "HALL_LABS_NAME";
            }
        }
        //Hall list
        private void halls_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            simpleButton2.Enabled = true;
            simpleButton13.Enabled = true;
        }
       
        ////////////////////////////////////////////////End Labs/Halls///////////////////////////////////////////

        private void label4_Click(object sender, EventArgs e)
        {

        }

        

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void sidePanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void sidePanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void sidePanel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
        //Doctor
        private void tabPane1_Click(object sender, EventArgs e)
        {
            Doc_list.Items.Clear();
            dep_list.Items.Clear();
            man_list.Items.Clear();
            halls_list.Items.Clear();
            view_name_departments();
            view_name_halls();
            view_names_managements();
            Doc_name();

           
           
        }
     ////////////////////////////////////////Start Doctors//////////////////////////
        //
        void Doc_name()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            OracleCommand command = new OracleCommand();
            command.Connection = connection;
            command.CommandText = "select D_TA_FRISTNAME,D_TA_LASTNAME from DOCTORS_TAS  ";
            command.CommandType = CommandType.Text;
            OracleDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string frist = reader[0].ToString();
                string last = reader[1].ToString();
                string all = frist + " " + last;
                Doc_list.Items.Add(all);
            }

        }

        void searchDoctor_name()
        {
            connection = new OracleConnection(connection_string);
            connection.Open();
            Doc_list.Items.Clear();

            string x =txt_doc.Text;
            string[] name = x.Split();
            if (name.Length == 1)
            {
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "select D_TA_FRISTNAME,D_TA_LASTNAME from DOCTORS_TAS where D_TA_FRISTNAME =:name";
                command.CommandType = CommandType.Text;
                command.Parameters.Add("name", name[0]);
                OracleDataReader reader = command.ExecuteReader();
                if (reader == null || !reader.HasRows)
                {
                    MessageBox.Show("Don't have This", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    while (reader.Read())
                    {
                        string frist = reader[0].ToString();
                        string last = reader[1].ToString();
                        string all = frist + " " + last;
                        Doc_list.Items.Add(all);
                    }
                }
            }
            else if (name.Length == 2)
            {
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "select  D_TA_FRISTNAME,D_TA_LASTNAME from DOCTORS_TAS where D_TA_FRISTNAME =:name and D_TA_LASTNAME=:lname ";
                command.CommandType = CommandType.Text;
                command.Parameters.Add("name", name[0]);
                command.Parameters.Add("lname", name[1]);
                OracleDataReader reader = command.ExecuteReader();
                if (reader == null || !reader.HasRows)
                {
                    MessageBox.Show("Don't have This", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    while (reader.Read())
                    {
                        string frist = reader[0].ToString();
                        string last = reader[1].ToString();
                        string all = frist + " " + last;
                        Doc_list.Items.Add(all);
                    }
                }
            }
            else
                MessageBox.Show("Don't have This", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void Doc_search_Click(object sender, EventArgs e)
        {

            searchDoctor_name();
            Update_Doc.Enabled = false;
            del_Doc.Enabled = false;
            //Doc_list.Items.Clear();
        }

        //Delete Doc
        private void del_Doc_Click(object sender, EventArgs e)
        {
            DialogResult Res = MessageBox.Show("Are You Sure You Want To Delete ?", "Caution", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            string Del_val = Doc_list.SelectedItem.ToString();
            string[] selected = Del_val.Split();
            if (Res == DialogResult.OK)
            {
                connection = new OracleConnection(connection_string);
                connection.Open();
                OracleCommand command = new OracleCommand();
                command.Connection = connection;
                command.CommandText = "Delete from DOCTORS_TAS where D_TA_FRISTNAME =:name and D_TA_LASTNAME=:lname ";
                command.CommandType = CommandType.Text;
                command.Parameters.Add("name", selected[0]);
                command.Parameters.Add("lname", selected[1]);
                int test = command.ExecuteNonQuery();
                if (test == -1)
                {
                    MessageBox.Show("Delete Successfully ^_^ ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Doc_list.Items.Clear();
                Doc_name();
            }
        }

        private void Add_Doc_Click(object sender, EventArgs e)
        {
            addform add_form = new addform(admin_email, "addDoc");
            this.Hide();
            add_form.ShowDialog();
        }

        private void Doc_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Update_Doc.Enabled = true;
            del_Doc.Enabled = true;
        }

        //update connection
        private void Update_Doc_Click(object sender, EventArgs e)
        {

            string up_val = Doc_list.SelectedItem.ToString();
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
            update up_form = new update("Doc", up_val,Formloc,admin_email);
            this.Hide();
            up_form.ShowDialog();
       
        }
        //Master Details Doctor
        private void Doc_Details_Click(object sender, EventArgs e)
        {
            Master_Details obj = new Master_Details("Doc", admin_email);
            this.Hide();
            obj.ShowDialog();
        }

        //Doctor report
        private void simpleButton17_Click(object sender, EventArgs e)
        {
            Reportform report_form = new Reportform("Doc");
            //this.Hide();
            report_form.ShowDialog();
        }
        ////////////////////////////////////end Doctor////////////////////////////////////////////////

        
        //Home
        private void simpleButton18_Click(object sender, EventArgs e)
        {
           this.Hide();
            mainform main = new mainform();
            main.ShowDialog();
        }

       /// ///////////////////////Report Parameter/////////////////
        private void par_report_Click(object sender, EventArgs e)
        {
            if (combo_table.Text == "Managments")
            {
                if (Admin_cmb.Text != "")
                {
                    //M_cr.SetParameterValue(0, Admin_cmb.Text);
                   // crystalReportViewer1.ReportSource = M_cr;
                }
                else
                    MessageBox.Show("Select Admin Mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (combo_table.Text == "Doctors")
            {
                if (Doc_ID_txt.Text != "")
                {
                   // D_cr.SetParameterValue(0, Admin_cmb.Text);
                   // D_cr.SetParameterValue(0, Doc_ID_txt.Text);
                   // crystalReportViewer1.ReportSource = D_cr;
                }
                else
                    MessageBox.Show("Enter Doctor ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

       //to select parameter report
        private void combo_table_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_table.SelectedItem.ToString() == "Doctors")
            {
                Doc_ID_txt.Text = "";
                Doc_ID_txt.Visible = true;
                label8.Visible = true;
                Admin_cmb.Visible = false;
                label6.Visible = false;
            }
            else if (combo_table.SelectedItem.ToString() == "Managments")
            {
                Admin_cmb.Visible = true;
                label6.Visible = true;
                Doc_ID_txt.Visible = false;
                label8.Visible = false;
            }
        }

       
        //end parem
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabNavigationPage4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabNavigationPage1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void man_text_TextChanged(object sender, EventArgs e)
        {

        }

    }

}
