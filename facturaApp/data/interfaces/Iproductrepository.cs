using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data.interfaces
{
    internal interface Iproductrepository
    {
        List<Product> getall();
        Product? getbyid(int id);
        bool save(Product product);
       
    }
}
