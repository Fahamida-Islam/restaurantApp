using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using RestaurantDetails.App_Code;


namespace RestaurantDetails
{
    public partial class ChefDetails : System.Web.UI.Page
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


                        if (dt != null)

                        {
                            int RestaurantID = Int32.Parse(Session["RestaurantID"].ToString());

                            string RestaurantName;

                            rst.RestaurantId = RestaurantID;

                            txtRestaurant.Text = rst.getRestaurantName();



                            User worker = new User();

                            worker.RestaurantId = RestaurantID;

                            DataTable dtc = worker.getAllWaiterName();

                            if (dtc != null)
                            {

                                lstWaiters.DataSource = dtc;

                                lstWaiters.DataValueField = "UserId";

                                lstWaiters.DataTextField = "UserName";

                                lstWaiters.DataBind();

                            }
                            else
                            {
                                lblError.Text = "No Waiter found";

                            }
                        }



                        int RestaurantID3 = Int32.Parse(Session["RestaurantID"].ToString());

                        Cuisine cnr = new Cuisine();

                        cnr.RestaurantId = RestaurantID3;

                        DataTable dtcuisine = cnr.getCuisine();



                        if (dtcuisine != null)
                        {
                            rptCuisines.DataSource = dtcuisine;

                            rptCuisines.DataBind();
                        }

                        else
                        {
                            lblError.Text = "Database connection error";
                        }

                    }

                    else
                    {
                        lblError.Text = "";

                        lblSuccess.Text = "";
                    }

                }
                else
                {
                    Response.Redirect("~/UserAccount.aspx");
                }

            }

        }


        protected void btnRemoveWaiter_Click(object sender, EventArgs e)
        {

            if (lstWaiters.SelectedIndex.Equals(-1))
            {
                lblError.Text = "please select a Waiter Name";
            }

            else
            {
                User worker = new User();

                worker.UserName = lstWaiters.SelectedItem.Text;

                if (worker.deleteUser())
                {
                    lblSuccess.Text = "Worker Delete successfully";

                    lstWaiters.Items.RemoveAt(lstWaiters.SelectedIndex);
                }
                else
                {
                    lblError.Text = "Database connection error - failed to delete password";
                }

            }

        }

        protected void txtSearch_Click(object sender, EventArgs e)
        {

            if (txtCuisineId.Text.Equals(""))
            {
                lblError.Text = "please enter a CuisineID to search";
            }

            else
            {
                SqlConnection conn;
                SqlCommand comm;

                conn = new SqlConnection(DatabaseConnection.getConnectionString("restaurant_details.mdf"));

                comm = new SqlCommand("SELECT Count(RestaurantID) FROM RestaurantCuisine WHERE " +
                                    "RestaurantID LIKE @SearchLower OR RestaurantID LIKE @SearchUpper", conn);

                string Restaurant = txtCuisineId.Text;

                comm.Parameters.AddWithValue("@SearchLower", Restaurant.ToUpper() + "%");

                comm.Parameters.AddWithValue("@SearchUpper", Restaurant.ToLower() + "%");

                try
                {
                    conn.Open();

                    int count = (int)comm.ExecuteScalar();

                    lblSuccess.Text = "There are " + count + " Restaurant offering same Cuisine";

                }
                catch
                {
                    lblError.Text = "Database connection error - cannot search worker.";
                }

                finally
                {
                    conn.Close();
                }
            }
        }

    }
}