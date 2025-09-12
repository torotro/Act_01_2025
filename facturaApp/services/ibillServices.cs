using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.services
{
    public interface ibillServices
    {
        List<Bill> getBills();
        Bill? getbillbyID(int id);
        bool save(Bill bill);
        
        bool delete(int id);

        bool Transaction(Bill bill);


    }
}
