using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBusiness.Entity;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System.Data.SQLite;

namespace LibraryBusiness.Mapper
{
    class EmployeeMapper
    {

        private static string select_single = "select * from zamestnanec where login = @LOGIN and heslo = @pass";

        public static Employee SelectSingle(SQLiteConnection connection, string login, string pass  )
        {
            
            using (SQLiteCommand cmd = new SQLiteCommand(select_single, connection))
            {
                Employee employee = new Employee();

                cmd.Parameters.AddWithValue("@LOGIN", login);
                cmd.Parameters.AddWithValue("@pass", pass);
                SQLiteDataReader rdr = null;

                try
                {
                    rdr = cmd.ExecuteReader();
                    int counter = 0;
                    while (rdr.Read())
                    {
                        counter++;
                        Employee e = new Employee()
                        {
                            Login = rdr["login"].ToString(),
                            Password = rdr["heslo"].ToString(),

                        };
                        rdr.Close();
                        Console.WriteLine(counter);
                        return e;

                    }
                }
                catch { }

                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }

                }
                return null;
                
            }
        }






    }
}
