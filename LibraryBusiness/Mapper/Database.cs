using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;

namespace LibraryBusiness.Mapper
{
    public class Database
    {
        private static string connectionString = "Data Source=C:/Users/PC/Desktop/school/3rok/zimny_semester/VIS/Library/Library/MyDatabase.db;Version=3;";

        public static SQLiteConnection getConnection() {
            var connection = new SQLiteConnection(connectionString);
            if (!(connection.State == System.Data.ConnectionState.Open)) {
                connection.Open();
            }
            return connection;
        }

    }
}
