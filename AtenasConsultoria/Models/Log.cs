using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtenasConsultoria.Models
{
    public class Log
    {
        public DateTime lancamento { get; set; }
        public String userId { get; set; }
        public String Cod_nota { get; set; }
        public User user { get; set; }

    }
}
