<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="UnitTestingTheImpossible.Web._2._default" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">

      <h1>Model Binding FTW!</h1>

      <asp:GridView runat="server" ID="grid" ItemType="UnitTestingTheImpossible.Web.Models.Product"
        SelectMethod="grid_GetData" UpdateMethod="grid_UpdateItem"
        AllowSorting="true" AutoGenerateColumns="true" AutoGenerateEditButton="true">

      </asp:GridView>

</asp:Content>