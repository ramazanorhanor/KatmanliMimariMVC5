using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Katmani
{
    public class Product
    {
        public int Id { get; set; }            // Primary Key
        public string Name { get; set; }       // Ürün adı
        public decimal Price { get; set; }     // Ürün fiyatı
    }
}
