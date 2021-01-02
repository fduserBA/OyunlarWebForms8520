<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TurDetayi.aspx.cs" Inherits="OyunlarWebForms.BaPages.TurDetayi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tür Detayı" Font-Size="14pt" Font-Underline="True"></asp:Label>
        </p>
    <p>
        <asp:Label ID="Label3" runat="server" Text="Adı:"></asp:Label>
        &nbsp;<asp:Label ID="lAdi" runat="server"></asp:Label>
        </p>
    <p>
        <asp:ImageButton ID="ibDuzenle" runat="server" Height="48px" ImageUrl="~/BaFiles/edit.png" OnClick="ibDuzenle_Click" Width="48px" />
&nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="ibSil" runat="server" Height="48px" ImageUrl="~/BaFiles/delete.png" OnClick="ibSil_Click" Width="48px" />
        </p>
    <p>
        <asp:Label ID="lBilgi" runat="server" ForeColor="Red"></asp:Label>
    </p>
</asp:Content>
