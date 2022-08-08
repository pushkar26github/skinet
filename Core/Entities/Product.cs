using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public Product(int id) 
        {
            this.Id = id;
   
        }
        public int Id { get; set; }
     
        public String? Name { get; set; }
    }
}