using System;
using System.Web.UI.WebControls;

namespace UnitTestingTheImpossible.Web._3
{

  public interface IGridPage
  {

    event EventHandler Load;

    bool IsPostBack { get; }

    GridView Grid { get; }

  }
}