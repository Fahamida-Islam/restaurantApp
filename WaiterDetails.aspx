﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaiterDetails.aspx.cs" Inherits="RestaurantDetails.WaiterDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    
    <asp:Button ID="btnUserAccount" runat="server" PostBackUrl="~/UserAccount.aspx" 
        style="z-index: 1; left: 104px; top: 15px; position: absolute" 
        Text="User Account" />
    
    <div>

     <asp:ScriptManager ID="ScriptManager1" runat="server">
     </asp:ScriptManager>
    
    <asp:Label ID="lblWaiterDetails" runat="server" Font-Bold="True" 
            Font-Size="Larger" 
            style="z-index: 1; left: 100px; top: 48px; position: absolute" 
            Text="Waiter Details" Font-Underline="True"></asp:Label>
    
    <asp:TextBox ID="txtRestaurant" runat="server" ReadOnly="True" 
        style="z-index: 1; left: 165px; top: 87px; position: absolute"></asp:TextBox>
        
   
    <asp:Label ID="lblChefs" runat="server" 
        style="z-index: 1; left: 102px; top: 125px; position: absolute" 
        Text="Chef(s) at your restaurant:"></asp:Label>
        
        
    <asp:Label ID="lblRestaurant" runat="server" 
        style="z-index: 1; left: 85px; top: 89px; position: absolute" 
        Text="Restaurant:"></asp:Label>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" 
       ChildrenAsTriggers="False" UpdateMode="Conditional">

    <ContentTemplate>
         
    <asp:Label ID="lblEmail" runat="server" Font-Italic="True" 
       style="z-index: 1; left: 236px; top: 254px; position: absolute" 
       Text="Email will appear here."></asp:Label>

     <asp:Label ID="lblError" runat="server" ForeColor="Red" 
     style="z-index: 1; left: 346px; top: 181px; position: absolute"></asp:Label>

     <asp:Button ID="btnShowEmail" runat="server" 
     style="z-index: 1; left: 102px; top: 250px; position: absolute" 
     Text="Show Email" OnClick="btnShowEmail_Click" />

     <asp:ListBox ID="lstChefs" runat="server"        
      style="z-index: 1; left: 102px; top: 159px; position: absolute;
      height: 72px; width: 180px"> 
     </asp:ListBox>
   
     </ContentTemplate>
                
     <Triggers>
     <asp:AsyncPostBackTrigger ControlID="btnShowEmail" EventName="Click"/>
     </Triggers>

     </asp:UpdatePanel>
       </div>
    </form>
</body>
</html>
