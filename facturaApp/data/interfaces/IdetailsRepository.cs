using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.data.interfaces
{
    internal interface IdetailsRepository
    {
        List<billDetails> GetAll();
        billDetails? getbyid(int id);
        bool save(billDetails details);
    }
}
