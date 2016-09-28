using Moq;
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

  public class _1_MoveLogicOut
  {

    private MockRepository _Mockery;

    public _1_MoveLogicOut()
    {
      _Mockery = new MockRepository(MockBehavior.Default);
    }

    [Fact]
    public void ShouldSave()
    {

      var repo = _Mockery.Create<ProductRepository>();

      var page = new UnitTestingTheImpossible.Web._1._default(repo.Object, null);

      var args = new GridViewUpdateEventArgs(1);
      var testProduct = new Product { ID = 1, Name = "Test Product", Price = 6.66M };
      args.Keys.Insert(0, 1, 1);
      args.NewValues.Add("Name", testProduct.Name);
      args.NewValues.Add("Price", testProduct.Price);

      page.grid_RowUpdating(null, args);

      // The grid doesn't EXIST?!?!

      repo.Verify(r => r.Save(testProduct), "Did not save the product");

    }

  }

}
