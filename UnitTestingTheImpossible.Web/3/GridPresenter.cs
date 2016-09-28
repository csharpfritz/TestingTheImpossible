using System;
using System.Linq;
using System.Web.UI.WebControls;
using UnitTestingTheImpossible.Web.Models;

namespace UnitTestingTheImpossible.Web._3
{

  public class GridPresenter
  {

    public GridPresenter(IGridPage page, ProductRepository repo)
    {

      this.Page = page;
      Page.Load += Page_Load;
      this.Repo = repo;

    }

    private void Page_Load(object sender, EventArgs e)
    {

      ManageGrid();

      if (!Page.IsPostBack) BindData();

    }

    public IGridPage Page { get; }

    public ProductRepository Repo { get; }

    private void BindData()
    {
      Page.Grid.DataKeyNames = new string[] { "ID" };
      Page.Grid.DataSource = Repo.Get().OrderBy(p => p.ID);
      Page.Grid.DataBind();
    }

    public void ManageGrid()
    {

      Page.Grid.RowEditing += grid_RowEditing;
      Page.Grid.RowCancelingEdit += grid_RowCancelingEdit;
      Page.Grid.RowUpdating += grid_RowUpdating;

    }

    public void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
      Page.Grid.EditIndex = e.NewEditIndex;
      BindData();
    }

    public void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
      Page.Grid.EditIndex = -1;
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
      Repo.Save(savedProduct);

      Page.Grid.EditIndex = -1;
      BindData();

    }

  }

}