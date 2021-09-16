using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace RestaurantDetails.App_Code
{
    public class Cuisine
    {

        public int CuisineId { get; set; }
        public string CuisineName { get; set; }
        public string CuisineRegion { get; set; }
        public int RestaurantId { get; set; }

        private DatabaseConnection dataConn;
        private IDataAdapter adapter;
        
       

        public Cuisine()
        {
            dataConn = new DatabaseConnection();
                   
        }

        public DataTable getCuisine()
        {
            dataConn.addParameter("@RestaurantID", RestaurantId);

            string command = "Select CuisineName,CuisineRegion FROM Cuisine where CuisineID IN (Select CuisineID FROM RestaurantCuisine where RestaurantID=@RestaurantID)";


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
