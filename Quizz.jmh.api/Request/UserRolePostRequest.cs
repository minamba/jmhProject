using System.ComponentModel.DataAnnotations;

namespace Quizz.jmh.Api.Request
{
    public class UserRolePostRequest : IValidatableObject
    {

        [MaxLength(100)]
        public string UserId { get; set; }

        [MaxLength(100)]
        public string RoleId { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (UserId == String.Empty)
            {
                yield return new ValidationResult("UserId is not correct");
            }
            if (RoleId == String.Empty)
            {
                yield return new ValidationResult("RoleId is not correct");
            }
        }
    }
}
