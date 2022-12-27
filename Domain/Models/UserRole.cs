using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Models
{
    public class UserRole
    {
        public string IdUser { get; set; }
        public string IdRole { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}
