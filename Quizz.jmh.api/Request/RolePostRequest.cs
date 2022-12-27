using System.ComponentModel.DataAnnotations;

namespace Quizz.jmh.Api.Request
{
    public class RolePostRequest : IValidatableObject
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == String.Empty)
            {
                yield return new ValidationResult("Name is not correct");
            }
        }
    }
}
