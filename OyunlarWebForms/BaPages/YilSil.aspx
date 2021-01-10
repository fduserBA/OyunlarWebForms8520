<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="YilSil.aspx.cs" Inherits="OyunlarWebForms.BaPages.YilSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label2" runat="server" Text="Yıl Sil" Font-Size="14pt" Font-Underline="True"></asp:Label>
        </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Değeri:"></asp:Label>
        &nbsp;<asp:Label ID="lDegeri" runat="server"></asp:Label>
        </p>
    <p>
        Yıl kaydını silmek istiyor musunuz?</p>
    <p>
        <asp:Button ID="bEvet" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bEvet_Click" Text="Evet" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="bHayir" runat="server" BackColor="#CE5D5A" ForeColor="White" OnClick="bHayir_Click" Text="Hayır" />
        </p>
    <asp:Label ID="lBilgi" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>
