using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UnitTestingTheImpossible.Web.Models;

namespace UnitTestingTheImpossible.Web._1
{
  public partial class _default : System.Web.UI.Page
  {

    private readonly ProductRepository _Repo;
    private readonly HttpContextWrapper _ContextOverride = null;

    public _default() : this(null, null)
    {
    }

    public _default(ProductRepository repo, HttpContextWrapper context)
    {
      _Repo = repo ?? new Models.ProductRepository();
      _ContextOverride = context;
    }

    protected new HttpContextWrapper Context
    {
      get
      {

        return _ContextOverride ?? new HttpContextWrapper(base.Context);

      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        BindData();
      }
    }

    private void BindData()
    {
      grid.DataKeyNames = new string[] { "ID" };
      grid.DataSource = _Repo.Get().OrderBy(p => p.ID);
      grid.DataBind();
    }

    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
      grid.EditIndex = e.NewEditIndex;
      BindData();
    }

    protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      grid.EditIndex = -1;
      BindData();
    }

    public void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

      var savedProduct = new Product
      {
        ID = (int)e.Keys[0],
        Name = e.NewValues["Name"].ToString(),
        Price = decimal.Parse(e.NewValues["Price"].ToString())
      };
      _Repo.Save(savedProduct);

      grid.EditIndex = -1;
      BindData();

    }

  }
}