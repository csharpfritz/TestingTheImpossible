using Fritz.WebFormsTest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using UnitTestingTheImpossible.Web.Models;
using Xunit;

namespace UnitTestingTheImpossible.Test
{

  public class WebFormsTest
  {

    public WebFormsTest()
    {

      WebApplicationProxy.Create(typeof(UnitTestingTheImpossible.Web.original));

    }

    [Fact]
    public void GridShouldHaveContent()
    {
      var page = WebApplicationProxy.GetPageByLocation<UnitTestingTheImpossible.Web.original>("/original.aspx");
      page.RunToEvent(WebFormEvent.Unload);
      var outputHTML = page.RenderHtml();

      Console.WriteLine(outputHTML);

      Assert.Contains("id=\"grid\"", outputHTML);

    }

    [Fact]
    public void ShouldSave()
    {

      var args = CreateGridUpdateArgs();

      var page = WebApplicationProxy.GetPageByLocation<UnitTestingTheImpossible.Web.original>("/original.aspx");
      page.TheGrid.FireEvent("RowUpdating", args);

      var theRealProduct = Web.original._Products.First(p => p.ID == 1);
      Assert.Equal("Test Product", theRealProduct.Name);
      Assert.Equal(6.66M, theRealProduct.Price);

    }

    private static GridViewUpdateEventArgs CreateGridUpdateArgs()
    {
      var args = new GridViewUpdateEventArgs(1);
      var testProduct = new Product { ID = 1, Name = "Test Product", Price = 6.66M };
      args.Keys.Insert(0, 1, 1);
      args.NewValues.Add("Name", testProduct.Name);
      args.NewValues.Add("Price", testProduct.Price);

      return args;

    }
  }

}
