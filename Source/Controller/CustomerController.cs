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

    [HttpGet]
    [Route("api/customers/{id}")]
    public IActionResult getCustomerById(string id)
    {
        Customer customer =  repository.GetCustomerById(id);
        return Ok(customer);
    }
    
    [HttpDelete]
    [Route("api/customers/{id}")]
    public IActionResult deleteCustomer(string id)
    {
        repository.DeleteCustomer(id);
        return Ok();
    }

    [HttpGet]
    [Route("api/customers")]
    public IActionResult listCustomer([FromQuery(Name = "orderBy")] string orderBy)
    {
        if(orderBy == "birthDate")
        {
            return Ok(repository.GetCustomerOrderByBirthDate());
        } 
        else if (orderBy == "id")
        {
            return Ok(repository.GetCustomerOrderById());
        }
        else if (orderBy == "name")
        {
            return Ok(repository.GetCustomerOrderByName());
        }
        else 
        {
            return BadRequest();
        }
    }
}