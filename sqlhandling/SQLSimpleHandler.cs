using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingApp.sqlhandling
{
    class SQLSimpleHandler
    {
        private MySqlConnection connection;
        public SQLSimpleHandler(MySqlConnection connection)
        {
            this.connection = connection;
        }
        private bool openConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open) { return true; }
                connection.Open();
                return true;
            }catch(MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cant connect to the server!");
                        break;
                    case 1045:
                        MessageBox.Show("Wrong user or password!");
                        break;
                }
                return false;
            }
            
        }
        private bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
           
        }
        public void executeCommand(String toExecute)
        {
            if(openConnection() == true)
            {
                MySqlCommand command = new MySqlCommand(toExecute, connection);
                command.ExecuteNonQuery();
                closeConnection();
            }
        }
        public StoreItem select(int id)
        {
            StoreItem toReturn = null;
            if (openConnection() == true)
            {
                
                MySqlCommand command = new MySqlCommand("SELECT * FROM storeitems WHERE id ="+id, connection);
                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    toReturn = new StoreItem(int.Parse(dataReader["id"]+""), dataReader["name"]+"", double.Parse(dataReader["price"]+""));
                }
                dataReader.Close();
                closeConnection();
            }
            return toReturn;
        }
        public int count(String toExecute)
        {
            if (openConnection() == true)
            {
                MySqlCommand command = new MySqlCommand(toExecute, connection);
                int count =  int.Parse(command.ExecuteScalar()+"");
                closeConnection();
                return count;
            }
            
            return -1;
        }
        public bool addItem(String name,int id,double price)
        {
            if (openConnection())
            {

                MySqlCommand cmd = new MySqlCommand("INSERT INTO storeitems(id,name,price) VALUES(?id,?name,?price)", connection);
                cmd.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
                cmd.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
                cmd.Parameters.Add("?price", MySqlDbType.Double).Value = price;
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }catch(MySqlException ex)
                {
                    
                    if (ex.Number.Equals(1062))
                    {
                        return false;
                    }

                }
                closeConnection();
            }
            return false;
        }

    }
}
