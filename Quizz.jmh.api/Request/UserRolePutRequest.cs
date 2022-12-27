using System.ComponentModel.DataAnnotations;

namespace Quizz.jmh.Api.Request
{
    public class UserRolePutRequest : IValidatableObject
    {
        [MaxLength(100)]
        public string RoleId { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RoleId == String.Empty)
            {
                yield return new ValidationResult("RoleId is not correct");
            }
        }
    }
}
