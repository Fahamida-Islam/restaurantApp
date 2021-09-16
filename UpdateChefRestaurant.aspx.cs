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
    public partial class UpdateChefRestaurant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("~/UserLogin.aspx");
            }

            else
            {
               int RoleID = Int32.Parse(Session["RoleID"].ToString());

                if (RoleID == 2)
                {
                    if (!Page.IsPostBack)
                    {
                        Restaurant rst = new Restaurant(); 

                        DataTable dt = rst.getAllRestaurants();

                        int RestaurantID = Int32.Parse(Session["RestaurantID"].ToString());

                        string RestaurantName;

                        rst.RestaurantId = RestaurantID;

                        txtRestaurant.Text = rst.getRestaurantName();


                        if (dt != null)

                        {
                            lstRestaurants.DataSource = dt;

                            lstRestaurants.DataTextField = "RestaurantName";

                            lstRestaurants.DataValueField = "RestaurantID";

                            lstRestaurants.DataBind();
                        }

                        else
                        {
                            lblError.Text = "Database connection error-failed to display Restaurant name";
                        }
                    }
                
                else
                {
                    lblError.Text = "";
        
                }
            }
        }
    }


        protected void btnUpdateRestaurant_Click(object sender, EventArgs e)
        {
           

            if (lstRestaurants.SelectedIndex.Equals(-1))
            {
                lblError.Text = "please select a Restaurant Name to progress";
            }


            else if (txtRestaurant.Text.Equals(lstRestaurants.SelectedItem.Text))

            {
                lblError.Text = " Restaurant Name already exist-please select another one";

            }


            else
            {
                Restaurant rst = new Restaurant();

                rst.RestaurantId = Int32.Parse(Session["RestaurantID"].ToString());

                string RestaurantName = rst.getRestaurantName();

                rst.RestaurantName = lstRestaurants.SelectedItem.Text;

                if (rst.UpdateChefRestaurant())
                {
                   
                    txtRestaurant.Text = lstRestaurants.SelectedItem.Text;

                    Response.Redirect("~/UserAccount.aspx?change=success");
                }


                else
                {
                    lblError.Text = "Database connection error - could not update Restaurant";
                }

            }
        }           
    }
}   
