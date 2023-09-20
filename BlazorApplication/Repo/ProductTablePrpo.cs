using BlazorApplication.Data;
using BlazorApplication.Models;

namespace BlazorApplication.Repo
{
    public class ProductTablePrpo : IProductTablePrpo
    {
        private readonly FirstTaskContext context;

        public ProductTablePrpo(FirstTaskContext context)
        {
            this.context = context;
        }
        public List<ProductTable> GetAll()
        {
            return context.ProductTabes.ToList();
        }
        public ProductTable GetByID(int id)
        {
            return context.ProductTabes.SingleOrDefault(p => p.ProductID == id);
        }
        public void AddProduct(ProductTable product)
        {
            context.ProductTabes.Add(product);
            context.SaveChanges();
        }
        public void UpdateProduct(ProductTable product)
        {
            var ExitingProduct = context.ProductTabes.Find(product.ProductID);
            if (ExitingProduct != null)
            {
                ExitingProduct.ProPrice = product.ProPrice;
                ExitingProduct.ProductName = product.ProductName;
                ExitingProduct.ProQuantity = product.ProQuantity;
                ExitingProduct.ProColor = product.ProColor;
                context.SaveChanges();
            }
            
            
        }
        public void DeleteProduct(int productID)
        {
            var product = context.ProductTabes.Find(productID);
            context.ProductTabes.Remove(product);
            context.SaveChanges();
        }
    }
}
