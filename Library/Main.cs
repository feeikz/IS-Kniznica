using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using LibraryBusiness.Entity;
using System.Data.SQLite;
using System.Xml.Serialization;
using System.IO;
using LibraryBusiness.Mapper;


namespace Library
{
    public partial class Main : Form
    {
        List<Book> knihy = new List<Book>();
        
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
         

        }


        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //vratenie knihy hľadať
            listBox2.Items.Clear();
            int ID_zaznamu = Convert.ToInt32(textBox11.Text);
            XMLGateway gateway = new XMLGateway();
            XMLGateway.LoadDocument("C:/Users/PC/Desktop/school/3rok/zimny_semester/VIS/Library/LibraryBusiness/Mapper/Rent.xml");
            Rent rent = new Rent(ID_zaznamu);
            rent.Load();
           /* if (id == "")
            {
                listBox2.Items.Add("ID zapožičania:");
                listBox2.Items.Add(rent.ID);
                listBox2.Items.Add("_____________");
            }
            else {
                listBox2.Items.Add("ID zapožičania:");
                listBox2.Items.Add(rent.ID);
                listBox2.Items.Add("_____________");
            }*/

            listBox2.Items.Add("ID zapožičania:");
            listBox2.Items.Add(rent.ID);
            listBox2.Items.Add("ID Knihy:");
            listBox2.Items.Add(rent.ID_knihy);
            listBox2.Items.Add("ID zakaznika:");
            listBox2.Items.Add(rent.ID_zakaznika);
            listBox2.Items.Add("_____________");

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //uložiť knihu 
         
            Book kniha = new Book();
            kniha.title = pridat_nazov.Text;
            kniha.author = pridat_autor.Text;
            kniha.year = Convert.ToInt32(pridat_rok.Text);
            kniha.condition = Convert.ToInt32(pridat_stav.Text);


//            SqliteDataAccess.SaveBook(kniha);
            Book.SaveBook(kniha);

            pridat_autor.Text = "";
            pridat_nazov.Text = "";
            pridat_rok.Text = "";
            pridat_stav.Text = "";

            List<Book> books = Book.GeAlltBooks();

            foreach (Book item in books)
            {
                pridat_list.Items.Add(item.title);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //najst knihu hladaj button
            string nazov = najst_nazov_knihy.Text;
            //List<Book> books = Book.GetBooks(nazov);
            List<Book> books = Book.GeAlltBooks();
            foreach (Book item in books)
            {
                najst_list.Items.Clear();

            }

            foreach (Book item in books)
            {
                najst_list.Items.Add("Názov Knihy:");
                najst_list.Items.Add(item.title);
                najst_list.Items.Add("ID Knihy:");
                najst_list.Items.Add(item.ID);
                najst_list.Items.Add("__________________");

            }
        }

        private void najst_list_Click(object sender, EventArgs e)
        {

        }

        private void najst_lis_Click(object sender, EventArgs e)
        {

        }

        private void najst_list_MouseClick(object sender, MouseEventArgs e)
        {
            //najst_list.View = View.Details;
            int row = najst_list.SelectedIndex;
   
        }

        private void najst_nazov_knihy_TextChanged(object sender, EventArgs e)
        {
           
    
        }

        private void najst_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //save registrovanie zakaznika
            Customer customer = new Customer();
            customer.login = registrovat_uzivatela.Text;
            customer.password = registrovat_heslo.Text;
            customer.firstName = registrovat_meno.Text;
            customer.lastName = registrovat_priezvisko.Text;
            customer.address = registrovat_adresa.Text;
            customer.balance = registrovat_kredity.Text;

            Customer.SignUp(customer);
            List<Customer> customers = Customer.ShowCustomers();

            foreach (Customer c in customers)
            {
                registrovat_list.Items.Add(c.login);
            }

            registrovat_uzivatela.Text = "";
            registrovat_heslo.Text = "";
            registrovat_meno.Text = "";
            registrovat_priezvisko.Text = "";
            registrovat_adresa.Text = "";
            registrovat_kredity.Text = "";

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string login = registrovat_box.Text.ToString();
            List<Customer> customers = Customer.ShowCustomersLogin(login);
            foreach (Customer c in customers)
            {

                registrovat_list.Items.Clear();
            }


            foreach (Customer c in customers)
            {
               
                registrovat_list.Items.Add(c.login);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // pridat kredit uložiť button
            string login = pridatKredit_login.Text;
            string balance = pridatKredit_kredity.Text;
            List<Customer> customers = Customer.ShowCustomersLogin(login);
            foreach (Customer c in customers)
            {

                listBox3.Items.Clear();
            }

            Customer.Update_balance(balance, login);

            List<Customer> customers2 = Customer.ShowCustomersLogin(login);

            foreach (Customer c in customers2)
            {

                listBox3.Items.Add(c.login);
                listBox3.Items.Add(c.balance);
                listBox3.Items.Add("________________________________________");
            }



        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //pridat kredit hladat button
            string login = pridatKredit_login.Text;
            List<Customer> customers = Customer.ShowCustomersLogin(login);
            foreach (Customer c in customers)
            {

                listBox3.Items.Clear();
            }

            foreach (Customer c in customers)
            {

                listBox3.Items.Add(c.login);
                listBox3.Items.Add(c.balance);
                listBox3.Items.Add("________________________________________");
            }

        }

        private void tabPage10_Click(object sender, EventArgs e)
        {
      

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //GENEROVAT
            List<Reservation> reservations = new List<Reservation>();
            XmlSerializer serial = new XmlSerializer(typeof(List<Reservation>));
            reservations.Add(new Reservation
            {
                ID = 1,
                ID_knihy = 3,
                ID_zakaznika = 3,
                od = DateTime.Now
            }); 
         
            using (FileStream fs = new FileStream(Environment.CurrentDirectory + "\\reservation.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(fs, reservations);
                MessageBox.Show("Created");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            List<Book> books = Book.GeAlltBooks();
            foreach (Book item in books)
            {
                pozicat_list.Items.Clear();

            }

            foreach (Book item in books)
            {
                pozicat_list.Items.Add(item.title);
                pozicat_list.Items.Add(item.ID);
                pozicat_list.Items.Add("__________________");

            }


            XMLGateway gateway = new XMLGateway();
            XMLGateway.LoadDocument("C:/Users/PC/Desktop/school/3rok/zimny_semester/VIS/Library/LibraryBusiness/Mapper/Rent.xml");
            List<Rent> rents = Rent.LoadAll();
            listBox4.Items.Clear();
            foreach (Rent rent in rents)
            {
              
                listBox4.Items.Add(rent.ID_knihy);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            List<Rent> rents = Rent.LoadAll();
            foreach (Rent rent in rents)
            {

                listBox1.Items.Clear();

            }

             XMLGateway gateway = new XMLGateway();
             XMLGateway.LoadDocument("C:/Users/PC/Desktop/school/3rok/zimny_semester/VIS/Library/LibraryBusiness/Mapper/Rent.xml");
          
             foreach (Rent rent in rents)
             {
                 
                listBox1.Items.Add("ID pôžičky: ");
                listBox1.Items.Add(rent.ID);
                listBox1.Items.Add("ID knihy: ");
                listBox1.Items.Add(rent.ID_knihy);
                listBox1.Items.Add("ID zákazníka: ");
                listBox1.Items.Add(rent.ID_zakaznika);
                listBox1.Items.Add("__________________");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //požičať knihu
            XMLGateway gateway = new XMLGateway();
            XMLGateway.LoadDocument("C:/Users/PC/Desktop/school/3rok/zimny_semester/VIS/Library/LibraryBusiness/Mapper/Rent.xml");
            int id = XMLGateway.GetFreeNode();
            Console.WriteLine(id);
            int id_zakaznika = Convert.ToInt32(textBox5.Text);
            int id_knihy = Convert.ToInt32(textBox2.Text);
            Rent rent = new Rent(id, id_zakaznika, id_knihy);

            rent.InsertData(rent);
            listBox5.Items.Add("ID pôžičky: ");
            listBox5.Items.Add(rent.ID);
            listBox5.Items.Add("ID knihy: ");
            listBox5.Items.Add(rent.ID_knihy);
            listBox5.Items.Add("ID zákazníka: ");
            listBox5.Items.Add(rent.ID_zakaznika);
            listBox5.Items.Add("__________________");

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox11.Text);
            Rent rent = new Rent(id);
            rent.Delete();
            //vratit knihu

        }
    }
}

