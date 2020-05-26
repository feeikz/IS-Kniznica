using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryBusiness.Mapper;

namespace LibraryBusiness.Entity
{
    public class Customer
    {
        public int ID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string balance { get; set; }

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = Database.getConnection();
            return connection;
        }


        public static void SignUp(Customer customer)
        {
            CustomerMapper.SignUpCustomer(GetConnection(), customer);
        }

        public static List<Customer> ShowCustomers()
        {
            return CustomerMapper.SelectALLCustomers(GetConnection());
        }

        public static List<Customer> ShowCustomersLogin(String login)
        {
            return CustomerMapper.SelectCustomersLogin(GetConnection(), login);
        }

        public static void Update_balance(string balance, string login) {
            CustomerMapper.UpdateBalance(GetConnection(), balance, login);
        }

        public static Customer GetCustomerByLogin(String login, String pass)
        {
            return CustomerMapper.SelectSingle(GetConnection(), login, pass);
        }
    }
}
