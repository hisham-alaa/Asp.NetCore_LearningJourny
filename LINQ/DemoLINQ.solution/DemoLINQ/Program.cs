using System.Reflection.Metadata.Ecma335;
using static DemoLINQ.ListGenerator;

namespace DemoLINQ
{
    class Program
    {

        static void Main(string[] args)
        {

            #region Implicitily Typed Local Variable Var and Dynamic

            ///.this means to detect the datatype implicitly from the initial value 
            ///.must be initialized in the declaration 
            ///.Compiler Will detect the datatype Implicitily in the Compilation Time 
            ///.NOTE: it differ from var in JS it just typing for you the datatype instead you are 
            ///.can't be used as a parameter of a function.
            ///
            ///.used usually once i realised that i don't know the datatype or I know But I don't have a datatype to represent it 
            ///
            ///var var1 = null;
            ///.can't be initialized with null since it has no datatype 
            ///
            ///var var1 = "ali";
            ///
            ///var1 = 10;
            ///not valid since it has detected as string in initialization(C# is strongly typed language)
            ///dynamic var2 =null;
            ///
            ///
            ///while dynamic is the same as var in JS
            ///CLR will detect its datatype Based on its last assigned value in the run time 

            #endregion

            #region Extension methods  

            ///- Basically it extend the class with method that I Have defined without add it actually to the class body
            ///  because of any reason may be you don't have the access to this class and you just have the dll 
            ///  file or anyother reason. 
            ///- you can call the method through the obj or variable of this class it extend 
            ///int X = 1236;
            ///Console.WriteLine(X.ReverseInt());
            ///Console.WriteLine(ReverseInt(X));
            ///we can call it as an static method or as a method in this datatype we try to extend it with this method.

            #endregion

            #region Anonymous Type

            ///- To creat an object from not existed datatype 
            ///- it will be created in the compilation time through the compiler since it has to generate to us a new 
            ///  class that doesn't exist, so we need its dll to be compiled to later in the runtime. 
            ///- we can define it through the var keyword.
            ///var var1 = new { id = 10, name = "hisham", salary = 9_000 };//AnonymousType0`3
            ///- we use the var keyword since it is the one that works in the comiplation time so before build we will
            ///  know if there is an error or not while with the dynamic keyword we won't know except in the runtime 
            ///  with a thrown exception in your face.
            ///- the object created from Anonymous type is immutable like string.
            ///var1.id=15; //invalid 
            ///
            ///var1 = new { id = 15, var1.name, var1.salary };//C# 9.0 and before
            ///var1 = var1 with { id = 15 };//C# 10.0 Feature 
            ///
            ///- two Anonymous type are the same if
            ///     1.Properties has the same name[Case Sensitive].
            ///     2.the same properties order

            #endregion

            #region Intro To LINQ

            ///- LINQ Stands for Language Integrated Query
            ///- Its a layer between me as a C# program and the database what ever its sql type(oracle, sqlserver, MySql...etc)           
            ///- 40+ C# function Against data(Stored in Sequence) regardless of Data store
            ///  (SQL Server , MySql, Static, XML)
            ///- Extension Functions for any Class implementing the IEnumerable Interface (any object of them is called Sequence).
            ///- Sequence:
            ///     Local sequence  => Static (written by me as a developer) or XML File. LINQ to OBJ, LINQ to XML 
            ///     Remote sequence => a database (need a connection to be establish). LINQ to EF 
            ///
            ///List<int> list = new List<int>() { 0, 1, 2, 7, 3, 4, 5};
            ///list.Where(e => e > 5);
            ///
            ///foreach (var item in list)
            ///    Console.WriteLine(item);
            ///
            ///- All Collections implements IEnumerable
            ///- Named as LINQ Operators Existed at class Enumerable
            ///- categorized into 13 category 
            ///     10 Differed  Functions  (Look at Linq Execution ways)
            ///     3  Immediate Functions 

            #endregion

            #region LINQ Syntax

            ///var Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 9, 8, 7 };

            /// Either written 

            ///     1. Fluent Syntax : use LINQ Operators through: (Recommended)
            ///         1.1 the Enumerable Class as static methods 
            ///var odds = Enumerable.Where(Numbers, N => N % 2 == 1);
            ///         1.2 an object from class implements IEnumerable interface(Sequence)
            ///odds = Numbers.Where(N => N % 2 == 1);//Recommended

            ///     2. SQl Experssion(written in the same way as its execution not exactly like sql)
            ///var odds = from N in Numbers
            ///           where N % 2 == 1
            ///           select N;
            ///foreach(var odd in odds)
            ///    Console.WriteLine(odd);

            #endregion

            #region LINQ Execution Ways

            ///List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 9, 8, 7 };
            ///
            ///var odds = Numbers.Where(N => N % 2 == 1);
            ///
            ///Numbers.AddRange(new int[] { 10, 11, 12, 13, 14, 15 });
            ///
            ///foreach (var odd in odds)
            ///    Console.WriteLine(odd);
            ///
            ///there is two type of executions here
            ///1. immediate execution (to execute the operator once it called and that happens with three categories of the 13)
            ///     [Element, Casting and Aggregation operators]
            ///2. differed execution (Thats happens with the other 10 categories).
            ///
            ///there is a trick to execute operators from differed execution types immediatly (to use an operator from immediate execution type with it)
            ///
            ///var odds = Numbers.Where(N => N % 2 == 1).ToList();//here we used to list from element operators and it will executed immediate not like previous
            ///
            ///Numbers.AddRange(new int[] { 10, 11, 12, 13, 14, 15 });
            ///
            ///foreach (var odd in odds)
            ///    Console.WriteLine(odd);

            #endregion

            #region Restriction-[Filteration] Operators (Where)

            ///Normal where operator with just a predicate as param
            ///var products = ProductsList.Where(p => p.UnitsInStock == 0);
            ///OR
            ///products = from p in ProductsList
            ///      where p.UnitsInStock == 0
            ///      select p;

            ///Indexed where operator with 2 params first is the predicate as previous and second index(valid only in Fluent syntax)
            ///products = ProductsList.Where((p,i) => p.UnitsInStock != 0 && i<10);//the products that meet the condition from first 10 elements
            ///
            ///foreach (var product in products)
            ///    Console.WriteLine(product);

            #endregion

            #region Transformation-[Projection] Operators (Select, SelectMany)

            ///Select Just need a predicate as an argument(in case we will retreive direct data from the sequence).
            ///var products = ProductsList.Select(p => new { Name= p.ProductName , NumOfUnits=p.UnitsInStock}/*Anonymous Type*/);
            ///OR
            ///products= from p in ProductsList
            ///          select new { Name = p.ProductName, NumOfUnits = p.UnitsInStock };

            ///SelectMany also predicate (in case we will retreive a collection from each sequence and we want to to combine them together)
            ///var Result = CustomersList.SelectMany(c => c.Orders);
            ///OR
            ///Result = from c in CustomersList
            ///         from o in c.Orders
            ///         select o;

            ///Indexed Select (predicate and int as index) also valid only with fluent syntax 
            ///var Result = ProductsList.Select((p, i) => new { index = i, Name = p.ProductName });
            ///
            ///foreach (var res in Result)
            ///    Console.WriteLine(res);

            #endregion

            #region Ordering Operators (OrderBy, OrderByDescending, ThenBy, ThenByDescending, Reverse)

            ///OrderBy and OrderByDescending with func as argument and ThenBy and ThenByDescending for ordering based on multi value
            ///var products = ProductsList.OrderBy/*Descending*/(p => p.UnitsInStock).ThenBy(p=>p.UnitsInStock);
            ///OR
            ///products= from p in ProductsList
            ///          orderby p.UnitsInStock/*, p.UnitsInStock*/ /*descending*/
            ///          select p;
            ///

            ///Reverse (Reverses the output) take nothing
            ///var products = ProductsList.Where(p => p.UnitsInStock == 0).Reverse();
            ///
            ///foreach (var product in products)
            ///    Console.WriteLine(product);

            #endregion

            #region Element Operators[Immediate Execution] (First, Last, FirstOrDefault, LastOrDefault, Single, SingleOrDefault)

            ///First returns First element (NO Argument) Throw Exception if it is empty
            ///var Result = ProductsList.First();
            ///It has an overload Which has Predicate as argument on something to sort upon
            ///Result = ProductsList.First(p => p.UnitsInStock > 0);

            ///Last returns Last Element (No Argument) Throw Exception if it is empty
            ///Result = ProductsList.Last();
            ///It has an overload Which has Predicate as argument on something to sort upon
            ///Result = ProductsList.Last(p => p.UnitsInStock > 0);

            ///Don't forget to use the null propagation operation here and with Last only in 
            ///case its null we have to avoid it with some value 
            ///Console.WriteLine(Result?.ProductName ?? "No Elements in the Sequence");

            ///FirstOrDefault Like first but if no element it doesn't throw Exception it returns the default 
            ///Result = ProductsList.FirstOrDefault();
            ///It has an overload the value that we want it to return to us if it is empty
            ///Result = ProductsList.FirstOrDefault(new Product() { ProductName="Hisham"});
            ///Another overload the same as First But it doesn't throw exception
            ///Result = ProductsList.FirstOrDefault(p => p.UnitsInStock > 0);
            ///Another overload the predicate and the value to return if empty
            ///Result = ProductsList.FirstOrDefault(p => p.UnitsInStock > 0, new Product() { ProductName = "Hisham" });

            ///LastOrDefault Exactly like FirstOrDefault Except it returns the last one with the same overloads
            ///Result = ProductsList.LastOrDefault();
            ///Result = ProductsList.LastOrDefault(new Product() { ProductName = "Hisham" });
            ///Result = ProductsList.LastOrDefault(p => p.UnitsInStock > 0);
            ///Result = ProductsList.LastOrDefault(p => p.UnitsInStock > 0, new Product() { ProductName = "Hisham" });

            ///Single returns the only existed element in the sequence (must has only single element or it will throw exception)
            ///var Result = ProductsList.Single();//here it will throw Exception
            ///Overload With predicate as argument will return the only element match that condition 
            ///if there is no element match it or more than one it throws exception
            ///Result = ProductsList.Single(p => p.ProductID == 3);

            ///SingleOrDefault The same idea of overloads above Except : 
            ///if the error was that the sequence has more than one element it still will throw Exception
            ///Result = ProductsList.SingleOrDefault();
            ///Result = ProductsList.SingleOrDefault(new Product() { ProductName = "Hisham" });
            ///Result = ProductsList.SingleOrDefault(p => p.ProductID == 3);
            ///Result = ProductsList.SingleOrDefault(p => p.ProductID == 3, new Product() { ProductName = "Hisham" });

            ///All of them are used only with Fluent syntax or we can use hybrid syntax

            #endregion

            #region Aggregation Operators-[Immediate Execution] (Count, Min, Max, Sum, Average, Aggregate)

            ///Count returns the number of Elements in the sequence(With or without condition)
            ///var Result =ProductsList.Count();//the same as using the property it sends to me the property Count value
            ///has overload which takes predicate as argument and returns the num of elements match that condition
            ///Result = ProductsList.Count(p => p.UnitsInStock == 0);//now it has meaning of such method
            ///Console.WriteLine(Result);

            ///Max returns the max element and it uses the CompareTo Method so this element type must implement IComparable
            ///OR We can create a class that implements Icomparer and use the MaxBy operator (C# 10.0 Feature) 
            ///var Result = ProductsList.Max();
            ///OR
            ///Result=ProductsList.MaxBy(p=>p.UnitsInStock);//returns the max based on a predicate as argument
            ///OR
            ///Result= ProductsList.Max(new MyComparer());
            ///Console.WriteLine(Result);

            ///Min same as the max returns the min value and must have an implementation for the icomparable interface
            ///also we have MinBy operator 

            ///Average returns the average value
            ///var Result = ProductsList.Average(p => p.UnitPrice);
            ///Console.WriteLine(Result);

            ///Aggregate returns the composition of all items together.
            ///string[] Names = { "Ali", "Mohamed", "Mahmoud", "Nasser" };
            ///var res = Names.Aggregate((p1, p2) => $"{p1} {p2}");
            ///Console.WriteLine(res);

            #endregion

            #region Casting Operators-[Immediate Execution] (ToList, ToHashSet, ToArray, ...etc)

            ///List<Product> products = ProductsList.Where(p=>p.UnitsInStock>7).ToList();
            ///
            ///Dictionary<long,/*string*/Product> dictionary = ProductsList.Where(p => p.UnitsInStock > 7).ToDictionary(p => p.ProductID/*,p=>p.ProductName*/);

            #endregion

            #region Generation Operators (Range, Repeat, Empty<IEnumerable>)

            ///var Result1 = Enumerable.Range(0, 100);//0...99
            ///
            ///var Result2 = Enumerable.Repeat(2, 5);//2 2 2 2 2
            ///
            ///var Result3=Enumerable.Empty<Product>();
            ///
            ///foreach (var item in Result2)
            ///    Console.WriteLine(item);

            #endregion

            #region Set Operators (Union, Intersect, Except,  )



            #endregion



            string res = "what if we have ";
            res.Replace("if", "hello");
            Console.WriteLine(res.Replace("if", "hello"));

            #region Join Operators (Join, GroupJoin )

            #endregion

        }

    }

    static class Extensions
    {
        ///once we type the keyword this it became an extension method to this datatype whatever it is
        ///if we want to define it as an extension method for more than one datatype these datatypes 
        ///must inherit or implement a common class or interface.
        ///
        public static int ReverseInt(this int value)
        {
            int result = 0;
            while (value != 0)
            {
                result *= 10;
                result += value % 10;
                value /= 10;
            }

            return result;
        }
    }

}