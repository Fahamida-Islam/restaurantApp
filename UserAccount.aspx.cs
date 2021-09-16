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
    public partial class UserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                if (Session.Count == 0)
                {
                    Response.Redirect("~/UserLogin.aspx");
                }

                else
                {
                if (Request.QueryString.HasKeys())
                {
                    if (Request.QueryString["change"].Equals("success"))
                    {
                        lblUpdateSuccess.Text = "You successfully changed your password";

                    }
                }

                    if (Request.QueryString.HasKeys())
                    {
                        if (Request.QueryString["change"].Equals("success"))
                        {

                            int RestaurantID = Int32.Parse(Session["RestaurantID"].ToString());

                            lblUpdateSuccess.Text = "You successfully changed your Restaurant";



                        }
                    }
                


                    if(Page.IsPostBack)
                {
                    lblUpdateSuccess.Text = " ";
                }

                    string RealName = (string)Session["RealName"];

                    int RoleID = Int32.Parse(Session["RoleID"].ToString());

                    lblWelcome.Text = "Welcome " + RealName + ".";

                    lblWelcome.Style.Add("color", "Blue");


                    if (RoleID == 2)
                    {
                        btnUpdateChefRestaurant.Visible = true;

                        lblChangePassword.Visible = true;

                        btnUserDetails.Text = "Chef Details";

                        btnUserDetails.PostBackUrl = "~/ChefDetails.aspx";
                    }


                }
            

           
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
         
            Session.Abandon();
   
            Response.Redirect("~/UserLogin.aspx");
        }

    }

}
