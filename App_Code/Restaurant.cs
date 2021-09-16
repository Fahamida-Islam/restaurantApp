using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace RestaurantDetails.App_Code
{
    public class Restaurant
    {

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        private DatabaseConnection dataConn;

        public Restaurant()
        {
            dataConn = new DatabaseConnection();
        }
        public DataTable getAllRestaurants()
        {
            string command = "Select * FROM Restaurant";
            return dataConn.executeReader(command);

        }

        public string getRestaurantName()
        {
           

            dataConn.addParameter("@RestaurantID", RestaurantId);

            string command = "Select  RestaurantName FROM Restaurant where RestaurantID=@RestaurantID";

            DataTable table = dataConn.executeReader(command);
            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["RestaurantName"].ToString();
            }
            else
            {
                return "";
            }
        }

        public bool UpdateChefRestaurant()
        {
            dataConn.addParameter("@RestaurantName", RestaurantName);
            dataConn.addParameter("@RestaurantID", RestaurantId);

            string command = "Update Restaurant set RestaurantName=@RestaurantName where RestaurantID=@RestaurantID ";
            return dataConn.executeNonQuery(command) > 0;
        }       
    }
}
