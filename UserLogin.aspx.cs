using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using RestaurantDetails.App_Code;
namespace RestaurantDetails
{
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {  if (Page.IsPostBack)
            {
                lblError.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            if (txtUsername.Text.Length < 5 || txtUsername.Text.Length > 20)
            {
                lblError.Text = "Username in invalid length";
            }


            else if (txtPassword.Text.Length < 6)
            {
                lblError.Text = "Password in invalid length";
            }


            else
            {
                User employee = new User();

                employee.UserName = txtUsername.Text;

                employee.UserPassword = txtPassword.Text;


                if (employee.authenticateUser())
                {
                    Response.Redirect("~/UserAccount.aspx");
                }

                else
                {
                    lblError.Text = "Incorrect username and/or password";
                }
            }

        }
    }
}