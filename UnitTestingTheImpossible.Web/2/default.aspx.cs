using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitTestingTheImpossible.Web.Models;

namespace UnitTestingTheImpossible.Web._2
{
  public partial class _default : System.Web.UI.Page
  {

    private readonly ProductRepository _Repo;

    public _default() : this(null)
    {
    }

    public _default(ProductRepository repo)
    {
      _Repo = repo ?? new Models.ProductRepository();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    // The return type can be changed to IEnumerable, however to support
    // paging and sorting, the following parameters must be added:
    //     int maximumRows
    //     int startRowIndex
    //     out int totalRowCount
    //     string sortByExpression
    public IQueryable<UnitTestingTheImpossible.Web.Models.Product> grid_GetData()
    {
      return _Repo.Get();
    }

    // The id parameter name should match the DataKeyNames value set on the control
    public void grid_UpdateItem(int id)
    {
      UnitTestingTheImpossible.Web.Models.Product item = null;
      item = _Repo.Get(id);
      if (item == null)
      {
        // The item wasn't found
        ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
        return;
      }
      TryUpdateModel(item);
      if (ModelState.IsValid)
      {

        _Repo.Save(item);

      }
    }
  }
}