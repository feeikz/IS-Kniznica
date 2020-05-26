using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBusiness.Mapper;

namespace LibraryBusiness.Entity
{
    public class Employee
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string Address { get; set; }
        public int Access { get; set; }

        public static Employee GetEmployeeByLogin(String login, String pass)
        {
            return EmployeeMapper.SelectSingle(GetConnection(), login, pass);
        }

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = Database.getConnection();
            return connection;
        }



    }
}
