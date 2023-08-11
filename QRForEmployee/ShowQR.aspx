<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowQR.aspx.cs" Inherits="QRForEmployee.ShowQR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <asp:Label ID="Label2" runat="server" Text="--Your QR--" Font-Bold="True" Font-Size="50px" ForeColor="Red"></asp:Label>
        
       <%-- 
        <p>
            <asp:Image Width="267px" hight="100px" ID="Image" runat="server" Visible="false" Height="247px" />
            </p>
            

            <br />
            <br />
            <br />
            <br />
            <br />
            --%>

       </center>
        <asp:GridView ID="GridView1" AllowPaging="True" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:ImageField DataImageUrlField="Img" HeaderText="QR-Image">
                </asp:ImageField>
            </Columns>
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
             
               
                 
                
                 
             
        </asp:GridView>  
        
        
        
       
        
        
        
    </form>
</body>
</html>
