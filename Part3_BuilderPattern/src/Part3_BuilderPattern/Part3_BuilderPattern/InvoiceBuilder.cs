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
        private readonly DateTime _orderDate;

        private string? _customerEmail;
        private string? _customerPhone;
        private string? _billStreet, _billCity, _billState, _billZip, _billCountry;
        private string? _shipStreet, _shipCity, _shipState, _shipZip, _shipCountry;
        private string? _paymentMethod;
        private string _currency;
        private decimal? _subTotal;
        private decimal? _discount;



        public InvoiceBuilder(string invoiceId, string customerName, DateTime orderDate)
        {
            if (string.IsNullOrEmpty(invoiceId))
                throw new ArgumentException("Invoice ID is mandatory", nameof(invoiceId));
            if (string.IsNullOrEmpty(customerName))
                throw new ArgumentException("Customer Name is mandatory", nameof(customerName));

            _invoiceId = invoiceId;
            _customerName = customerName;
            _orderDate = orderDate;

        }

        public InvoiceBuilder WithBillingStreet(string billStreet)
        {
            _billStreet = billStreet;
            return this;
        }

        public InvoiceBuilder WithBillingCity(string billCity)
        {
            _billCity = billCity;
            return this;
        }

        public InvoiceBuilder WithBillingState(string billState)
        {
            _billState = billState;
            return this;
        }

        public InvoiceBuilder WithBillingZip(string billZip)
        {
            _billZip = billZip;
            return this;
        }

        public InvoiceBuilder WithBillingCountry(string billCountry)
        {
            _billCountry = billCountry;
            return this;
        }

        public InvoiceBuilder WithShippingStreet(string shipStreet)
        {
            _shipStreet = shipStreet;
            return this;
        }

        public InvoiceBuilder WithShippingCity(string shipCity)
        {
            _shipCity = shipCity;
            return this;
        }

        public InvoiceBuilder WithShippingState(string shipState)
        {
            _shipState = shipState;
            return this;
        }

        public InvoiceBuilder WithShippingZip(string shipZip)
        {
            _shipZip = shipZip;
            return this;
        }

        public InvoiceBuilder WithShippingCountry(string shipCountry)
        {
            _shipCountry = shipCountry;
            return this;
        }


        public InvoiceBuilder WithDiscount(decimal discount)
        {
            _discount = discount;
            return this;
        }

        public InvoiceBuilder PaidBy(string paymentMethod)
        {
            _paymentMethod = paymentMethod;
            return this;
        }

        public InvoiceBuilder InCurrency(string currency)
        {
            _currency = currency;
            return this;
        }

        public InvoiceBuilder WithSubTotal(decimal subTotal)
        {
            _subTotal = subTotal;
            return this;
        }


    


        public Invoice Build()
        {
            return new Invoice(
                     _invoiceId,
                     _customerName,
                     _customerEmail ,
                     _customerPhone,
                     _billStreet ,
                     _billCity ,
                     _billState,
                     _billZip ,
                     _billCountry,
                     _shipStreet,
                     _shipCity,
                     _shipState,
                     _shipZip,
                     _shipCountry,
                     _orderDate, 
                     _paymentMethod ,
                     _currency ,
                     _subTotal ?? 0m,
                     _discount ?? 0m
                     );
        }
    }



}

