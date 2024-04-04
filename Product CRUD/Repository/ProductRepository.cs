using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_CRUD.DB;
using Product_CRUD.Models;

namespace Product_CRUD.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Product> Add(ProductAddModel product)
        {

            var on122 = (product.CostPrice * 122.50)/100;
            var ten = on122+((on122 * 10) / 100);


            var productDetails = new Product() { 
                Name=product.Name,
                CostPrice = product.CostPrice,
                Qty =product.Qty,
                SalesPrice = ((product.CostPrice * 122.50) / 100) + (((product.CostPrice * 122.50) / 100)*10)/100,

        };

            var result= await _databaseContext.Products.AddAsync(productDetails);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task<Product> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Update(ProductAddModel product, int id)
        {
            var productDetails = new Product()
            {
                Name = product.Name,
                CostPrice = product.CostPrice,
                Qty = product.Qty,
                SalesPrice = ((product.CostPrice * 122.50) / 100) + (((product.CostPrice * 122.50) / 100) * 10) / 100,

            };
            var existProduct = await _databaseContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (existProduct != null)
            {
                existProduct.CostPrice = productDetails.CostPrice;
                existProduct.Qty = productDetails.Qty;
                existProduct.Name = productDetails.Name;
                existProduct.SalesPrice= productDetails.SalesPrice;

                 _databaseContext.Products.Update(existProduct);
                await _databaseContext.SaveChangesAsync();

            }
            return existProduct;
            
        }

        public async Task<Product> View(int id)
        {
            var result = await _databaseContext.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Product>> ViewAll()
        {
            var result = await _databaseContext.Products.ToListAsync();
            return result;
        }

       
    }
}
