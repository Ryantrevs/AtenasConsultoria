using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtenasConsultoria.Models
{
    public class ApiViewModel
    {
        public String name { get; set; }
        public float amount { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public float unit_price { get; set; }
        public int quantity { get; set; }
        public bool tangible { get; set; }
        public bool enabledCard { get; set; }
        public int free_installments { get; set; }
        public double interest_rate { get; set; }
        public int max_installments { get; set; }
        public bool enabledboleto { get; set; }
        public int expires_in { get; set; }


    }
}
