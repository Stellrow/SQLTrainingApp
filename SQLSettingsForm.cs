using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace TrainingApp
{
    
    public partial class SQLSettingsForm : Form
    {
        

        private String serverName = "Server Name";
        private String dataBaseName = "DataBase Name";
        private String userID = "User ID";
        private String password = "Password";
        private String port = "Port";
        private String sqlStatus;
        private MySqlConnection connection;
        private Form1 form1;

        public SQLSettingsForm(String sqlStatus,Form1 form)
        {
            this.form1 = form;
            this.sqlStatus = sqlStatus;
            InitializeComponent();
            textBox1.Text = serverName;
            textBox2.Text = dataBaseName;
            textBox3.Text = userID;
            textBox4.Text = password;
            textBox5.Text = port;
            label1.Text = sqlStatus;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(serverName)) { return; }
            textBox1.Text = "";
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            if (!textBox2.Text.Equals(dataBaseName)) { return; }
            textBox2.Text = "";
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            if (!textBox3.Text.Equals(userID)) { return; };
            textBox3.Text = "";
        }
        private void textBox4_Click(object sender, EventArgs e)
        {
            if (!textBox4.Text.Equals(password)) { return; };
            textBox4.Text = "";
        }
        private void textBox5_Click(object sender, EventArgs e)
        {
            if (!textBox5.Text.Equals(port)) { return; };
            textBox5.Text = "";
        }
        private void SQLSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public String ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }
        public String DataBaseName
        {
            get { return dataBaseName; }
            set { dataBaseName = value; }
        }

        public String UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        public String SQLStatus
        {
            get { return sqlStatus; }
            set { sqlStatus = value; }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.serverName = textBox1.Text;
            this.dataBaseName = textBox2.Text;
            this.userID = textBox3.Text;
            this.password = textBox4.Text;
            this.port = textBox5.Text;
            String loginS = "SERVER="+serverName+";uid="+userID+";password="+password+";database="+dataBaseName+";port="+port+";";
            connection = new MySqlConnection(loginS);
            try
            {
                connection.OpenAsync();
                MessageBox.Show("Sucessfully connected to the database!");
                label1.Text = "SQL Status: Connected";
                form1.getSQLStatusLabel().Text= "SQL Status: Connected";
                form1.Connection = connection;
                form1.IsConnected = true;
                createTable();
            }
            catch(Exception)
            {
                MessageBox.Show("Wrong login information!");
            }
        }
        private void createTable()
        {
            MySqlCommand cmd = new MySqlCommand("CREATE TABLE IF NOT EXISTS storeItems(id INT NOT NULL,name varchar(50),price DOUBLE NOT NULL,PRIMARY KEY(id));", connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
