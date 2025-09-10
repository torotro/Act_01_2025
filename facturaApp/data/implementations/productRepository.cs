using facturaApp.data.helpers;
using facturaApp.data.interfaces;
using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data.implementations
{
    internal class productRepository : Iproductrepository
    {
        
        public List<Product> getall()
        {
            List<Product>lst = new List<Product>();

            var dt = Datahelper.GetInstance().ExecuteSPQuery("sp_recuperar_Articulos");
            foreach (DataRow item in dt.Rows) 
            {

                Product p = new Product();
                p.Id = Convert.ToInt32(item["id_articulo"]);
                p.Name=(string)item["nombre"];
                p.UnitPrice = Convert.ToDouble(item["precioUnitario"]);
                p.stock = (int)item["stock"];
                lst.Add(p);

            }

            return lst;
        }

        public Product? getbyid(int id)
        {
            List<parameters> p = new List<parameters>()
           {
               new parameters()
               {
                   Name="@id",
                   Valor=id
               }

              
           };
            var dt = Datahelper.GetInstance().ExecuteSPQuery("sp_recuperar_Articulos_id", p);

            if (dt != null && dt.Rows.Count > 0)
            {
                Product pr = new Product()
                {
                    Id = (int)dt.Rows[0]["id_articulo"],
                    Name = (string)dt.Rows[0]["nombre"],
                    UnitPrice = Convert.ToDouble(dt.Rows[0]["precioUnitario"]),
                    stock = (int)dt.Rows[0]["stock"],
                   
                };

                return pr;
            }

            return null;

        }

        public bool save(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
