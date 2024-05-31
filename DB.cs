using System;
using MySql.Data.MySqlClient;

namespace Diplom
{
    internal class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;password=root;username=root;database=algorytms-data;");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetSqlConnection()
        {
            return connection;
        }

        public void SaveDataToSwarm(int startNumberOfFruits, TimeSpan executionTime)
        {
            openConnection();
            var query = "INSERT INTO swarm (startNumberOfFruits, executionTime) VALUES (@startNumberOfFruits, @executionTime)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@startNumberOfFruits", startNumberOfFruits);
                command.Parameters.AddWithValue("@executionTime", executionTime);
                command.ExecuteNonQuery();
            }
            closeConnection();
        }
        public void SaveDataToCentralized(int startNumberOfFruits, TimeSpan executionTime)
        {
            openConnection();
            var query = "INSERT INTO centralized (startNumberOfFruits, executionTime) VALUES (@startNumberOfFruits, @executionTime)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@startNumberOfFruits", startNumberOfFruits);
                command.Parameters.AddWithValue("@executionTime", executionTime);
                command.ExecuteNonQuery();
            }
            closeConnection();
        }
    }
}
