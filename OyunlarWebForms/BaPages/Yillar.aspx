<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Yillar.aspx.cs" Inherits="OyunlarWebForms.BaPages.Yillar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="14pt" Text="Yıl Listesi"></asp:Label>
    </p>
    <p>
        <asp:LinkButton ID="lbEkle" runat="server" OnClick="lbEkle_Click">Yeni Yıl Ekle</asp:LinkButton>
    </p>
    <asp:GridView ID="gvYillar" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="700px" OnSelectedIndexChanged="gvTurler_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField SelectText="Detay" ShowSelectButton="True" />
            <asp:BoundField DataField="Id" />
            <asp:BoundField DataField="Degeri" HeaderText="Yıl Değeri" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
<br />
<asp:Label ID="lBilgi" runat="server" ForeColor="IndianRed"></asp:Label>
</asp:Content>
