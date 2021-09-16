using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace RestaurantDetails.App_Code
{
    public class User
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string RealName { get; set; }
        public string EmailAddress { get; set; }
        public int RestaurantId { get; set; }
        public int RoleId { get; set; }
        



        private DatabaseConnection dataConn;

        public User()
        {
            dataConn = new DatabaseConnection();
        }
        public bool UserNameExists() //boolean means true or false
        {
            dataConn.addParameter("@UserName", UserName);

            string command = "Select COUNT(UserName) FROM RestaurantUser WHERE UserName=@UserName";

            int result = dataConn.executeScalar(command); //result of count

            return result > 0 || result == -1; //if record found or exception caught
        }
        public bool addUser()
        {
            dataConn.addParameter("@UserName", UserName);
            dataConn.addParameter("@UserPassword", UserPassword);
            dataConn.addParameter("@RealName", RealName);
            dataConn.addParameter("@EmailAddress", EmailAddress);
            dataConn.addParameter("@RestaurantID", RestaurantId);
            dataConn.addParameter("@RoleID", RoleId);

            string command = "INSERT INTO RestaurantUser (UserName, UserPassword, RealName, EmailAddress, RestaurantID, RoleID) " +
                            "VALUES (@UserName, @UserPassword, @RealName, @EmailAddress, @RestaurantID, @RoleID)";

            return dataConn.executeNonQuery(command) > 0; //i.e. 1 or more rows affected
        }

       

        public bool authenticateUser()
        {
            dataConn.addParameter("@UserName", UserName);
            dataConn.addParameter("@UserPassword", UserPassword);

            string command = "Select UserID, RealName, RestaurantID, RoleID FROM RestaurantUser " +
                            "WHERE UserName=@UserName AND UserPassword=@UserPassword";

            DataTable table = dataConn.executeReader(command);

            if (table.Rows.Count > 0)
            {

                HttpContext.Current.Session["UserID"] = table.Rows[0]["UserID"].ToString();
                HttpContext.Current.Session["RealName"] = table.Rows[0]["RealName"].ToString();
                HttpContext.Current.Session["RestaurantID"] = table.Rows[0]["RestaurantID"].ToString();
                HttpContext.Current.Session["RoleID"] = table.Rows[0]["RoleID"].ToString();

                return true;
            }
            else
            {
                return false;
            }
        }


        public string getPasswordUsingID()
        {
            dataConn.addParameter("@UserID", UserId);

            string command = "Select UserPassword FROM RestaurantUser WHERE UserID=@UserID";

            DataTable table = dataConn.executeReader(command);

            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["UserPassword"].ToString();
            }
            else
            {
                return "";
            }

        }
        public bool updatePasswordByUserId()
        {
            dataConn.addParameter("@UserPassword", UserPassword);
            dataConn.addParameter("@UserID", UserId);

            string command = "Update RestaurantUser Set UserPassword=@UserPassword WHERE UserID=@UserID";

            return dataConn.executeNonQuery(command) > 0; //i.e. 1 or more rows affected
        }



        public DataTable getAllUser()
        {
            string command = "Select * FROM RestaurantUser";
            return dataConn.executeReader(command);

        }



        public bool deleteUser()
        {
            dataConn.addParameter("@UserName", UserName);


            string command = "DELETE FROM RestaurantUser where UserName=@UserName ";

            return dataConn.executeNonQuery(command) > 0; //i.e. 1 or more rows affected
        }



        public string getEmailAddress()
        {

          
            dataConn.addParameter("@UserID", UserId);


            string command = "Select EmailAddress FROM RestaurantUser where UserID=@UserID";

            DataTable table = dataConn.executeReader(command);

            if (table.Rows.Count > 0)
            {
                return table.Rows[0]["EmailAddress"].ToString();


            }
            else
            {
                return "";
            }
        }


        public DataTable getAllChefUserName()
        {

            dataConn.addParameter("@RestaurantID", RestaurantId);


            string command = "Select UserName, UserID FROM RestaurantUser WHERE RestaurantID=@RestaurantID and RoleID=2";

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



        public DataTable getAllWaiterName()
        {

            dataConn.addParameter("@RestaurantID", RestaurantId);

            string command = "Select UserName, UserID FROM RestaurantUser WHERE RestaurantID=@RestaurantID and RoleID=1";

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