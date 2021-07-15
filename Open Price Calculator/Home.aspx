<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Open_Price_Calculator.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        For Simplicty, Just capturing Buy and Sell order from user, and display the Open price    
    </div>

    <h3>Enter you order details.</h3>

    <div>
        Enter Price:<asp:TextBox ID="txtBuyPrice" runat="server"></asp:TextBox>
        Enter Volume:<asp:TextBox ID="txtBuyVol" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuy" runat="server" Text="BuyOrder" OnClick="BuyOrder_Click" />
    </div>
    <p></p>
    <div>
        Enter Price:<asp:TextBox ID="txtSellPrice" runat="server"></asp:TextBox>
        Enter Volume:<asp:TextBox ID="txtSellVolume" runat="server"></asp:TextBox>
        <asp:Button ID="btnSell" runat="server" Text="SellOrder" OnClick="SellOrder_Click" />
    </div>
    <p></p>
    <div>
        
        <asp:Button ID="btnDisplayOpenPrice" runat="server" Text="Display open price" OnClick="DisplayPrice_Click" />
        <asp:Label ID="lblOpenPrice" runat="server" Text="" Font-Bold="true"></asp:Label>

    </div>
    <p></p>

    <div>
        <asp:Button ID="btnDisplayOrderBook" runat="server" Text="Display order book" OnClick="DisplayOrderBook_Click" />

        <div id="tblBook" visible="false" runat="server">
            <table border="1px">
                <tr>
                    <td>
                        <table border="1px">
                            <thead>
                                <tr>
                                    <th colspan="2">Buy</th>
                                </tr>
                                <tr>
                                    <th>Volume</th>
                                    <th>Price</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptBuy" runat="server">

                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("BuyVolume") %></td>
                                            <td><%# Eval("BuyPrice") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </td>
                    <td></td>
                    <td>
                        <table border="1px">
                            <thead>
                                <tr>
                                    <th colspan="2">Sell</th>
                                </tr>
                                <tr>
                                    <th>Price</th>
                                    <th>Volume</th>
                                </tr>
                            </thead>
                            <tbody>

                                <asp:Repeater ID="rptSell" runat="server">

                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("SellPrice") %></td>
                                            <td><%# Eval("SellVolume") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </table>



        </div>

    </div>




</asp:Content>
