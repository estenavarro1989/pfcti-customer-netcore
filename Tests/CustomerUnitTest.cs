using System.Data.Common;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Tests;


public class CustomerUnitTest
{
    [Fact]
    public void TestAddCustomer()
    {

        InsertCustomer customer = new InsertCustomer()
        {
            Id = "123456789012345678901234567890123456789012345678901",
            FirstName = "John",
            LastName = "Doe",
            Phone = "+50688888888",
            BirthDate = default(DateTime)
        };

        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();

        var controller = new CustomerController(repository.Object);

        var result = controller.addCustomer(customer);
        var data = ((OkObjectResult)result).Value as Customer;

        Assert.IsType<OkObjectResult>(result);
        Assert.Contains("123456789012345678901234567890123456789012345678901", data.Id);
        Assert.Contains("John", data.FirstName);
        Assert.Contains("Doe", data.LastName);
        Assert.Contains("+50688888888", data.Phone);
        Assert.Contains("1/1/0001 12:00:00 AM", data.BirthDate.ToString());

    }

    [Fact]
    public void TestEditCustomer()
    {

        Customer customer = new Customer()
        {
            FirstName = "John",
            LastName = "Doe",
            Phone = "+50688888888",
            BirthDate = default(DateTime)
        };

        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();
        repository.Setup(repo => repo.EditCustomer("100", customer)).Returns(customer);

        var controller = new CustomerController(repository.Object);

        var result = controller.editCustomer("100", customer);
        var data = ((OkObjectResult)result).Value as Customer;

        Assert.IsType<OkObjectResult>(result);

        Assert.Contains("John", data.FirstName);
        Assert.Contains("Doe", data.LastName);
        Assert.Contains("+50688888888", data.Phone);
        Assert.Contains("1/1/0001 12:00:00 AM", data.BirthDate.ToString());
    }

    [Fact]
    public void TestDeleteCustomer()
    {

        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();

        var controller = new CustomerController(repository.Object);

        var result = controller.deleteCustomer("100");

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public void TestGetCustomersOrderById()
    {

        Customer customer = new Customer("100")
        {
            FirstName = "John",
            LastName = "Doe",
            Phone = "+50688888888",
            BirthDate = default(DateTime)
        };
        List<Customer> customers = [customer];

        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();
        repository.Setup(repo => repo.GetCustomerOrderById()).Returns(customers);

        var controller = new CustomerController(repository.Object);
        var result = controller.GetCustomersOrderById();
        var data = ((OkObjectResult)result).Value as List<Customer>;

        Assert.IsType<OkObjectResult>(result);
        Assert.Contains("100", data.First().Id);
        Assert.Contains("John", data.First().FirstName);
        Assert.Contains("Doe", data.First().LastName);
        Assert.Contains("+50688888888", data.First().Phone);
        Assert.Contains("1/1/0001 12:00:00 AM", data.First().BirthDate.ToString());
    }

    [Fact]
    public void TestGetCustomerById()
    {

        Customer customer = new Customer()
        {
            FirstName = "John",
            LastName = "Doe",
            Phone = "+50688888888",
            BirthDate = default(DateTime)
        };

        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();
        repository.Setup(repo => repo.GetCustomerById("100")).Returns(customer);

        var controller = new CustomerController(repository.Object);

        var result = controller.getCustomerById("100");
        var data = ((OkObjectResult)result).Value as Customer;

        Assert.IsType<OkObjectResult>(result);

        Assert.Contains("John", data.FirstName);
        Assert.Contains("Doe", data.LastName);
        Assert.Contains("+50688888888", data.Phone);
        Assert.Contains("1/1/0001 12:00:00 AM", data.BirthDate.ToString());
    }

    [Fact]
    public void TestGetCustomersOrderByBirthDate()
    {

        Customer customer = new Customer("100")
        {
            FirstName = "John",
            LastName = "Doe",
            Phone = "+50688888888",
            BirthDate = default(DateTime)
        };
        List<Customer> customers = [customer];

        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();
        repository.Setup(repo => repo.GetCustomerOrderByBirthDate()).Returns(customers);

        var controller = new CustomerController(repository.Object);
        var result = controller.GetCustomerOrderByBirthDate();
        var data = ((OkObjectResult)result).Value as List<Customer>;

        Assert.IsType<OkObjectResult>(result);
        Assert.Contains("100", data.First().Id);
        Assert.Contains("John", data.First().FirstName);
        Assert.Contains("Doe", data.First().LastName);
        Assert.Contains("+50688888888", data.First().Phone);
        Assert.Contains("1/1/0001 12:00:00 AM", data.First().BirthDate.ToString());
    }

    [Fact]
    public void TestGetCustomersOrderByName()
    {

        Customer customer = new Customer("100")
        {
            FirstName = "John",
            LastName = "Doe",
            Phone = "+50688888888",
            BirthDate = default(DateTime)
        };
        List<Customer> customers = [customer];

        Mock<ICustomerRepository> repository = new Mock<ICustomerRepository>();
        repository.Setup(repo => repo.GetCustomerOrderByName()).Returns(customers);

        var controller = new CustomerController(repository.Object);
        var result = controller.GetCustomersOrderByName();
        var data = ((OkObjectResult)result).Value as List<Customer>;

        Assert.IsType<OkObjectResult>(result);
        Assert.Contains("100", data.First().Id);
        Assert.Contains("John", data.First().FirstName);
        Assert.Contains("Doe", data.First().LastName);
        Assert.Contains("+50688888888", data.First().Phone);
        Assert.Contains("1/1/0001 12:00:00 AM", data.First().BirthDate.ToString());
    }

}
