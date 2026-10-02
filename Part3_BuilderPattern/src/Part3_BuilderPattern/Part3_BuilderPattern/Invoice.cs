using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern
{
    public class Invoice
    {

        public static readonly decimal TaxRate = 0.14m;

        public string InvoiceId { get; private set; }
        public string CustomerName { get; private set; }

        public string? CustomerEmail { get; private set; }
        public string? CustomerPhone { get; private set; }

        public string? BillingStreet { get; private set; }
        public string? BillingCity { get; private set; }
        public string? BillingState { get; private set; }
        public string? BillingZipCode { get; private set; }
        public string? BillingCountry { get; private set; }
                     
        public string? ShippingStreet { get; private set; }
        public string? ShippingCity { get; private set; }
        public string? ShippingState { get; private set; }
        public string? ShippingZipCode { get; private set; }
        public string? ShippingCountry { get; private set; }


        public DateTime OrderDate { get; private set; } = DateTime.Now;
        public string? PaymentMethod { get; private set; }
        public string Currency { get; private set; } = "EGP";
        public decimal SubTotal { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public decimal TaxAmount => SubTotal * TaxRate;
        public decimal TotalAmount => SubTotal + TaxAmount - DiscountAmount;
       
     

        internal Invoice(
            string invoiceId, string customerName, string? customerEmail, string? customerPhone,
            string? billingStreet, string? billingCity, string? billingState,
            string? billingZipCode, string? billingCountry,
            string? shippingStreet, string? shippingCity, string? shippingState,
            string? shippingZipCode, string? shippingCountry,
            DateTime orderDate, string? paymentMethod, string currency,
            decimal subTotal, decimal discountAmount)
        {
            InvoiceId = invoiceId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerPhone = customerPhone;
            BillingStreet = billingStreet;
            BillingCity = billingCity;
            BillingState = billingState;
            BillingZipCode = billingZipCode;
            BillingCountry = billingCountry;
            ShippingStreet = shippingStreet;
            ShippingCity = shippingCity;
            ShippingState = shippingState;
            ShippingZipCode = shippingZipCode;
            ShippingCountry = shippingCountry;
            OrderDate = orderDate;
            PaymentMethod = paymentMethod;
            Currency = currency;
            SubTotal = subTotal;
            DiscountAmount = discountAmount;
        }



    }
}
