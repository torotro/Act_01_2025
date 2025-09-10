using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.domain
{
    public class Bill
    {
        public int id {  get; set; }
        public DateTime date {  get; set; }
        public int Type { get; set; }
        public string? client { get; set; }


        public List<billDetails>? details { get; set; }

      
            public Bill()
            {
                details = new List<billDetails>();
            }



        public override string ToString()
        {
            return  date + "-" + Type + "-" + client;
        }

    }
}
