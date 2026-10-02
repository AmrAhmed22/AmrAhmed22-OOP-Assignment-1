namespace Part3_BuilderPattern
{
    public class Program
    {


        static void Main(string[] args)
        {
            var invoice = new InvoiceBuilder("INV-1001", "Amr Ahmed", DateTime.Now)
               .WithBillingCity("Cairo")
               .WithBillingCountry("Egypt")
               .PaidBy("Card")
               .InCurrency("EGP")
               .WithSubTotal(1000m)
               .Build();


            Console.WriteLine($"{invoice.InvoiceId} | {invoice.CustomerName} | {invoice.TotalAmount} {invoice.Currency}");

        }
    }
}
