using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern
{
    public sealed class InvoiceBuilder
    {

        private readonly string _invoiceId;
        private readonly string _customerName;
        private readonly string _customerEmail;
        private readonly Address _billingAddress;
        private readonly Order _order;

        private string? _customerPhone;
        private Address? _shippingAddress;

        public InvoiceBuilder(string invoiceId, string customerName, string customerEmail,
            Address billingAddress, Order order)
        {

            ArgumentNullException.ThrowIfNull(billingAddress);
            ArgumentNullException.ThrowIfNull(order);

            if (order is null)
                throw new NullReferenceException("order is empty!");

            if (billingAddress is null)
                throw new NullReferenceException("billingaddress is empty!");


            _invoiceId = invoiceId;
            _customerName = customerName;
            _customerEmail = customerEmail;
            _billingAddress = billingAddress;
            _order = order;
        }

        public InvoiceBuilder WithPhone(string phone)
        {
            _customerPhone = phone;
            return this;
        }

        public InvoiceBuilder WithShippingAddress(Address shippingAddress)
        {
            _shippingAddress = shippingAddress;
            return this;
        }

        public Invoice Build()
        {
            return new Invoice(_invoiceId, _customerName, _customerEmail,
                _customerPhone, _billingAddress, _shippingAddress, _order);
        }



    }

}