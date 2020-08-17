using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingApp.sqlhandling
{
    public partial class AddItemForm : Form
    {
        private Form1 form;
        public AddItemForm(Form1 form)
        {
            this.form = form;
            InitializeComponent();
            this.Text = "Add Item";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 4)
            {
                MessageBox.Show("The name must be at least 4 characters long!");
                return;
            }


            int id = 0;
            try
            {
                id = int.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("The id is not a number!");
            }


            double price = 0;
            try
            {
                price = double.Parse(textBox3.Text);
            } catch (FormatException)
            {
                MessageBox.Show("The price is not a number!");
            }
            if (id.Equals(0)) { return; }
            if (form.SimpleHandler.addItem(textBox1.Text, id, price))
            {
                MessageBox.Show("The item was added to the Database!");
            }
            else { MessageBox.Show("The item ID already exists in the Database!"); }
            
        }
    }
}
