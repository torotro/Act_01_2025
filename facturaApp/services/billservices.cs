using facturaApp.data;
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
    public class Billservices :ibillServices
    {
        private IBillrepository _repository;
        public Billservices()
        {
            _repository = new billRepository();
        }

        public List<Bill> getBills()
        {
            return _repository.GetAll();
        }

        public Bill? getbillbyID(int id)
        {
            return _repository.getbyid(id);
        }
        public bool save(Bill bill)
        {
            var existingBill = _repository.getbyid(bill.id);

            if (existingBill != null)
            {

                return _repository.update(bill);
            }

            
            return _repository.save(bill);

        }

        public bool delete(int id)
        {
            var billBD = _repository.getbyid(id);

            if (billBD == null)
                return false;

            return _repository.delete(id);

        }

        public bool Transaction(Bill bill)
        {
            return Datahelper.GetInstance().executeTransaction(bill);
        }

    }

}
