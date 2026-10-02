using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern
{
    internal class OrderBuilder
    {
        private readonly DateTime _orderDate;
        private readonly string _paymentMethod;
        private readonly string _currency;
        private readonly decimal _subTotal;

        private decimal _discount;

        public OrderBuilder(DateTime orderDate, string paymentMethod, string currency, decimal subTotal)
        {
             if (subTotal < 0)
                throw new ArgumentException("SubTotal cannot be negative.");

            _orderDate = orderDate;
            _paymentMethod = paymentMethod;
            _currency = currency;
            _subTotal = subTotal;
        }

        public OrderBuilder WithDiscount(decimal discount)
        {
            if (discount < 0) 
                throw new ArgumentException("Discount cannot be negative.");
           
            _discount = discount;
            return this;
        }

      

        public Order Build()
        {
            if (_subTotal + _subTotal * Order.TaxRate - _discount < 0)
                throw new InvalidOperationException("Discount cannot exceed subtotal plus tax.");

            return new Order(_orderDate, _paymentMethod, _currency, _subTotal, _discount);
        }
    }
}
