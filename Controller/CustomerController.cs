using Microsoft.AspNetCore.Mvc;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository repository;

    public CustomerController(ICustomerRepository repository)
    {
        this.repository = repository;
    }

    [HttpPost]
    [Route("api/customers")]
    public void addCustomer([FromBody] Customer customer)
    {
        repository.AddCustomer(customer);
    }

    [HttpPut]
    [Route("api/customers")]
    public void editCustomer([FromBody] Customer customer)
    {
        repository.EditCustomer(customer);
    }

    [HttpDelete]
    [Route("api/customers/{id}")]
    public void deleteCustomer(string id)
    {
        repository.DeleteCustomer(id);
    }

    [HttpGet]
    [Route("api/customers/{id}")]
    public Customer getCustomerById(string id)
    {
        return repository.GetCustomerById(id);
    }

    [HttpGet]
    [Route("api/customers/name")]
    public IEnumerable<Customer> GetCustomersOrderByName()
    {
        return repository.GetCustomerOrderByName();
    }

    [HttpGet]
    [Route("api/customers/id")]
    public IEnumerable<Customer> GetCustomersOrderById()
    {
        return repository.GetCustomerOrderById();
    }

    [HttpGet]
    [Route("api/customers/birthDate")]
    public IEnumerable<Customer> GetCustomerOrderByBirthDate()
    {
        return repository.GetCustomerOrderByBirthDate();
    }

}