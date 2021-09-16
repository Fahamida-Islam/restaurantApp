<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.aspx.cs" Inherits="RestaurantDetails.UserAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
       <form id="form1" runat="server">
    
    <asp:Button ID="btnLogout" runat="server" PostBackUrl="~/Logout.aspx"        
        style="z-index: 1; left: 27px; top: 29px; position: absolute;" 
        Text="Logout" />
    
    <div>
        
        <asp:Label ID="lblUserAccount" runat="server" Font-Bold="True" 
            Font-Size="Larger" Font-Underline="True" 
            style="z-index: 1; left: 119px; top: 69px; position: absolute" 
            Text="User Account"></asp:Label>
    
    
    <asp:Label ID="lblWelcome" runat="server" 
        style="z-index: 1; left: 119px; top: 107px; position: absolute"></asp:Label>
        
    <asp:Label ID="lblChangePassword" runat="server" 
        style="z-index: 1; left: 118px; top: 144px; position: absolute" 
        Text="If this is the first time you have logged in, please change your password." 
        Visible="False"></asp:Label>
        
    <asp:Button ID="btnUpdatePassword" runat="server" 
        style="z-index: 1; top: 29px; position: absolute; left: 280px" 
        Text="Update Password" PostBackUrl="~/UpdatePassword.aspx" />
        
    <asp:Button ID="btnUserDetails" runat="server" 
        PostBackUrl="~/WaiterDetails.aspx" 
        style="z-index: 1; left: 120px; top: 29px; position: absolute" 
        Text="Waiter Details"/>
        
    <asp:Button ID="btnUpdateChefRestaurant" runat="server" 
        style="z-index: 1; left: 457px; top: 30px; position: absolute" 
        Text="Update Chef Restaurant" Visible="False" 
        PostBackUrl="~/UpdateChefRestaurant.aspx" />

         <asp:Label ID="lblUpdateSuccess" runat="server" ForeColor="#009900" 
        style="z-index: 1; left: 121px; top: 189px; position: absolute"></asp:Label>

     

        </div>
           
    </form>
</body>
</html>
