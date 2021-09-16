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
    public partial class WaiterDetails : System.Web.UI.Page
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

                if (RoleID == 1)
                {
                    if (!Page.IsPostBack)
                    {
                        Restaurant rst = new Restaurant(); 

                        DataTable dt = rst.getAllRestaurants();  

                        if (dt != null)

                        {
                            int RestaurantID = Int32.Parse(Session["RestaurantID"].ToString());

                            string RestaurantName;

                            rst.RestaurantId = RestaurantID;

                            txtRestaurant.Text = rst.getRestaurantName();



                            User worker = new User();

                            worker.RestaurantId = RestaurantID;

                            DataTable dtc = worker.getAllChefUserName();

                            if (dtc != null)
                            {

                                lstChefs.DataSource = dtc;  
                                
                                lstChefs.DataValueField = "UserId";  
                                
                                lstChefs.DataTextField = "UserName";

                                lstChefs.DataBind();

                            }
                            else
                            {
                                lblError.Text = "No chef's Exist";
                            }
                        }
                    }
                }
            }
        }

        protected void btnShowEmail_Click(object sender, EventArgs e)
        {


            if (lstChefs.SelectedIndex.Equals(-1))
            {
                lblError.Text = "Please select a chef to progress";
            }

            else
            {
                {
                    User worker = new User();

                    DataTable dtc = worker.getAllUser();

                    worker.UserId = Int32.Parse(lstChefs.SelectedValue.ToString());


                    if (dtc != null)
                    {
                        lstChefs.SelectedItem.Value = worker.getEmailAddress();

                        lblEmail.Text = worker.getEmailAddress();

                        lblEmail.Style.Add("color", "Blue");

                    }

                    else
                    {
                        lblError.Text = "Database connection error-failed to show Email Address";
                    }
                }
            }
        }
    }
}