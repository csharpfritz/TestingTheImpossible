using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using UnitTestingTheImpossible.Web.Models;
using Xunit;

namespace UnitTestingTheImpossible.Test
{

  public class _0_Original
  {

    [Fact]
    public void ShouldSetEditIndex()
    {

      var page = new UnitTestingTheImpossible.Web.original();

      // How do I trigger page lifecycle so the grid is created?

      var args = new GridViewUpdateEventArgs(1);
      var testProduct = new Product { ID = 1, Name = "Test Product", Price = 6.66M };
      args.Keys.Insert(0, 1, 1);
      args.NewValues.Add("Name", testProduct.Name);
      args.NewValues.Add("Price", testProduct.Price);

      page.grid_RowUpdating(null, args);

      // How do I verify the database is called?

      Assert.Equal(1, page.TheGrid.EditIndex);

    }

  }

}
