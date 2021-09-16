<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="RestaurantDetails.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
    <div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager> 

        <asp:Label ID="lblUsername" runat="server" Text="Username:" 
            style="z-index: 1; top: 88px; position: absolute; left: 97px; " width="64"></asp:Label>
       
        <asp:Label ID="lblPassword" runat="server" Text="Password:" 
            style="z-index: 1; left: 97px; top: 129px; position: absolute"></asp:Label>
       
        <asp:Label ID="lblLoginPortal" runat="server" Font-Bold="True" 
            Font-Size="Larger" style="z-index: 1; left: 97px; top: 40px; position: absolute" 
            Text="Login Portal" Font-Underline="True"></asp:Label>
       
        <p> &nbsp;</p>
        <asp:Label ID="lblRegister" runat="server" 
            style="z-index: 1; left: 143px; top: 269px; position: absolute" 
            Text="Waiter not registered?"></asp:Label>

        
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" 
             ChildrenAsTriggers="False" UpdateMode="Conditional">

        <ContentTemplate>

         <p>     
         <asp:Button ID="btnLogin" runat="server" Text="Login" 
           style="z-index: 1; left: 181px; top: 173px; position: absolute" OnClick="btnLogin_Click"/>      
        </p>
        
         <asp:TextBox ID="txtUsername" runat="server" 
              style="z-index: 1; left: 181px; top: 88px; position: absolute"></asp:TextBox>
        
         <asp:TextBox ID="txtPassword" runat="server" 
              style="z-index: 1; left: 181px; top: 128px; position: absolute" 
              TextMode="Password"></asp:TextBox>

         <asp:Label ID="lblError" runat="server" ForeColor="Red" 
            style="z-index: 1; left: 181px; top: 218px; position: absolute"></asp:Label>

        <asp:UpdateProgress ID="UpdateProgress1" runat="server" 	DynamicLayout="true">

        <ProgressTemplate>

             <p style="text-align:center;">please wait checking validation...</p>
 
        </ProgressTemplate>

            </asp:UpdateProgress>
        
          </ContentTemplate>

         <Triggers>

           <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click"/>

     </Triggers>

</asp:UpdatePanel>
        
    </div>

    <asp:Button ID="btnRegister" runat="server" 
        style="z-index: 1; left: 293px; top: 260px; position: absolute" 
        Text="Register" PostBackUrl="WaiterRegistration.aspx" />

    </form>
</body>
</html>
