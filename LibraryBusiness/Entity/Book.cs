using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using LibraryBusiness.Mapper;
using System.Data;
using System.Data.SQLite;

namespace LibraryBusiness.Entity

{
    public class Book
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int year { get; set; }
        public int condition { get; set; }


        public static SQLiteConnection GetConnection() {
            SQLiteConnection connection = Database.getConnection();
            return connection;
        }


        public static void SaveBook(Book book) {
            BookMapper.SaveBook(GetConnection(), book);
        }

        public static List<Book> GetBooks(string title)
        {
            return BookMapper.Select(GetConnection(), title);
        }

        public static List<Book> GeAlltBooks()
        {
            return BookMapper.SelectALLBooks(GetConnection());
        }




    }
}
