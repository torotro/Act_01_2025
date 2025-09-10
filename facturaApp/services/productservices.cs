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
    public class productServices
    {
       
        
            private Iproductrepository _repository;
            public productServices()
            {
                _repository = new productRepository();
            }


          
            public List<Product> GetProducts()
            {
                return _repository.getall();
            }
            public Product? GetProduct(int id)
            {
                return _repository.getbyid(id);
            }

            public bool save(Product product)
            {
                bool result;
                var produtID = _repository.getbyid(product.Id);


                if (produtID != null)
                {
                    result = _repository.save(product);
                }
                else
                {
                    result = false;
                }

                return result;
            }
        
    }
}
