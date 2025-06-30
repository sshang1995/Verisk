using Products.Models;

namespace Products.Services
{
    public class ProductService: IProductService
    {
        private readonly List<Product> _products = new List<Product>();
        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public Product? GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
        public Product CreateProduct(Product product)
        {
            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
            return product;
        }
        public Product? UpdateProduct(int id, Product product)
        {
            var existingProduct = GetProductById(id);
            if (existingProduct == null) return null;
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.UpdatedAt = DateTime.UtcNow;
            return existingProduct;
        }
        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null) return false;
            _products.Remove(product);
            return true;
        }
    }
}
