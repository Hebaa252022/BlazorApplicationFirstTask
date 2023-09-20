using BlazorApplication.Models;

namespace BlazorApplication.Repo
{
    public interface IProductTablePrpo
    {
        void AddProduct(ProductTable product);
        void DeleteProduct(int productID);
        List<ProductTable> GetAll();
        ProductTable GetByID(int id);
        void UpdateProduct(ProductTable product);
    }
}