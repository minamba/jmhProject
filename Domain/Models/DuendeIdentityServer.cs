using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizz.jmh.Domain.Models
{
    public class DuendeIdentityServer
    {
        public string DiscoveryUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientPassword { get; set; }
        public bool UseHttps { get; set; }
    }
}
