using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class ProductService  : DefaultService<Product>
    {
        public ProductService(TestDbContext ctx) : base(ctx)
    {
    }

        public override DefaultList<Product> GetList(int page)
		{
			var products = _ctx.Products.ToList().Skip(((page - 1) * 10)).Take(10).ToList();
			var productsAll = _ctx.Products.ToList();	

            return new ProductList() {  HasNext= (page * 10)< productsAll.Count(), TotalCount = products.Count(), Items = products };
		}

	}
}
