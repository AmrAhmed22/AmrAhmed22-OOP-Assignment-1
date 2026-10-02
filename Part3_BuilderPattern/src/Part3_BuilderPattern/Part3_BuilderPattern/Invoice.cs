using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern
{
    public class Invoice
    {

        public string InvoiceId { get; }
        public string CustomerName { get; }
        public string CustomerEmail { get; }
        public string? CustomerPhone { get; }
        public Address BillingAddress { get; }
        public Address? ShippingAddress { get; }
        public Order order { get; }

        internal Invoice(string invoiceId, string customerName, string customerEmail,
            string? customerPhone, Address billingAddress, Address? shippingAddress, Order order)
        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            BillingAddress = billingAddress;
            ShippingAddress = shippingAddress;
            this.order = order;
        }



    }
}
