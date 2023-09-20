using BlazorApplication.DTO;
using BlazorApplication.Models;
using BlazorApplication.Repo;

namespace BlazorApplication.Services
{
    public class CustomerTableService
    {
        
        private readonly ICustomerTableRepo repo;
        public CustomerTableService(ICustomerTableRepo repo)
        {
            this.repo = repo;
        }
        public List<CustomerTableDTO> GetAllCustomers()
        {
            List<CustomerTable> customerTables = repo.GetAll();
            List<CustomerTableDTO> customerTableDTOs = new List<CustomerTableDTO>();
            if (customerTables == null)
            {
                return null;
            }

            else
            {
                foreach (CustomerTable customerTable in customerTables)
                {
                    CustomerTableDTO customerTableDTO = new CustomerTableDTO()
                    {
                        CustomerID = customerTable.CustomerID,
                        Cus_Age = customerTable.Cus_Age,
                        Cus_Name = customerTable.Cus_Name,
                        Cus_Product = customerTable.Cus_Product
                    };
                    customerTableDTOs.Add(customerTableDTO);
                }
                return customerTableDTOs;
            }


        }
        public CustomerTableDTO GetCustomer(int id)
        {
            CustomerTable customerTable = repo.GetByID(id);

            if (customerTable == null)
            {
                return null;
            }

            else
            {

                CustomerTableDTO customerTableDTO = new CustomerTableDTO()
                {
                    CustomerID = customerTable.CustomerID,
                    Cus_Age = customerTable.Cus_Age,
                    Cus_Name = customerTable.Cus_Name,
                    Cus_Product = customerTable.Cus_Product
                };

                return customerTableDTO;
            }


        }
        public string AddCustomer(CustomerTableDTO customerDTO)
        {
            if (customerDTO != null)
            {
                CustomerTable customerTable = new CustomerTable()
                {
                    CustomerID = customerDTO.CustomerID,
                    Cus_Age = customerDTO.Cus_Age,
                    Cus_Name = customerDTO.Cus_Name,
                    Cus_Product = customerDTO.Cus_Product
                };

                repo.AddCustomer(customerTable);
                return "Addd";
            }
            else
            {
                return "Enter Data First";
            }

        }
        public string UpdateCustomer(CustomerTableDTO customerDTO)
        {
            
                CustomerTable customerTable = new CustomerTable()
                {
                    CustomerID = customerDTO.CustomerID,
                    Cus_Age = customerDTO.Cus_Age,
                    Cus_Name = customerDTO.Cus_Name,
                    Cus_Product = customerDTO.Cus_Product
                };

                repo.UpdateCustomer(customerTable);
                return "Updated";
           
           
        }
        public string DeleteCustomer(int customerDTO)
        {
           
                repo.DeleteCustomer(customerDTO);
                return "Deleted";
          

        }
    }
}
