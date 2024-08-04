using System.ComponentModel.DataAnnotations;
public class DateLessThanOrEqualToToday : ValidationAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return "La fecha de nacimiento tiene que ser anterior al día de hoy";
    }

    protected override ValidationResult IsValid(object objValue,
                                                   ValidationContext validationContext)
    {
        var dateValue = objValue as DateTime? ?? new DateTime();

        //alter this as needed. I am doing the date comparison if the value is not null

        if (dateValue.Date > DateTime.Now.Date)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
        return ValidationResult.Success;
    }
}