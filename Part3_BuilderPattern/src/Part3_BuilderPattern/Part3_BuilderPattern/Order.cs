using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern
{
    public class Order
    {
        public static readonly decimal TaxRate = 0.14m;
        public DateTime OrderDate { get; } = DateTime.Now;
        public string PaymentMethod { get; }
        public string Currency { get; }
        public decimal SubTotal { get; }
        public decimal DiscountAmount { get; }

        public decimal TaxAmount => SubTotal * TaxRate;
        public decimal TotalAmount => SubTotal + TaxAmount - DiscountAmount;

        internal Order(DateTime orderDate, string paymentMethod, string currency,
            decimal subTotal, decimal discountAmount)
        {
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
        }
    }
}
