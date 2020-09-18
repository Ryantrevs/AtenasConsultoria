using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AtenasConsultoria.Models
{
    public class User : IdentityUser
    {
        public String Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public List<Log> Log { get; set; }

    }
}
