using System.ComponentModel.DataAnnotations;

namespace Quizz.jmh.Api.Request
{
    public class UserPutRequest : IValidatableObject
    {
    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(50)]
    public string Pseudonym { get; set; }

    [MaxLength(5)]
    public string Sexe { get; set; }
    [MaxLength(100)]
    public string LevelId { get; set; }
    [MaxLength(320)]
    public string Mail { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FirstName == String.Empty)
        {
            yield return new ValidationResult("FirstName is not correct");
        }
        if (LastName == String.Empty)
        {
            yield return new ValidationResult("LastName is not correct");
        }
        if (Pseudonym == String.Empty)
        {
            yield return new ValidationResult("Pseudonym is not correct");
        }
        if (Sexe == String.Empty)
        {
            yield return new ValidationResult("Sexe is not correct");
        }
        if (Mail == String.Empty)
        {
            yield return new ValidationResult("Mail is not correct");
        }
    }
}
    
}

