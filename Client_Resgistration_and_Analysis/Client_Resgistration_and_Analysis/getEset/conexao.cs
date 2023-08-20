using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Client_Resgistration_and_Analysis.getEset
{
    internal class Conexao
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string apelido { get; set; }
        public string clienteTipo { get; set; }

        private MySqlConnection connection;

        public Conexao()
        {
            string server = "localhost";
            string database = "clientestm";
            string user = "root";
            string password = "Halix2020.";

            string connectionString = $"Server={server};Database={database};Uid={user};Pwd={password};";

            connection = new MySqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public DataTable GetTestDataFromTestando()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM testando";

            try
            {
                OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here, e.g., log or display an error message.
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return dataTable;
        }

        public void InsertDataIntoTestando(string nome, string apelido, string clietipo)
        {
            string query = "INSERT INTO testando (nome, apelido, clietipo) VALUES (@nome, @apelido, @clietipo)";

            try
            {
                OpenConnection();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@apelido", apelido);
                    cmd.Parameters.AddWithValue("@clietipo", clietipo);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here, e.g., log or display an error message.
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
