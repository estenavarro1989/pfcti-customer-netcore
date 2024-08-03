using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
    public string? FirstName { get; set; }
    public string? lastName { get; set; }
    public string? phone { get; set; }
    public DateTime birthDate { get; set; }
}

