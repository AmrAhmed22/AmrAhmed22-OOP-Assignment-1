using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int Stock { get; private set; }

        public Product(int id, string name, decimal price, int stock)
        {

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void RemoveStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be positive.", nameof(quantity));
            if (Stock < quantity)
                throw new InvalidOperationException($"Not enough stock for product #{Id}.");

            Stock -= quantity;
        }

        public override string ToString() => $"#{Id}  {Name}  price={Price:F2}  stock={Stock}";

    }
}
