using DemoEF_Core03.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DemoEF_Core03
{
    class Program
    {
        static void Main()
        {
            using AppDbContext db = new AppDbContext();

            #region Loading The Navigational Property (Related Data)

            ///By Default Related data Like department in Employee model Doesn't loaded so,
            ///we need to load it in  way of three ways:
            ///     1- Explicit Loading 
            ///     2- Implicit Loading.
            ///     3- Eager Loading.

            #region Explicit Loading

            ///var res= (from e in db.Employees
            ///          where e.Id == 3
            ///          select e).FirstOrDefault();
            ///
            ///So by saying Load for this related data it will be generated
            ///we can sa then Include If there is more than one related data
            ///
            ///db.Entry(res).Reference(d => d.Department).Load();
            ///
            ///But we do it in two steps(requests) like following so its not good 
            ///It is good in just one thing that you call it once you need it only  
            ///
            ///
            ///Console.WriteLine(res);
            ///Console.WriteLine( res?.Department);

            #endregion

            #region Eager Loading

            ///var res = (from e in db.Employees.Include(e=>e.Department)/*.Include(e=>e.Department).ThenInclude(d=>d.Id).Include(e=>e.Department)*/
            ///           where e.Id == 3
            ///           select e).FirstOrDefault();
            ///
            ///it will always get the related data we defined in the include fucntion 
            ///Include Fucntion can be existed more than once for each related data
            ///we can also select a related data to this related by calling ThenInlcude method
            ///
            ///We Will Use it if the user will always need this related data
            ///
            ///But I will not always need this related date so this is its disadvantage
            ///
            ///Console.WriteLine(res);
            ///Console.WriteLine( res?.Department);

            #endregion

            #region Lazy-Implicit Loading

            ///Basically its like Exiplicit loading but it will load related data automatically 
            ///once you called this related data, But you need to so some Configurations to do this implicitly
            ///     1. Install Microsoft.EntityFrameworkCore.Proxies
            ///     2. in OnConfiguring overrided method in the AppDbContext class type this:
            ///         optionsBuilder.UseLazyLoadingProxies().UseSqlServer("ConnStr");
            ///     3. Change the AccessModifier of model Classes to be Public.
            ///     4. this related data Must be Virtual to have the ability to override 
            ///         the get method to fit the currunt data.
            ///
            ///var res = (from e in db.Employees.Include(e=>e.Department)
            ///           where e.Id == 3
            ///           select e).FirstOrDefault();
            ///
            ///Console.WriteLine(res);
            ///Console.WriteLine( res?.Department);//will be loaded once you call it 

            #endregion

            #endregion


            #region Join Operators (Join, LeftJoin, GroupJoin)

            ///whats written first here will be also the first in the equailty of join 
            ///var Result = from E in db.Employees join D in db.Departments 
            ///             on E.DepartmentId equals D.Id
            ///             select new 
            ///             {
            ///                 DeptId = D.Id,
            ///                 DeptName= D.Name,
            ///                 EmpId = E.Id,
            ///                 EmpName = E.Name,
            ///             };
            ///
            //////OR In Fluent Syntax
            ///Result = db.Employees.Join(  db.Departments
            ///                           , E => E.DepartmentId
            ///                           , d => d.Id
            ///                           , (E, D) => new
            ///                           {
            ///                               DeptId = D.Id,
            ///                               DeptName = D.Name,
            ///                               EmpId = E.Id,
            ///                               EmpName = E.Name,
            ///                           }/*another parameter you will use if the primary key is composed key*/);


            var Result = db.Departments.GroupJoin(db.Employees
                                       , d => d.Id
                                       , E => E.DepartmentId
                                       , (D, Emps) => new
                                       {
                                           D,
                                           Emps
                                       });



            foreach (var result in Result)
                Console.WriteLine(result);

            #endregion


        }
    }
}