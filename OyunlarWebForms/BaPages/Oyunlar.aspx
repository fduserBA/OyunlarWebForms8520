<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Oyunlar.aspx.cs" Inherits="OyunlarWebForms.BaPages.Oyunlar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:LinkButton ID="lbYeni" runat="server" OnClick="lbYeni_Click">Yeni Oyun</asp:LinkButton>
    <br />
</p>
<p>
    <asp:Label ID="Label1" runat="server" Font-Size="14pt" Text="Oyun Listesi"></asp:Label>
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="gvOyunlar" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="700px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField SelectText="Seç" ShowSelectButton="True" />
                <asp:BoundField DataField="Id" />
                <asp:BoundField DataField="Adi" HeaderText="Oyun Adı" />
                <asp:BoundField DataField="Maliyeti" HeaderText="Oyun Maliyeti" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="Kazanci" HeaderText="Oyun Kazancı" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="KarZarar" HeaderText="Kar / Zarar" />
                <asp:BoundField DataField="YilDegeri" HeaderText="Oyun Yılı" />
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
</p>
    <p>
        <asp:Button ID="bDetay" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bDetay_Click" Text="Detay" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bDuzenle" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bDuzenle_Click" Text="Düzenle" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="bSil" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bSil_Click" Text="Sil" />
</p>
    <p>
        <asp:Label ID="lBilgi" runat="server" ForeColor="Red"></asp:Label>
</p>
    <p>
        &nbsp;</p>
    <asp:Panel ID="pDetay" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False">
        <asp:Label ID="Label2" runat="server" Text="Oyun Detayı" Font-Size="14pt" Font-Underline="True"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:Label ID="lAdi" runat="server"></asp:Label>
        <br />
        Maliyeti:
        <asp:Label ID="lMaliyeti" runat="server"></asp:Label>
        <br />
        Kazancı:
        <asp:Label ID="lKazanci" runat="server"></asp:Label>
        <br />
        Yılı:
        <asp:Label ID="lYili" runat="server"></asp:Label>
        <br />
        Oyun Türleri:
        <asp:Label ID="lTurleri" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pYeni" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False">
        <asp:Label ID="Label4" runat="server" Text="Yeni Oyun" Font-Size="14pt" Font-Underline="True"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:TextBox ID="tbAdiYeni" runat="server" Width="350px"></asp:TextBox>
        <br />
        Maliyeti:
        <asp:TextBox ID="tbMaliyetiYeni" runat="server" Width="200px"></asp:TextBox>
        <br />
        Kazancı:
        <asp:TextBox ID="tbKazanciYeni" runat="server" Width="200px"></asp:TextBox>
        <br />
        Yılı:
        <asp:DropDownList ID="ddlYiliYeni" runat="server" Height="22px" Width="125px">
        </asp:DropDownList>
        <br />
        Oyun Türleri:
        <asp:ListBox ID="lbTurleriYeni" runat="server" SelectionMode="Multiple" Width="270px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="bKaydetYeni" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bKaydetYeni_Click" Text="Kaydet" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="bTemizleYeni" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bTemizleYeni_Click" Text="Temizle" />
    </asp:Panel>
    <asp:Panel ID="pDuzenle" runat="server" BorderStyle="Solid" BorderWidth="1px" Visible="False">
        <asp:Label ID="Label6" runat="server" Text="Oyun Düzenle" Font-Size="14pt" Font-Underline="True"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:TextBox ID="tbAdiDuzenle" runat="server" Width="350px"></asp:TextBox>
        <br />
        Maliyeti:
        <asp:TextBox ID="tbMaliyetiDuzenle" runat="server" Width="200px"></asp:TextBox>
        <br />
        Kazancı:
        <asp:TextBox ID="tbKazanciDuzenle" runat="server" Width="200px"></asp:TextBox>
        <br />
        Yılı:
        <asp:DropDownList ID="ddlYiliDuzenle" runat="server" Height="22px" Width="125px">
        </asp:DropDownList>
        <br />
        Oyun Türleri:<asp:CheckBoxList ID="cblTurleriDuzenle" runat="server">
        </asp:CheckBoxList>
        <br />
        <asp:Button ID="bKaydetDuzenle" runat="server" BackColor="#CE5D5A" ForeColor="White" Text="Kaydet" OnClick="bKaydetDuzenle_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="bTemizleDuzenle" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bTemizleDuzenle_Click" Text="Temizle" />
    </asp:Panel>
</p>
</asp:Content>
