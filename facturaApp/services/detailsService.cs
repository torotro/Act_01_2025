using facturaApp.data.implementations;
using facturaApp.data.interfaces;
using facturaApp.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facturaApp.services
{
    public class detailsService
    {
        private IdetailsRepository _repository;
        public detailsService()
        {
            _repository = new detailsRepository();
        }

        public List<billDetails> getDetail()
        {
            return _repository.GetAll();
        }

        public bool save(billDetails bd)
        {
            return _repository.save(bd);
        }
    }
}
