using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Threading;
using static AssignmentLINQ.ListGenerator;

namespace AssignmentLINQ
{
    class Program
    {
        static void Main(string[] args)
        {

            FileStream f = new FileStream(@"dictionary_english.txt", FileMode.Open, FileAccess.Read);
            StreamReader streamReader = new StreamReader(f);
            var dataInArray = streamReader.ReadToEnd().Split("\n");
            


            #region LINQ - Restriction Operators

            ///1.Find all products that are out of stock.
            ///var res = ProductsList.Where((P) => P.UnitsInStock == 0);
            ///
            ///foreach (var item in res)
            ///    Console.WriteLine(item);


            ///2.Find all products that are in stock and cost more than 3.00 per unit.
            ///var res = ProductsList.Where((P) => P.UnitsInStock != 0 && P.UnitPrice>3.0M);
            ///
            ///foreach (var item in res)
            ///    Console.WriteLine(item);

            ///3.Returns digits whose name is shorter than their value
            ///Question is not clear
            ///String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            ///
            ///var res=Arr.Where(item=>)
            ///

            #endregion

            #region LINQ - Element Operators

            /// 1.Get first Product out of Stock
            ///var res = ProductsList.FirstOrDefault((P) => P.UnitsInStock == 0 );
            ///Console.WriteLine(res);

            /// 2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            ///var res = ProductsList.Where((X) => X.UnitPrice > 1000).FirstOrDefault();
            ///
            ///Console.WriteLine(res != null?$"FIRST PRODUCT:{res.ProductName}":"null");

            /// 3.Retrieve the second number greater than 5
            ///int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            ///int res = ( from val in Arr
            ///            where val > 5 && val
            ///            select Num).ElementAt(2);
            ///                                 
            ///Console.WriteLine(res != -1 ? res: " Not Found ");

            #endregion

            #region LINQ - Ordering Operators

            ///1. Sort a list of products by name
            ///var ResProducts = ProductsList.OrderBy(X => X.ProductName);
            ///foreach (var Item in ResProducts)
            ///    Console.WriteLine(Item);

            ///2. Uses a custom comparer to do a case-insensitive sort of the words in an array
            ///string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            ///var SortArr = Arr.OrderBy(X => X, StringComparer.OrdinalIgnoreCase).ToArray();
            ///Console.WriteLine("SortOfArray:");
            ///foreach (var Item in SortArr)
            ///    Console.WriteLine(Item);

            ///3. Sort a list of products by units in stock from highest to lowest.
            ///var ResProducts = ProductsList.OrderByDescending(X => X.UnitsInStock);
            ///foreach (var Item in ResProducts)
            ///    Console.WriteLine(Item);

            ///4. Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
            ///string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            ///var SortArr = Arr.Where((X) => X.Length < 6).OrderBy(X => X.Length).ThenBy(X => X);
            ///foreach (var Digit in SortArr)          
            ///    Console.WriteLine(Digit);

            ///5. Sort first by-word length and then by a case-insensitive sort of the words in an array.
            ///string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            ///var SortArr = Arr.OrderBy(X => X.Length).ThenBy(X => X, StringComparer.OrdinalIgnoreCase);  
            ///foreach (var item in SortArr)            
            ///    Console.WriteLine(item);

            ///6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            ///var ResProducts = ProductsList.OrderByDescending(P => P.Category).ThenByDescending(P => P.UnitPrice);
            ///foreach (var Item in ResProducts)
            ///    Console.WriteLine(Item);

            ///7. Sort first by-word length and then by a case-insensitive descending sort of the words in an array.
            ///string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            ///var SortArr = Arr.OrderBy(P => P.Length).ThenByDescending(P => P, StringComparer.OrdinalIgnoreCase); 
            ///
            ///foreach (var X in SortOfArray)            
            ///    Console.WriteLine(P);

            ///8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            ///string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            ///var ReversedDigits = Arr.Where(word => word.Length > 1 && word[1] == 'i')
            ///                        .Select(word => new string(word.Reverse().ToArray()));
            ///
            ///foreach (var Digit in ReversedDigits)
            ///    Console.WriteLine(Digit);

            #endregion

            #region LINQ - Aggregate Operators

            ///1.Uses Count to get the number of odd numbers in the array
            ///int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            ///var res = Arr.Count(e => e % 2 == 1);
            ///Console.WriteLine(res);

            ///2.Return a list of customers and how many orders each has.
            ///var res=CustomersList.Select(c => new {c.CustomerName, NumOfOrders=c.Orders.Length });
            ///foreach(var c in res)
            ///    Console.WriteLine(c);

            ///3.Return a list of categories and how many products each has
            ///var res=ProductsList.GroupBy(p=>p.Category).Select(p => new {Category=p.Key, NumOfProducts=p.Count()});
            ///foreach (var item in res)
            ///    Console.WriteLine(item);

            ///4.Get the total of the numbers in an array.
            ///int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            ///var res=Arr.Sum(x => x);
            ///Console.WriteLine(res);

            ///5.Get the total number of characters of all words in dictionary_english.txt
            ///var res = dataInArray.Sum(e=>e.Length);
            ///Console.WriteLine(res);

            ///6.Get the length of the shortest word in dictionary_english.txt
            ///var res = dataInArray.Min(e => e.Length);
            ///Console.WriteLine(res);

            ///7.Get the length of the longest word in dictionary_english.txt
            ///var res = dataInArray.Max(e => e.Length);
            ///Console.WriteLine(res);

            ///8.Get the average length of the words in dictionary_english.txt
            ///var res = dataInArray.Average(e => e.Length);
            ///Console.WriteLine(res);

            ///9.Get the total units in stock for each product category.
            ///var res = ProductsList.GroupBy(p => p.Category).Select(p => new { Category = p.Key, NumofUnits = p.Sum(e=>e.UnitsInStock) });
            ///foreach (var item in res) 
            ///    Console.WriteLine(item);

            ///10.Get the cheapest price among each category's products
            ///var res = ProductsList.GroupBy(p => p.Category).Select(p => new { Category = p.Key, CheapestProduct = p.Min(e=>e.UnitPrice) });
            ///foreach (var item in res) 
            ///    Console.WriteLine(item);

            ///11.Get the products with the cheapest price in each category(Use Let)
            ///var res = from p in ProductsList
            ///          let cheap = ProductsList.Min(e => e.UnitPrice)
            ///          group p by p.Category into val
            ///          select new { Category=val.Key, cheap = val.Min(e => e.UnitPrice) };
            ///
            ///foreach (var item in res) 
            ///    Console.WriteLine(item);

            ///12.Get the most expensive price among all category's products.
            ///var res = ProductsList.Max(e => e.UnitPrice);
            ///Console.WriteLine(res);

            ///13.Get the products with the most expensive price in each category.
            ///var res = ProductsList.GroupBy(p => p.Category).Select(p => new { Category = p.Key, MostExpensiveProduct = p.Max(e=>e.UnitPrice) });
            ///foreach (var item in res) 
            ///    Console.WriteLine(item);

            ///14.Get the average price of each category's products.
            ///var res = ProductsList.GroupBy(p => p.Category).Select(p => new { Category = p.Key, AveragePrices = p.Average(e=>e.UnitPrice) });
            ///foreach (var item in res) 
            ///    Console.WriteLine(item);

            #endregion

            #region LINQ - Set Operators

            ///1.Find the unique Category names from Product List
            ///var res = ProductsList.Select(p=>p.Category).Distinct();
            ///foreach (var item in res)
            ///    Console.WriteLine(item);

            ///2.Produce a Sequence containing the unique first letter from both product and customer names.


            ///3.Create one sequence that contains the common first letter from both product and customer names.

            ///4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.

            ///5.Create one sequence that contains the last Three Characters in each name of all customers and products, including any duplicates


            #endregion


        }
    }
}