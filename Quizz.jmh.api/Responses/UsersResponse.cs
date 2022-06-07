using Quizz.jmh.api.ViewModels;

namespace Quizz.jmh.Api.Responses
{
    public class UsersResponse
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
