using System.ComponentModel.DataAnnotations;

namespace GuestBook.Models.Requests;
public class GuestBookReadRequestModel : IValidatableObject
{
    [Required]
    public int Id { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Id <= 0)
        {
            yield return new ValidationResult("Id must be greater than 0", new[] { nameof(Id) });
        }
    }
}
