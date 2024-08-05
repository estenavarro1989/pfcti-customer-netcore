using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
    public IActionResult addCustomer([FromBody] Customer customer)
    {
        repository.AddCustomer(customer);
        return Ok("Creator created successfully.");
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

    private object CreateValidationErrorResponse(ModelStateDictionary modelState)
    {
        var errors = modelState
            .Where(e => e.Value.Errors.Count > 0)
            .ToDictionary(
                e => e.Key,
                e => e.Value.Errors.Select(x => x.ErrorMessage).ToArray()
            );

        // Create your custom error response object
        return new
        {
            errorMessage = "Here BadRequest Validation failed.",
            errorCode = 40002,
            details = errors  //or you can hide
        };
    }

}