<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="original.aspx.cs" Inherits="UnitTestingTheImpossible.Web.original" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

      <h1>My Original Grid with Edit Capabilities</h1>

      <asp:GridView runat="server" ID="grid" ClientIDMode="Static"
        OnRowEditing="grid_RowEditing" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowUpdating="grid_RowUpdating"
        AllowSorting="true" AutoGenerateColumns="true" AutoGenerateEditButton="true">

      </asp:GridView>

</asp:Content>