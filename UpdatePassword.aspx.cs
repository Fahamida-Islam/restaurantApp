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
    public partial class UpdatePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("~/UserLogin.aspx");
            }

            if(Page.IsPostBack)
            {
                lblError.Text = "";
            }
        }

        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text.Length < 6)
            {
                lblError.Text = "Current password is in invalid length.";
            }
            else if (txtNewPassword.Text.Length < 6)
            {
                lblError.Text = "New password is in invalid length.";
            }
            else if (!txtConfirmPassword.Text.Equals(txtNewPassword.Text))
            {
                lblError.Text = "Please confirm new password.";
            }
            else
            {
                User worker = new User();

                worker.UserId = Int32.Parse(Session["UserID"].ToString());

                string password = worker.getPasswordUsingID();


                if (password.Equals(txtCurrentPassword.Text))
                {
                    worker.UserPassword = txtNewPassword.Text; 

                    if (worker.updatePasswordByUserId())
                    {
                        Response.Redirect("~/UserAccount.aspx?change=success");
                    }
                    else
                    {
                        lblError.Text = "Database connection error - failed to update password";
                    }
                }
                else
                {
                    lblError.Text = "Current password is incorrect";
                }

            }
        }
    }
}