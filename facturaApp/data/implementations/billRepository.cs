using facturaApp.data.helpers;
using facturaApp.data.interfaces;
using facturaApp.domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data.implementations
{
    public class billRepository : IBillrepository
    {
        public bool delete(int id)
        {
            List<parameters> param = new List<parameters>()
            {
               new parameters("@id", id)
            };

            return Datahelper.GetInstance().ExecuteSPT("sp_eliminar_Facturas_nro", param);
            

        }

        public List<Bill> GetAll()
        {
            List<Bill> lst = new List<Bill>();

            var dt = Datahelper.GetInstance().ExecuteSPQuery("sp_recuperar_Facturas");
            foreach (DataRow item in dt.Rows)

            {

                Bill b = new Bill();
                
                b.id = (int)item["nroFactura"];
                b.date = (DateTime)item["fecha"];
                b.Type = (int)item["idforma"];
                b.client = (string)item["cliente"];
                List<parameters> details = new List<parameters>();
           
     
               
                lst.Add(b);
            }

            return lst;


        }

           
            
        

        public Bill? getbyid(int id)
        {
            List<parameters> b = new List<parameters>()
           {
               new parameters()
               {
                   Name="@id",
                   Valor=id
               }


           };
            var dt = Datahelper.GetInstance().ExecuteSPQuery("sp_recuperar_Facturas_nro", b);

            if (dt != null && dt.Rows.Count > 0)
            {
               
               
                Bill br = new Bill()
                {
                    
                    id= (int)dt.Rows[0]["nroFactura"],
                    date = (DateTime)dt.Rows[0]["fecha"],
                    Type = (int)dt.Rows[0]["idforma"],
                    client = (string)dt.Rows[0]["cliente"],

                };

                return br;

            }
            return null;
        }

        public bool save(Bill bill)
        {
            List<parameters> param = new List<parameters>()
            {

                //new parameters("@nro", bill.id),
                new parameters("@fecha", bill.date),
                new parameters("@tipo", bill.Type),
                new parameters("@cliente", bill.client)
            };

            return Datahelper.GetInstance().ExecuteSPT("sp_insertar_Maestro", param);

        }
        
        public bool update(Bill bill)
        {
            List<parameters> param = new List<parameters>()
            {

                new parameters("@nro", bill.id),
                new parameters("@fecha", bill.date),
                new parameters("@tipo", bill.Type),
                new parameters("@cliente", bill.client)
            };

            return Datahelper.GetInstance().ExecuteSPT("sp_actualizar_Maestro", param);

        }
    }
}
