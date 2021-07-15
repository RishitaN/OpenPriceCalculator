<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Open_Price_Calculator.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        For Simplicty, Just captyring Buy and Sell order from user.        
    </div>

    <h3>Enter you order details.</h3>   

    <div>
         Enter Price:<asp:TextBox ID="txtBuyPrice" runat="server"></asp:TextBox>
         Enter Volume:<asp:TextBox ID="txtBuyVol" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuy" runat="server" Text="BuyOrder" OnClick="BuyOrder_Click"/>
    </div>

    <div>

         Enter Price:<asp:TextBox ID="txtSellPrice" runat="server"></asp:TextBox>
         Enter Volume:<asp:TextBox ID="txtSellVolume" runat="server"></asp:TextBox>
        <asp:Button ID="btnSell" runat="server" Text="SellOrder"  OnClick="SellOrder_Click"/>
    </div>

    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Button ID="btnDisplayOpenPrice" runat="server" Text="Display open price"  OnClick="DisplayPrice_Click"/>

    </div>

   
    

</asp:Content>
