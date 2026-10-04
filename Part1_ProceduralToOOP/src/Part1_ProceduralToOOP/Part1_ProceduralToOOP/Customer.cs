using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part1_ProceduralToOOP
{
    public class Customer
    {
        private readonly List<Order> _orders = new List<Order>();

        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string City { get; }
        public bool IsVip { get; }

        public decimal DiscountRate => IsVip ? 0.10m : 0m;

        public Customer(int id, string name, string email, string city, bool isVip)
        {
            Id = id;
            Name = name;
            Email = email;
            City = city;
            IsVip = isVip;
        }

        public Order PlaceOrder(int orderId, DateOnly date)
        {
            var order = new Order(orderId, Id, DiscountRate, date);
            _orders.Add(order);
            return order;
        }

        public List<Order> GetOrders()
        {
            return new List<Order>(_orders);
        }

        public override string ToString() => $"#{Id}  {Name}  <{Email}>  {City}  vip={(IsVip ? "yes" : "no")}";

    }
}
