3.1:

1 -
the 20 constructor parameter problems :
not readable, every time you create an object you must pass a terrible 20 parameters and  because it's so hard to read and maintain, you could swapping values by mistake, it will compiles without error but gives you wrong data, .
also if you want to add another property you must change the constructor that will break existing calls or you will make chain constructor but it will be so large and even worse!

2-
it will have so many responsibilities all of them in one class and thats violates the first SOLID principle (Single responsibility) and it will be low cohesion which is bad design!

3.3:
 Single responsibility - what does each small builder own, and only own?

AddressBuilder knows only address rules, OrderBuilder knows only payment and order rules, and InvoiceBuilder only joins the pieces.
each builder has only single responsibility


 Independent validation - can AddressBuilder guarantee a complete address on its own, without the
parent object knowing anything about street/city/zip rules?

Address cannot exist without street, city, zip and country, so InvoiceBuilder has no any knowledge about address rules at all
same with order details.


 Reuse - the exact same AddressBuilder is used for both billing and shipping. What would you have had
to duplicate without it?

it would duplicate the billing funcs and shipping funcs , while the both are address!


 Readability at the call site - compare constructing the object with Task 3.2's single builder versus this
composed version.




In 3.2, one builder holds everything, so the call site is one long chain of about 12 calls. Billing and shipping fields look the same (WithBillingCity, WithShippingCity), so it is easy to lose track or mix them up.

for example:
new InvoiceBuilder("INV-1001", "Ali", new DateTime(2026, 10, 2))
    .WithEmail("ali@example.com")
    .WithBillingStreet("12 Nile St").WithBillingCity("Cairo")
    .WithBillingZip("11511").WithBillingCountry("Egypt")
    .PaidBy("Card").InCurrency("EGP")
    .WithSubTotal(1000m)
    .Build();

But in 3.3, the code is split into small named class: address, order, invoice. Each class is built on its own and can be read on its own.
The final invoice call only says which address is billing, which is shipping, and which is the order.

ex:
var billing = new AddressBuilder("12 Nile St", "Cairo", "11511", "Egypt").Build();
var order   = new OrderBuilder(new DateTime(2026, 10, 2), "Card", "EGP", 1000m).Build();

var invoice = new InvoiceBuilder("INV-1001", "Ali", "ali@example.com", billing, order).Build();


SO: 3.3 is easier to read because each part is small and named, and the invoice line shows the structure clearly instead of 12 setter calls.