using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingTheImpossible.Web.Models;
using Xunit;

namespace UnitTestingTheImpossible.Test
{

  public class _2_ModelBinding
  {
    private MockRepository _Mockery;

    public _2_ModelBinding()
    {
      _Mockery = new MockRepository(MockBehavior.Default);
    }

    [Fact]
    public void ShouldSave()
    {

      var repo = _Mockery.Create<ProductRepository>();

      var page = new UnitTestingTheImpossible.Web._2._default(repo.Object);

      page.grid_UpdateItem(1);

      // How do I set the model in model state???

      repo.Verify(r => r.Save(null), "Did not save the product");

    }

  }

}
