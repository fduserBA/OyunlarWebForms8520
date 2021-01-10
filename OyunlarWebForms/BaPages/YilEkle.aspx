<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YilEkle.aspx.cs" Inherits="OyunlarWebForms.BaPages.YilEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Yıl Ekle" Font-Size="14pt" Font-Underline="True"></asp:Label>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Değeri:"></asp:Label>
        &nbsp;<asp:TextBox ID="tbDegeri" runat="server" Width="286px"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="bKaydet" runat="server" BackColor="#CE5D5A" ForeColor="White" Text="Kaydet" OnClick="bKaydet_Click" />
    </p>
    <p>
        <asp:Label ID="lBilgi" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
