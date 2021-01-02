<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurDuzenle.aspx.cs" Inherits="OyunlarWebForms.BaPages.TurDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tür Düzenle" Font-Size="14pt" Font-Underline="True"></asp:Label>
        </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:TextBox ID="tbAdi" runat="server" Width="286px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="bKaydet" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bKaydet_Click" Text="Kaydet" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="bDetay" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bDetay_Click" Text="Detay" />
        </p>
    <p>
        <asp:Label ID="lBilgi" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
