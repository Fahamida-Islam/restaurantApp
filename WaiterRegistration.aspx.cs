using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using RestaurantDetails.App_Code;

namespace RestaurantDetails
{
    public partial class WaiterRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!Page.IsPostBack)
            {
                Restaurant rst = new Restaurant();
                
                DataTable dt = rst.getAllRestaurants();  

                if (dt!=null)
                {
                    
                    ddlRestaurants.DataSource = dt;
                   
                    ddlRestaurants.DataValueField = "RestaurantId";
                 
                    ddlRestaurants.DataTextField = "RestaurantName";
                  
                    ddlRestaurants.DataBind();
                }

                else
                {
                    lblError.Text = "Database connection error - failed to display Departments.";
                }

            }
            else
            {
                lblError.Text="";
             }


        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Inside eWOOOOScalar method...");
           
            if(txtUsername.Text.Equals(""))

            {
                lblError.Text = " Please fill up all details to progress";
            }

            else if (txtUsername.Text.Length < 5 || txtUsername.Text.Length > 20)
            
            {
                lblError.Text = "Name sholud be more than 5 or less than 20 character";
            }

            else if (txtPassword.Text.Length < 6)
            {
                lblError.Text = "Password should be more than 6 character ";
            }

            else if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
            {
                lblError.Text = "Please confirm your password to progress";
            }

            else if (txtRealName.Text.Equals(""))
            {
                lblError.Text = "Please Enter your Real Name";
            }
            else if (txtEmailAddress.Text.Equals("")) 
            {
                lblError.Text = "Please Enter your Email Address";
            }

            else
            {
                User employee = new User();
                
                employee.UserName = txtUsername.Text;
                
                if (employee.UserNameExists())
                {
                   
                    lblError.Text = "Username already exists, please select another Name";
                }

                else
                {
                    employee.UserName = txtUsername.Text;

                    employee.UserPassword = txtPassword.Text;

                    employee.RealName = txtRealName.Text;

                    employee.EmailAddress = txtEmailAddress.Text;

                    employee.RestaurantId = Int32.Parse(ddlRestaurants.SelectedValue);

                    employee.RoleId = 1; 
                    
                    if (employee.addUser())
                    {                                                                                                                                                                                                                                                       
                    Response.Redirect("~/UserLogin.aspx");
                    }

                    else                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
                    {                      
                        lblError.Text = "Database connection error - failed to insert record.";
                    }

                }

            }
        }
    }
}
    
