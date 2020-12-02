using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaComercio.Entities
{
    class Product
    {
        public string NameProduct { get; set; }
        public double Price { get; set; }

        public Product()
        {
        }

        public Product(string nameProduct, double price)
        {
            NameProduct = nameProduct;
            Price = price;
        }
    }
}
