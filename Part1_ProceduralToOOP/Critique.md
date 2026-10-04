1 - Fixed Const sized arrays,Can't take more.
which is very bad design and not realistic at all, you can't take 51 customer for example. 

2- Global 'critical' Variables that can be accessed by any function anywhere without guard rules or validations.(No Encapsulation)

3- No Hashset, every search will be O(N) time complexity.

4- No Objects, NO relations between them in the sys.
exist instead: array indexes (orderCustomerIndexes, lineProductIndexes), which break if the order of data changes. very bad design.

5- Missin so many input validation, and No Exception handling at all.

6- Only one global variable (Customer count) that validates and index every customer input.
(no concurrency) we can't take input more than one at same time.

7- No anytpe of database (no files even),so data is not structured or secured and all data is lost when the program exits.

8- Some functions return value that never used as (CreateOrder) 

9- fixed and hard coded discount for vip customers as magic number (0.9) and no discount for others at all.

10- Validation at any function takes so long O(N) every time,bad performance.

11- Bad Validation, Makeorderpaid can make the order paid twice, it never checks it.

12- No Date Validation, it takes Date as String!! you can write youe name in it normally.

13- No add product option in the menu, and No validation in it! you can pass negative price and stock and it will work normally.

14- decimal is better than double at financial transactions, double has binary rounding errors.

15- Menu must be work internally with (switch case) , not (if else) for better readability and performance.
