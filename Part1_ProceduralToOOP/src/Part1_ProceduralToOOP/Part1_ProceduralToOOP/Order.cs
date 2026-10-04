using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP
{
    public class Order
    {
        private readonly List<OrderLine> _lines = new List<OrderLine>();
        private readonly decimal _discountRate;   

        public int Id { get; }
        public int CustomerId { get; }
        public DateOnly Date { get; }
        public bool IsPaid { get; private set; }


        public decimal Total
        {
            get
            {
                decimal sum = 0m;
                foreach (var line in _lines)
                {
                    sum += line.LineTotal;
                }
                return sum * (1 - _discountRate);
            }
        }
        internal Order(int id, int customerId, decimal discountRate, DateOnly date)
        {

            Id = id;
            CustomerId = customerId;
            _discountRate = discountRate;
            Date = date;
        }

        public void AddLine(Product product, int quantity)
        {
            if (IsPaid)
                throw new InvalidOperationException("Cannot change a paid order.");

            var line = new OrderLine(product, quantity);   
            product.RemoveStock(quantity);                
            _lines.Add(line);
        }

        public void MarkPaid()
        {
            if (IsPaid)
                throw new InvalidOperationException("Order is already paid.");
            if (_lines.Count == 0)
                throw new InvalidOperationException("Cannot pay an empty order.");

            IsPaid = true;
        }

        public List<OrderLine> GetLines()
        {
            return new List<OrderLine>(_lines);
        }
    }
}
