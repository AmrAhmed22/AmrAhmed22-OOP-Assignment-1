namespace Part3_BuilderPattern
{
    public class Program
    {


        static void Main(string[] args)
        {
            var billing = new AddressBuilder("12 Nile St", "Cairo", "22222", "Egypt")
                .Build();

            var shipping = new AddressBuilder("5 Pyramids Rd", "Giza", "11111", "Egypt")
                .WithState("Giza state")
                .Build();

            var order = new OrderBuilder(new DateTime(2026, 10, 2), "Cash", "EGP", 1000m)
                .WithDiscount(100m)
                .Build();

            var invoice = new InvoiceBuilder("INV-1001", "Ahmed Anwer", "Ahmed@Simulation.com", billing, order)
                .WithPhone("01000000000")
                .WithShippingAddress(shipping)
                .Build();

            Console.WriteLine($"{invoice.InvoiceId} | {invoice.CustomerName}");
            Console.WriteLine($"Billing: {invoice.BillingAddress.City} | Shipping: {invoice.ShippingAddress?.City}");
            Console.WriteLine($"Tax: {invoice.order.TaxAmount} | Total: {invoice.order.TotalAmount} {invoice.order.Currency}");

        }
    }
}
