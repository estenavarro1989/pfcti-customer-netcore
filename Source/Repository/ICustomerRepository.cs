public interface ICustomerRepository
{
    void AddCustomer(Customer customer);
    void EditCustomer(Customer customer);
    void DeleteCustomer(string id);
    Customer GetCustomerById(string id);
    IEnumerable<Customer> GetCustomerOrderByName();
    IEnumerable<Customer> GetCustomerOrderById();
    IEnumerable<Customer> GetCustomerOrderByBirthDate();
}