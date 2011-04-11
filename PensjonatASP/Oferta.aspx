<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oferta.aspx.cs" Inherits="PensjonatASP.Oferta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pensjonat: Oferta</title>
 <style type="text/css">
    BODY {
	margin: 0px;
	padding: 0px;
	background-color: #ffffff;
}

BODY, DIV, P, INPUT 
{
	font: 15px  "Trebuchet MS", Tahoma, Arial, sans-serif;
	margin: 0px;
	padding: 8px;
}

INPUT 
{
    border: 1px solid #D2D2D2;
}

TEXTAREA, SELECT {
	border: 1px solid #D2D2D2;
}

#start
{
    float:left;
}
</style>
</head>
<body>
    <form id="form1" runat="server" >
    <div id="content">
    <div id="start">
        <p>Termin rozpoczęcia: </p><asp:Calendar ID="Calendar1" runat="server" 
            BackColor="White" BorderColor="#999999" CellPadding="4" 
            DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
            Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    </div>
    <div id="zakonczenie">
        <p>Termin zakończenia: </p>
    <asp:Calendar ID="Calendar2" runat="server" BackColor="White" 
        BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
        Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
        Width="200px">
        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
        <NextPrevStyle VerticalAlign="Bottom" />
        <OtherMonthDayStyle ForeColor="#808080" />
        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
        <SelectorStyle BackColor="#CCCCCC" />
        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
        <WeekendDayStyle BackColor="#FFFFCC" />
    </asp:Calendar>   
    </div>
    <div id="ilosc_osob">
    Ilość osób: 
        <asp:TextBox ID="TextBox1" runat="server" Enabled="False"></asp:TextBox> 
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Sprawdź" /><br />
    </div>
    <div id="grid">    
        <asp:Label ID="Label1" runat="server" Text="---"></asp:Label><br />
        <asp:GridView ID="GridView1" runat="server"  autogeneratecolumns="true" CellPadding="4" ForeColor="#333333" 
            GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </div>
    </div>
    
    </form>
            
</body>
</html>
