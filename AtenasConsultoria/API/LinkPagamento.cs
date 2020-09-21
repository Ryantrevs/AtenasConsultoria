using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtenasConsultoria.API
{
    public class LinkPagamento
    {
        public String api_key { get; set; }
        public String name { get; set; }
        public float amount { get; set; }
        public List<items> Items { get; set; }
        public payment_config  payment_Config { get; set; }

        public void AddItem(items items)
        {
            Items.Add(items);
        }
    }

    

}
