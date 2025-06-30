using Products.Models;

namespace Products.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProductById(int id);
        Product CreateProduct(Product product);
        Product? UpdateProduct(int id, Product product);
        bool DeleteProduct(int id);
    }
}
