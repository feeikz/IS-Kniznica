using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBusiness.Entity;
using System.Data.SQLite;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace LibraryBusiness.Mapper
{
    class CustomerMapper
    {

        private static string Select_ALL = "select * from zakaznik";
        private static string selectLogin = "select* from zakaznik where login like @login";
        private static string updateBalance = "UPDATE [zakaznik] SET kredity = @balance WHERE login = @login";
        private static string select_single = "select * from zakaznik where login = @LOGIN and heslo = @pass";


        public static void SignUpCustomer(SQLiteConnection connection, Customer customer)
        {
            using (connection)
            {
                connection.Execute("Insert into Zakaznik (meno, priezvisko, kredity, adresa, login, heslo, telefon) values (@firstname, @lastname, @balance, @address, @login, @password, @number)", customer);
            }
        }


        public static List<Customer> SelectALLCustomers(SQLiteConnection connection)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(Select_ALL, connection))
            {
                List<Customer> result = new List<Customer>();

                SQLiteDataReader rdr = null;
                try
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        Customer c = new Customer()
                        {

                            login = rdr["login"].ToString()

                        };
                        result.Add(c);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {

                }
                return result;
            }
        }

        public static List<Customer> SelectCustomersLogin(SQLiteConnection connection, string login)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(selectLogin, connection))
            {
                List<Customer> result = new List<Customer>();

                SqlParameter p = new SqlParameter("@login", SqlDbType.Char, 255)
                {
                    Value = "%" + login + "%"
                };
                cmd.Parameters.AddWithValue(p.ParameterName, p.Value);

                SQLiteDataReader rdr = null;
                try
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Customer c = new Customer()
                        {
                            login = rdr["login"].ToString(),
                            balance = rdr["kredity"].ToString(),
                             
                        };
                        result.Add(c);
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    if (rdr != null)
                    {
                        rdr.Close();
                    }
                }
                return result;
            }
        }


        public static bool UpdateBalance(SQLiteConnection connection, string balance,  string login)
        {
            if (login == null)
            {
                Console.WriteLine("nepodarilo sa pridat");
                return false;
            }
            

            using (SQLiteCommand cmd = new SQLiteCommand(updateBalance, connection))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@balance", balance);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        
        public static Customer SelectSingle(SQLiteConnection connection, string login, string pass)
        {

            using (SQLiteCommand cmd = new SQLiteCommand(select_single, connection))
            {
                Customer customer = new Customer();
                int counter = 0;
                cmd.Parameters.AddWithValue("@LOGIN", login);
                cmd.Parameters.AddWithValue("@pass", pass);
                SQLiteDataReader rdr = null;

                try
                {
                    rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        counter++;
                        Customer c = new Customer()
                        {
                            login = rdr["login"].ToString(),
                            password = rdr["heslo"].ToString(),

                        };
                        rdr.Close();
                        Console.WriteLine(counter);
                        return c;

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
