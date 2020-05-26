using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibraryBusiness.Mapper;
using LibraryBusiness.Entity;

namespace WEB
{
    public partial class Pozicky : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                txtuser.Text = "Welcome " + Session["user"].ToString();
            }

            ListBox1.Items.Clear();

            List<Rent> rents = Rent.LoadAll();
            foreach (Rent rent in rents)
            {

                ListBox1.Items.Clear();

            }

            XMLGateway gateway = new XMLGateway();
            XMLGateway.LoadDocument("C:/Users/PC/Desktop/school/3rok/zimny_semester/VIS/Library/LibraryBusiness/Mapper/Rent.xml");

            foreach (Rent rent in rents)
            {

                ListBox1.Items.Add("ID pôžičky: ");
                ListBox1.Items.Add(rent.ID.ToString());
                ListBox1.Items.Add("ID knihy: ");
                ListBox1.Items.Add(rent.ID_knihy.ToString());
                ListBox1.Items.Add("ID zákazníka: ");
                ListBox1.Items.Add(rent.ID_zakaznika.ToString());
                ListBox1.Items.Add("__________________");

            }


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("user");
            Response.Redirect("/Default.aspx");
        }

    }
}