using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using LibraryBusiness.Entity;


namespace WEB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                Response.Redirect("/welcome.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String login = txtuser.Text;
            String password = txtpass.Text;

            Customer customer = Customer.GetCustomerByLogin(login, password);
            if (customer == null) {
                Response.Write("Login failed");
            }

            else if (customer.login == login && customer.password == password )
            {
                //Console.WriteLine(customer.login + "employee login");
                //Console.WriteLine(login + "= login");
                Session["user"] = txtuser.Text;
                Response.Redirect("/welcome.aspx");
            }
        }
    }
}