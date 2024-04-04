using Product_CRUD.DB;
using Product_CRUD.Models;

namespace Product_CRUD.Repository
{
    public interface IProductRepository
    {
        Task <Product> Add(ProductAddModel product);
        Task <Product> Update(ProductAddModel product,int id);
        Task <Product> Delete(int id);
        Task <Product> View(int id);
        Task <List<Product>> ViewAll();
    }
}
