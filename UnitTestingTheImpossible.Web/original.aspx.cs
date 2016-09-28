using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UnitTestingTheImpossible.Web
{
  public partial class original : System.Web.UI.Page
  {

    private static readonly List<Models.Product> _Products = new List<Models.Product>
    {
      new Models.Product { ID=1, Name="Mop",              Price=5.21M },
      new Models.Product { ID=2, Name="Laundry Soap",     Price=10.22M },
      new Models.Product { ID=3, Name="Cleaning Spray",   Price=5.09M },
      new Models.Product { ID=4, Name="Cleaning Gloves",  Price=5.27M }
    };


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
      grid.DataSource = _Products;
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

    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

      var selectedProduct = _Products.First(p => p.ID == (int)e.Keys[0]);
      selectedProduct.Name = e.NewValues["Name"].ToString();
      selectedProduct.Price = decimal.Parse(e.NewValues["Price"].ToString());

      grid.EditIndex = -1;
      BindData();

    }
  }
}