using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingApp.sqlhandling;

namespace TrainingApp
{
    public partial class Form1 : Form
    {
        private SQLSettingsForm sqlForms;
        private AddItemForm addItemForm;
        private String sqlStatus = "SQL Status: Disconnected";
        private MySqlConnection connection;
        private bool isConnected = false;

        public Form1()
        {
            InitializeComponent();
            addItemForm = new AddItemForm(this);
            this.Text = "SQL Training";
            label1.Text = sqlStatus;
            sqlForms = new SQLSettingsForm(sqlStatus,this);
        }
        public Label getSQLStatusLabel()
        {
            return label1;
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlForms.Text = "SQL Settings";
            sqlForms.Show();
        }
        public MySqlConnection Connection
        {
            get { return connection; }
            set { connection = value; SimpleHandler = new SQLSimpleHandler(value); isConnected = true; }
        }
        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        internal SQLSimpleHandler SimpleHandler { get; set; } = null;

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isConnected) { MessageBox.Show("Please log in the MySql Database first!");return; };
            new AddItemForm(this).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isConnected) { MessageBox.Show("Please log in the MySql Database first!"); return; };
            new GetItemForm(this).Show();
        }
    }
}
