using BlazorApplication.Data;
using BlazorApplication.Models;

namespace BlazorApplication.Repo
{
    public class CustomerTableRepo : ICustomerTableRepo
    {
        private readonly FirstTaskContext context;
        public CustomerTableRepo(FirstTaskContext context)
        {
            this.context = context;
        }
        public List<CustomerTable> GetAll()
        {
            return context.CustomerTables.ToList();
        }
     
        public CustomerTable GetByID(int id)
        {
            return context.CustomerTables.SingleOrDefault(C => C.CustomerID == id);
        }
        public void AddCustomer(CustomerTable customer)
        {
            context.CustomerTables.Add(customer);
            context.SaveChanges();
        }
        public void UpdateCustomer(CustomerTable customer)
        {
            var ExitingCustomer= context.CustomerTables.SingleOrDefault(C => C.CustomerID == customer.CustomerID);
            if (ExitingCustomer != null)
            {
                ExitingCustomer.Cus_Name = customer.Cus_Name;
                ExitingCustomer.Cus_Age = customer.Cus_Age;
                ExitingCustomer.Cus_Product = customer.Cus_Product;
                context.SaveChanges();
            }
           
            
        }
        public void DeleteCustomer(int customerID)
        {
            var cus = context.CustomerTables.Find( customerID);
            context.CustomerTables.Remove(cus);
            context.SaveChanges();
        }
        //public void DeleteCustomer(int customerID)
        //{
        //    var cus = context.CustomerTables.SingleOrDefault(c => c.CustomerID == customerID);
        //    context.CustomerTables.Remove(cus);
        //    context.SaveChanges();
        //}
       
    }
}
