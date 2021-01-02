<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurSil.aspx.cs" Inherits="OyunlarWebForms.BaPages.TurSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Tür Sil" Font-Size="14pt" Font-Underline="True"></asp:Label>
        </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:Label ID="lAdi" runat="server"></asp:Label>
        </p>
    <p>
        Tür kaydını silmek istiyor musunuz?</p>
    <p>
        <asp:Button ID="bEvet" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bEvet_Click" Text="Evet" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="bHayir" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bHayir_Click" Text="Hayır" />
        </p>
</asp:Content>
