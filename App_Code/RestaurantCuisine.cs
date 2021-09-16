using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace RestaurantDetails.App_Code
{
    public class RestaurantCuisine
    {
        public int CuisineId { get; set; }
        public int  RestaurantId { get; set; }

        private DatabaseConnection dataConn;


        public RestaurantCuisine()
        {
            dataConn = new DatabaseConnection();
           
        }

        public DataTable getCuisineId()
        {
            dataConn.addParameter("@RestaurantID", RestaurantId);

            string command = "Select CuisineID FROM RestaurantCuisine where RestaurantID=@RestaurantID";

            DataTable table = dataConn.executeReader(command);

            if (table.Rows.Count > 0)
            {
                return table;
            }
            else
            {
                return null;
            }
        }
    }
}