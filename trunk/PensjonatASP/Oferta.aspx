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
     .style1
     {
         width: 100%;
     }
     .style2
     {
         width: 438px;
     }
 </style>
</head>
<body>
<b>Rezerwacja:</b><table class="style1">
        <tr>
            <td class="style2">
    <form id="form1" runat="server" >
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
    
   <div id="content">
    
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
    Ilość osób w pokoju: 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox> 
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Sprawdź" /><br />
    </div>
    <div id="grid">    
        <asp:Label ID="Label1" runat="server" Text="              "></asp:Label>
        <asp:GridView ID="GridView1" runat="server"  autogeneratecolumns="true" 
            CellPadding="4" ForeColor="#333333" 
            GridLines="None" SelectedIndex="0" 
            onselectedindexchanged="GridView1_SelectedIndexChanged">
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
        <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="*" 
            Visible="False" />
&nbsp;<asp:Button ID="Button3" runat="server" Text="Wybierz" Visible="False" 
            onclick="Button3_Click" />
    </div>
    </div>
    <hr />
    <div id="Div1">
    <b>Sprawdź zaliczkę:</b><br />
        Id rezerwacji: <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> <br />
        PESEL: <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox> <br />
        <asp:Button ID="Button2" runat="server" Text="Sprawdź" 
            onclick="Button2_Click" /><br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="             "></asp:Label>
    </div>


    </form>
            
            </td>
            <td valign="top">
                <strong><br />
                </strong>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
&nbsp;
            
</body>
</html>
