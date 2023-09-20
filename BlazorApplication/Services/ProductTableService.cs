using BlazorApplication.DTO;
using BlazorApplication.Models;
using BlazorApplication.Repo;


namespace BlazorApplication.Services
{
    public class ProductTableService
    {
        private readonly IProductTablePrpo repo;
        

        public ProductTableService(IProductTablePrpo repo)
        {
            this.repo = repo;
        }
        public List<ProductTableDTO> GetAllProducts()
        {
            List<ProductTable> productTables = repo.GetAll();
            List<ProductTableDTO > productTableDTOs = new List<ProductTableDTO>();
            if (productTables == null)
            {
                return null;
            }
            else
            {
                foreach (ProductTable  productTable in productTables) 
                {
                    ProductTableDTO productTableDTO = new ProductTableDTO()
                    {
                        ProductName = productTable.ProductName,
                        ProColor = productTable.ProColor,
                        ProductID = productTable.ProductID,
                        ProPrice = productTable.ProPrice,
                        ProQuantity = productTable.ProQuantity
                    };
                    productTableDTOs .Add(productTableDTO);
                
                }
                return productTableDTOs;
            }

        }
        public ProductTableDTO GetProduct(int id)
        {
           
            ProductTable productTable = repo.GetByID(id);
            if (productTable == null)
            { 
                return null; 
            }
            else
            { 
                    ProductTableDTO productTableDTO = new ProductTableDTO()
                    {
                        ProductName = productTable.ProductName,
                        ProColor = productTable.ProColor,
                        ProductID = productTable.ProductID,
                        ProPrice = productTable.ProPrice,
                        ProQuantity = productTable.ProQuantity
                    };
                
                return productTableDTO;
            }
           
        }
        public String AddProduct (ProductTableDTO productDot)
        {
     if (productDot == null)
            {
                return " Add Data First";
            
            }


     else
            {
                ProductTable productTable = new ProductTable()
                {
                ProColor = productDot.ProColor,
                ProductID = productDot.ProductID,
                ProPrice = productDot.ProPrice,
                ProQuantity = productDot.ProQuantity,
                ProductName=productDot.ProductName
                };
                repo.AddProduct(productTable);
                return "Addad";
            }
        }
     
        public string DeleteProduct(int productDOT)
        {
            repo.DeleteProduct(productDOT);
            return "Deleted";
        }
   
        public String UpdateProduct(ProductTableDTO productDot)
        { 
                ProductTable productTable = new ProductTable()
                {
                    ProColor = productDot.ProColor,
                    ProductID = productDot.ProductID,
                    ProPrice = productDot.ProPrice,
                    ProQuantity = productDot.ProQuantity,
                      ProductName=productDot.ProductName,
                };
                repo.UpdateProduct(productTable);
                return "Deleted";
            
        }














    }
}
