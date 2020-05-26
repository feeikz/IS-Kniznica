using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using LibraryBusiness.Entity;
using System.Data.SQLite;
using System.Data;

namespace LibraryBusiness.Mapper
{
    public class BookMapper
    {

        private static string Select_ALL = "SELECT * FROM KNIHA";
        private static string selectTitle = "select* from Kniha where nazov like @title";
    

        public static List<Book> SelectALL(SQLiteConnection connection)
        {
            using (connection)
            {
                var output = connection.Query<Book>("select * from Kniha", new DynamicParameters());
                {
                    var tmp = output.ToList();
                    Console.Out.WriteLine(tmp);
                    return output.ToList();
                }
            }
        }


        public static void SaveBook(SQLiteConnection connection, Book book)
        {
            using (connection)
            { 
                connection.Execute("Insert into Kniha (nazov, autor, rok_vydania, stav) values (@title, @author, @year, @condition)", book);
            }
        }

        public static List<Book> LoadBook(SQLiteConnection connection,string nazov)
        {

            using (connection)
            {

                var output = connection.Query<Book>($"select * from Kniha where nazov like '{nazov}'");
                var default_output = connection.Query<Book>("select * from Kniha");

                if (nazov == "")
                {
                    return default_output.ToList();
                }

                return output.ToList();
            }

        }

        public static List<Book> Select(SQLiteConnection connection, string title)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(selectTitle, connection))
            {
                List<Book> result = new List<Book>();

               SqlParameter p = new SqlParameter("@title", SqlDbType.Char, 255)
                {
                    Value = "%" + title + "%"
                };
                cmd.Parameters.AddWithValue(p.ParameterName, p.Value);

                SQLiteDataReader rdr = null;
                try
                {
                    rdr = cmd.ExecuteReader();
                    int i = -1;
                    while (rdr.Read())
                    {
                        i++;

                        Book b = new Book()
                        {
                            ID = Convert.ToInt32(rdr["ID"]),
                            title = rdr["nazov"].ToString(),
                            author = rdr["autor"].ToString()
                            //year = (int)rdr["rok_vydania"],
                            //condition = (int)rdr["stav"]

                        };
                        result.Add(b);
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


        public static List<Book> SelectALLBooks(SQLiteConnection connection)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(Select_ALL, connection))
            {
                List<Book> result = new List<Book>();

                SQLiteDataReader rdr = null;
                try
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        Book b = new Book()
                        {
                            ID = Convert.ToInt32(rdr["ID"]),
                            title = rdr["nazov"].ToString()
    
                        };
                        result.Add(b);
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




    }

}
