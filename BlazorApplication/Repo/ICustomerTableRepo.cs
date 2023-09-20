using BlazorApplication.DTO;
using BlazorApplication.Models;

namespace BlazorApplication.Repo
{
    public interface ICustomerTableRepo
    {
        List<CustomerTable> GetAll();
        CustomerTable GetByID(int id);
        void AddCustomer(CustomerTable customer);
        void UpdateCustomer(CustomerTable customer);
        void DeleteCustomer(int customerID);

    }
}