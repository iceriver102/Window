<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="F5debugWp7RawNotificationServer._Default" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<style type="text/css">
.style1
{
width:100%;
}
.style2
{
}
.style3
{
width:690px;
}
.style4
{
width:143px;
}
.style5
{
width:38px;
}
</style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<table>
<tr>
<td colspan="3">
<asp:Label ID="Label1" runat="server" Font-Bold="true" Font-Size="Large" Text="F5Debug Windows Phone 7 Raw Notification"></asp:Label>
</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td>
&nbsp;</td>
<td>
<asp:Label ID="Label2" runat="server" Text="Channel URI"></asp:Label>
</td>
<td>
<asp:TextBox ID="TextBox1" runat="server" Width="661px"></asp:TextBox>
</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td>
&nbsp;</td>
<td>
<asp:Label ID="Label3" runat="server" Text="Notification Title"></asp:Label>
</td>
<td>
<asp:TextBox ID="TextBox2" runat="server" Width="661px"></asp:TextBox>
</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td>
&nbsp;</td>
<td>
<asp:Label ID="Label4" runat="server" Text="Notification SubTitle"></asp:Label>
</td>
<td>
<asp:TextBox ID="TextBox3" runat="server" Width="659px"></asp:TextBox>
</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
<td>
&nbsp;</td>
</tr>
<tr>
<td>
&nbsp;</td>
<td>
<asp:Button ID="Button1" runat="server" Font-Bold="True"
onclick="Button1_Click" Text="Send Notification" Width="134px" />
</td>
<td>
<asp:Label ID="lblresult" runat="server"></asp:Label>
</td>
<td>
&nbsp;</td>
</tr>
</table>
</asp:Content>
