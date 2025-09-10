using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace facturaApp.domain
{
    public class billDetails
    {
        public int code {  get; set; }
        public int id {  get; set; }

        public int nro { get; set; }
        public int count {  get; set; }

        public double price { get; set; }    



        public double total() 
        { 
            return price * count;
        }

        public override string ToString()
        {
            return code +"-"+ id + "-" + nro + "-" + count + "-" + total();
        }
    }
}
