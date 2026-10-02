1 -
the 20 constructor parameter problems :
not readable, every time you create an object you must pass a terrible 20 parameters and  because it's so hard to read and maintain, you could swapping values by mistake, it will compiles without error but gives you wrong data, .
also if you want to add another property you must change the constructor that will break existing calls or you will make chain constructor but it will be so large and even worse!

2-
it will have so many responsibilities all of them in one class and thats violates the first SOLID principle (Single responsibility) and it will be low cohesion which is bad design!