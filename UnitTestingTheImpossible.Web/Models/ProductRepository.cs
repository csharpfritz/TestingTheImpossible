using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestingTheImpossible.Web.Models
{

  public class ProductRepository
  {

    private static readonly List<Models.Product> _Products = new List<Models.Product>
    {
      new Models.Product { ID=1, Name="Mop",              Price=5.21M },
      new Models.Product { ID=2, Name="Laundry Soap",     Price=10.22M },
      new Models.Product { ID=3, Name="Cleaning Spray",   Price=5.09M },
      new Models.Product { ID=4, Name="Cleaning Gloves",  Price=5.27M }
    };

    public virtual IQueryable<Product> Get()
    {
      return _Products.AsQueryable();
    }

    public Product Get(int id)
    {
      return _Products.First(p => p.ID == id);
    }

    public virtual void Save(Product newProduct)
    {

      // Validation
      if (newProduct.Price < 0) throw new ApplicationException("Price must be greater than $0.00");

      if (_Products.Any(p => p.ID == newProduct.ID))
      {
        _Products.Remove(_Products.First(p => p.ID == newProduct.ID));
      }

      _Products.Add(newProduct);

    }

  }

}