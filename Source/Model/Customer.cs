using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer(string id)
    {
        Id = id;
    }

    public Customer() { }
    
    public virtual string? Id { get; set; }
    
    [MaxLength(20, ErrorMessage = "El máximo de caracteres del nombre es de 20")]
    public virtual string? FirstName { get; set; }

    [MaxLength(20, ErrorMessage = "El máximo de caracteres del apellido es de 20")]
    public virtual string? LastName { get; set; }

    [MaxLength(20, ErrorMessage = "El máximo de caracteres del teléfono es de 20")]
    public string? Phone { get; set; }
    [DateLessThanOrEqualToToday]
    public DateTime? BirthDate { get; set; }
}

public class InsertCustomer : Customer
{
    [Required(ErrorMessage = "El id del cliente es requerido")]
    [MaxLength(50, ErrorMessage = "El máximo de caracteres del id es de 50")]
    public override string? Id { get; set; }

    [Required(ErrorMessage = "El nombre del cliente es requerido")]
    public override string? FirstName { get; set; }

    [Required(ErrorMessage = "El apellido del cliente es requerido")]
    public override string? LastName { get; set; }
}