﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PozdravnaPoruka.aspx.cs" Inherits="WebFormsPrimjer.PozdravnaPoruka" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Ovo je pozdravna poruka <br />
            <asp:Label ID="Label1" runat="server" Text="Ime:"></asp:Label><br />
            <asp:TextBox ID="txtIme" runat="server" ForeColor="Red"></asp:TextBox><br />
            <asp:Button ID="btnObradi" runat="server" Text="Button" BackColor="Black" ForeColor="White" Height="45px" OnClick="btnObradi_Click" Width="129px"/><br />
            <asp:Label ID="lblRezultat" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
