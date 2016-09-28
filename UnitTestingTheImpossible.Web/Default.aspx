<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UnitTestingTheImpossible.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET - Unit Test the Impossible!</h1>
        <p class="lead">Let's look at various techniques to test your applications.  Our <a href="Original.aspx">sample page</a> shows a grid that uses a repository to
          fetch some data.
        </p>
    </div>

    <div class="row">
        <div class="col-md-3">
            <h2>Move Your Code Out!</h2>
            <p>
              In this sample, we will look at moving all of our code out of the event
              handlers and into other classes to manage the interactions.
            </p>
            <p>
                <a class="btn btn-default" href="/1/default.aspx">Explore &raquo;</a>
            </p>
        </div>
        <div class="col-md-3">
            <h2>Don't Use Events</h2>
            <p>
              With ASP.NET 4.5, Model Binding was introduced to ASP.NET Web Forms and allows
              you to operate outside of the event structure
            </p>
            <p>
                <a class="btn btn-default" href="/2/default.aspx">Explore &raquo;</a>
            </p>
        </div>
        <div class="col-md-3">
            <h2>Model - View - Presenter</h2>
            <p>
              The grand-daddy of architecture changes, but provides ultimate flexibility is the
              model - view - presenter approach.  Lets make the ASPX a dumb UI and push all management
              to another class
            </p>
            <p>
                <a class="btn btn-default" href="/3/default.aspx">Explore &raquo;</a>
            </p>
        </div>
        <div class="col-md-3">
            <h2>Web Forms Test</h2>
            <p>
              Let's test our existing application without changing a line of code.
            </p>
            <p>
                <a class="btn btn-default" href="/original.aspx">Explore &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
