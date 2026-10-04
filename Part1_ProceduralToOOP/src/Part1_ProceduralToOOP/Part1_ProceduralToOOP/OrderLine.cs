using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP
{
    public class OrderLine
    {
        public Product Product { get; }
        public int Quantity { get; }

        public decimal LineTotal => Product.Price * Quantity;

        internal OrderLine(Product product, int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.", nameof(quantity));

            Product = product;
            Quantity = quantity;
        }

    }
}
