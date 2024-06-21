using Microsoft.EntityFrameworkCore;
using RapidBootcamp.BackendAPI.Models;

namespace RapidBootcamp.BackendAPI.DAL
{
    public class ProductEF : IProduct
    {
        private readonly AppDbContext _appDbContext;
        public ProductEF(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Product Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            var results = _appDbContext.Products.OrderBy(p => p.ProductName).ToList();
            return results;
        }

        public IEnumerable<Product> GetByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            Product result = _appDbContext.Products.Include(p => p.Category)
                .FirstOrDefault(p => p.ProductId == id);
            if (result == null)
            {
                throw new Exception("Product not found");
            }
            return result;
        }

        public IEnumerable<Product> GetByProductName(string productName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducsWithCategory()
        {
            var results = _appDbContext.Products.Include(p => p.Category)
                .OrderBy(p => p.ProductName).ToList();
            return results;
        }

        public int GetProductStock(int productId)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product entity)
        {
            try
            {
                var updateProduct = GetById(entity.ProductId);
                updateProduct.ProductName = entity.ProductName;
                updateProduct.CategoryId = entity.CategoryId;
                updateProduct.Stock = entity.Stock;
                updateProduct.Price = entity.Price;
                _appDbContext.SaveChanges();
                return updateProduct;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
