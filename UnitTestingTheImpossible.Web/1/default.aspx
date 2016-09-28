<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="UnitTestingTheImpossible.Web._1._default" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

      <h1>Move Logic Out!</h1>

      <asp:GridView runat="server" ID="grid" 
        OnRowEditing="grid_RowEditing" OnRowCancelingEdit="grid_RowCancelingEdit" OnRowUpdating="grid_RowUpdating"
        AllowSorting="true" AutoGenerateColumns="true" AutoGenerateEditButton="true">

      </asp:GridView>

</asp:Content>