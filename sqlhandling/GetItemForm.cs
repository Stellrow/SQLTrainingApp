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

namespace TrainingApp.sqlhandling
{
    public partial class GetItemForm : Form
    {
        private Form1 form;
        public GetItemForm(Form1 form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            try
            {
                id = int.Parse(textBox1.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("The ID is not a number!");
            }
            sqlhandling.StoreItem storeItem;
            storeItem = form.SimpleHandler.select(id);
            if (storeItem == null)
            {
                MessageBox.Show("No item found with this ID!");
                return;
            }
            MessageBox.Show("Found this item! \nName: "+storeItem.Name+"\nID: "+storeItem.Id+"\nPrice: "+storeItem.Price);

        }
    }
}
