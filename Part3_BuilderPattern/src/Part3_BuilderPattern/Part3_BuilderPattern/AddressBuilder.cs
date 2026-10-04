using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3_BuilderPattern
{
    internal class AddressBuilder
    {
        private readonly string _street;
        private readonly string _city;
        private readonly string _zipCode;
        private readonly string _country;
        private string? _state;

        public AddressBuilder(string street, string city, string zipCode, string country)
        {
            
            _street = street;
            _city = city;
            _zipCode = zipCode;
            _country = country;
        }

        public AddressBuilder WithState(string state)
        {
            _state = state;
            return this;
        }

        public Address Build() => new Address(_street, _city, _state, _zipCode, _country);

    }
}
