using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer(string id)
    {
        id = id;
    }

    public Customer() { }
    
    public string? id { get; set; }
    public string? firstName { get; set; }
    public string? lastName { get; set; }
    public string? phone { get; set; }
    public DateTime? birthDate { get; set; }
}