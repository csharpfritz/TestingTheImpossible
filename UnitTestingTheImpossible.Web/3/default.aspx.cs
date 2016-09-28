using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitTestingTheImpossible.Web.Models;

namespace UnitTestingTheImpossible.Web._3
{
  public partial class _default : System.Web.UI.Page, IGridPage
  {

    private readonly GridPresenter _Presenter;
    private readonly ProductRepository _Repo;

    public _default()
    {

      _Repo = new Models.ProductRepository();
      _Presenter = new GridPresenter(this, _Repo);

    }

    public GridView Grid {  get { return this.grid; } }

  }
}