using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer(string id)
    {
        Id = id;
    }

    public string Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
    public DateTime BirthDate { get; set; }
}

