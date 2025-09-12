using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data.interfaces
{
    internal interface IBillrepository
    {
        List<Bill> GetAll();
        Bill? getbyid(int id);
        bool save(Bill bill);

        bool update(Bill bill);
        bool delete(int id);

    }
}
