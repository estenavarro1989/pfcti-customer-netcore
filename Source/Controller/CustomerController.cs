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
    public IActionResult addCustomer([FromBody] InsertCustomer customer)
    {
        repository.AddCustomer(customer);
        return Ok(customer);
    }

    [HttpPut]
    [Route("api/customers/{id}")] 
    public IActionResult editCustomer(string id, [FromBody] Customer customer)
    {
        Customer editCustomer = repository.EditCustomer(id, customer);
        return Ok(editCustomer);
    }

    [HttpDelete]
    [Route("api/customers/{id}")]
    public IActionResult deleteCustomer(string id)
    {
        repository.DeleteCustomer(id);
        return Ok();
    }

    [HttpGet]
    [Route("api/customers/{id}")]
    public IActionResult getCustomerById(string id)
    {
        Customer customer =  repository.GetCustomerById(id);
        return Ok(customer);
    }

    [HttpGet]
    [Route("api/customers/name")]
    public IActionResult GetCustomersOrderByName()
    {
        return Ok(repository.GetCustomerOrderByName());
    }

    [HttpGet]
    [Route("api/customers/id")]
    public IActionResult GetCustomersOrderById()
    {
        return Ok(repository.GetCustomerOrderById());
    }

    [HttpGet]
    [Route("api/customers/birthDate")]
    public IActionResult GetCustomerOrderByBirthDate()
    {
        return Ok(repository.GetCustomerOrderByBirthDate());
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