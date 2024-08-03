using Microsoft.AspNetCore.Mvc;

[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository repository;

    public CustomerController(ICustomerRepository repository)
    {
        this.repository = repository;
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