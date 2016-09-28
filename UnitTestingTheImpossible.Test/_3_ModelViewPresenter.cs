using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using UnitTestingTheImpossible.Web._3;
using UnitTestingTheImpossible.Web.Models;
using Xunit;

namespace UnitTestingTheImpossible.Test
{

  public class _3_ModelViewPresenter
  {

    private MockRepository _Mockery;

    public _3_ModelViewPresenter()
    {
      _Mockery = new MockRepository(MockBehavior.Default);
    }

    [Fact]
    public void ShouldSave()
    {

      var testProduct = new Product { ID = 1, Name = "Test Product", Price = 6.66M };
      var repo = _Mockery.Create<ProductRepository>();
      repo.Setup(r => r.Save(null)).Verifiable();
      repo.Setup<IQueryable<Product>>(r => r.Get()).Returns(new[] { testProduct }.AsQueryable());

      var page = _Mockery.Create<IGridPage>();
      page.SetupGet(p => p.Grid).Returns(new GridView());


      var args = new GridViewUpdateEventArgs(1);
      args.Keys.Insert(0, 1, 1);
      args.NewValues.Add("Name", testProduct.Name);
      args.NewValues.Add("Price", testProduct.Price);

      var sut = new GridPresenter(page.Object, repo.Object);

      sut.grid_RowUpdating(null, args);



    }

  }

}

