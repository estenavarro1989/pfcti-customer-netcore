using System.ComponentModel.DataAnnotations;

public class Customer
{
    public Customer(string id)
    {
        Id = id;
    }

    public Customer() { }

    [Required(ErrorMessage = "El id del cliente es requerido")]
    [MaxLength(50, ErrorMessage = "El máximo de caracteres del id es de 50")]
    public string? Id { get; set; }

    [Required(ErrorMessage = "El nombre del cliente es requerido")]
    [MaxLength(20, ErrorMessage = "El máximo de caracteres del apellido es de 20")]
    public string? FirstName { get; set; }
    [MaxLength(20, ErrorMessage = "El máximo de caracteres del apellido es de 20")]
    [Required(ErrorMessage = "El apellido del cliente es requerido")]
    public string? LastName { get; set; }

    [MaxLength(20, ErrorMessage = "El máximo de caracteres del teléfono es de 20")]
    public string? Phone { get; set; }
    [DateLessThanOrEqualToToday]
    public DateTime BirthDate { get; set; }
}