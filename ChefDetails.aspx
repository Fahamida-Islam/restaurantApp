<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChefDetails.aspx.cs" Inherits="RestaurantDetails.ChefDetails" %>

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
       
        <asp:Label ID="lblChefDetails" runat="server" Font-Bold="True" 
            Font-Size="Larger" 
            style="z-index: 1; left: 100px; top: 48px; position: absolute" 
            Text="Chef Details" Font-Underline="True"></asp:Label>

          <asp:UpdatePanel ID="UpdatePanel1" runat="server" 
             ChildrenAsTriggers="False" UpdateMode="Conditional">

      <ContentTemplate>

       <asp:TextBox ID="txtRestaurant" runat="server" ReadOnly="True" 
        style="z-index: 1; left: 165px; top: 87px; position: absolute"></asp:TextBox>

       <asp:ListBox ID="lstWaiters" runat="server"  
        style="z-index: 1; left: 102px; top: 159px; position: absolute; height: 72px; width: 180px">
       </asp:ListBox>
    
       <asp:Button ID="btnRemoveWaiter" runat="server" 
        style="z-index: 1; left: 102px; top: 250px; position: absolute" 
        Text="Remove Waiter" OnClick="btnRemoveWaiter_Click" />
        
       <asp:Label ID="lblSuccess" runat="server" ForeColor="#009900" 
        style="z-index: 1; left: 523px; top: 251px; position: absolute"></asp:Label>

          <asp:Label ID="lblError" runat="server" ForeColor="Red" 
        style="z-index: 1; left: 327px; top: 260px; position: absolute"></asp:Label>

          <asp:TextBox ID="txtCuisineId" runat="server" 
        style="z-index: 1; left: 355px; top: 160px; position: absolute"></asp:TextBox>

       <asp:Button ID="btnTxtSearch" runat="server" OnClick="txtSearch_Click" 
         style="z-index: 1; left: 360px; top: 199px; position: absolute" Text="Search" />
        
          <asp:UpdateProgress ID="UpdateProgress1" runat="server" 	DynamicLayout="true">

      <ProgressTemplate>
             <p style="text-align:center;">Please wait page Loading ...</p>
      </ProgressTemplate>

      </asp:UpdateProgress>

      </ContentTemplate>

      <Triggers>
      <asp:AsyncPostBackTrigger ControlID="btnRemoveWaiter" EventName="Click"/>
      <asp:AsyncPostBackTrigger ControlID="btnTxtSearch" EventName="Click"/>
      </Triggers>

      </asp:UpdatePanel>


    </div>

    <asp:Label ID="lblRestaurant" runat="server"       
        style="z-index: 1; left: 90px; top: 90px; position: absolute; height: 19px;" 
        Text="Restaurant:"></asp:Label>
        
    <asp:Label ID="lblWaiters" runat="server" 
        style="z-index: 1; left: 102px; top: 125px; position: absolute" 
        Text="Waiters(s) at your restaurant:"></asp:Label>
   

    <asp:Label ID="Label1" runat="server" 
        style="z-index: 1; left: 356px; top: 130px;
        position: absolute" Text="Count  Restaurant offering same Cuisine by CuisineID"></asp:Label>
   
    <p>
        
    <asp:Label ID="lblCuisines" runat="server" 
        style="z-index: 1; left: 100px; top: 305px; position: absolute" 
        Text="Cuisines at your restaurant:"></asp:Label>
    
    </p>
    
     <div style="z-index: 1; left: 110px; top: 340px; position: absolute;">
    <asp:Repeater ID="rptCuisines" runat="server">
        <ItemTemplate>
        Cuisine Region:
        <strong><%#Eval("CuisineRegion") %></strong><br />
        Cuisine Name:
        <strong><%#Eval("CuisineName") %></strong><br />
        </ItemTemplate>
        <SeparatorTemplate>
            <div style="width:300px;"><hr /></div>
        </SeparatorTemplate>
    </asp:Repeater>
    </div>
    
       
    </form>
</body>
</html>
