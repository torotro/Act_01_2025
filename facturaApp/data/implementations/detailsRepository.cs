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
    internal class detailsRepository : IdetailsRepository
    {
        public List<billDetails> GetAll()
        {
            List<billDetails> lst = new List<billDetails>();
            var d = Datahelper.GetInstance().ExecuteSPQuery("sp_recuperar_Detalles");
            

            foreach (DataRow i in d.Rows)
            {
                billDetails bd = new billDetails();
                bd.id = (int)i["id_articulo"];
                bd.count = (int)i["cantidad"];
                bd.nro = (int)i["nroFactura"];
                bd.price = (double)i["monto"];

                lst.Add(bd);
            }
            return lst;
        }

        public billDetails? getbyid(int id)
        {
            throw new NotImplementedException();
        }

        public bool save(billDetails details)
        {
            throw new NotImplementedException();
        }
    }
}
