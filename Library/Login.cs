using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryBusiness.Mapper;
using LibraryBusiness.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace Library
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            String login = textBox1.Text;
            String password = textBox2.Text;
            this.Hide();
            Main main = new Main();
            main.Show();   


            /*Employee employee = Employee.GetEmployeeByLogin(login, password);
            if (employee.Login == login && employee.Password == password)
            {
                Console.WriteLine(employee.Login + "employee login");
                Console.WriteLine(login + "= login");
                this.Hide();
                Main main = new Main();
                main.Show();
            }
            else {
                Console.WriteLine("cosi sa pojebalo");
                Console.WriteLine(employee.Password + "employe pass");
                Console.WriteLine(login + "= login");
                this.Hide();
            }*/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
