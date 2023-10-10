using DemoEFCore01.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlTypes;
using DemoEFCore01.Entities;
using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore01
{

    class Program
    {
        static void Main(string[] args)
        {
            #region ADO.NET

            ///var configuration = new ConfigurationBuilder()
            ///    .AddJsonFile("appsettings.json")
            ///    .Build();
            ///
            ///Console.WriteLine(configuration.GetSection("connstr").Value);

            ///var conn = new SqlConnection(configuration.GetSection("connstr").Value);
            ///
            ///var sql = "Select * from WALLETS";
            ///
            ///SqlCommand cmd = new SqlCommand(sql, conn);
            ///
            ///cmd.CommandType = CommandType.Text;
            ///
            ///conn.Open();
            ///
            ///SqlDataReader reader = cmd.ExecuteReader();
            ///
            ///Wallet wallet ;
            ///
            ///while (reader.Read()) 
            ///{
            ///    wallet = new Wallet()
            ///    {
            ///        Id = reader.GetInt32("Id"),
            ///        Holder = reader.GetString("Holder"),
            ///        Balance = reader.GetDecimal("Balance")
            ///    };
            ///    Console.WriteLine(wallet);
            ///}
            ///conn.Close();

            #endregion

            #region Intro To EF_Core

            ///EF_Core is an ORM (Object Relational Mapper)
            ///1. Mapping (has 2 Approaches)
            ///     1.1 From code to DB(Table, Views, Functions) [Code First Approach]
            ///     1.1 From DB Generate Classes [DB First Approach]
            ///     the Code First Approach is the most common used and the recommended one
            ///2. Linq To Entity 
            ///(without take the DB in consideration since we can just type linq once and using the 
            /// proper pachage we can make it fit any sql).

            ///Generation will follow which schema?
            ///1. TPC (Table Per Class) the Default.
            ///     [each class will have its corresponding table in the database 
            ///      which is not the best way when exist an inheritance relation].
            ///2. TPH (Table Per Hierarchy).
            ///     [takes the whole hierarchy and map it to just one table with a non existed column
            ///      before(Discraminator) which is the one that define this row belongs to which type in the heararchy
            ///      ,which lead us to have alot of null values in the created table].
            ///3. TPCC (Table Per Concrete Class).
            ///     [Will Generate tables based on whether its a concrete class or not and generate table for the 
            ///      concrete classes].

            ///Dapper VS EF_Core VS ADO.Net
            ///- Dapper, ADo.Net Writes the queries in Sql Server while EF_Core uses linq to generate Queries for different
            ///  SQL Syntax(SqlServer, MySql, Oracle Sql...etc).
            ///- the real comparison for make it simple is between Dapper and EF_Core For more details visit https://www.c-sharpcorner.com/article/dapper-vs-entity-framework-core-vs-ado-net-which-one-should-you-choose/#:~:text=If%20you%20need%20a%20lightweight,NET%20is%20a%20good%20choice.
            ///- both Dapper and EF_Core are a layer above the ADO.Net but Dapper is the fastest since it needs 
            ///  not to much code while ADO.Net you will suffer to write what you want.
            ///- EF_Core is better since it keeps your queries general not related to just one database sql 
            ///- 

            #endregion


            ///another way to acces the EmployeeObject without creating a DbSet<Employee> in "name"Dbcontext
            ///db.Set<Employee>().Where(e => e.Age > 50);

            using CompanyMappedDbContext db = new CompanyMappedDbContext();

            #region CRUD

            ///Create
            ///Employee emp1 = new Employee()
            ///{ Name = "hisham", Age = 23, EmailAddress = "HishamAlaa923@gmail.com", Password = "12345", Phone = "01021125956", Salary = 9000 };
            ///Employee emp2 = new Employee()
            ///{ Name = "hisham", Age = 23, EmailAddress = "HishamAlaa923@gmail.com", Password = "12345", Phone = "01021125956", Salary = 9000 };
            ///
            ///Console.WriteLine(db.Entry(emp1).State);
            ///db.Add(emp1);
            ///
            ///ways to add the object to watch its state
            ///db.employees.Add(emp2);
            ///db.Set<Employee>().Add(emp1);
            ///
            ///db.SaveChanges();
            ///Console.WriteLine(db.Entry(emp1).State);
            ///
            ///Console.WriteLine(emp1.EmpId);
            ///Console.WriteLine(emp2.EmpId); 

            ///Read
            ///db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;//No tracking will happens just read
            ///var res=(from e in db.employees
            ///        where e.EmpId==1
            ///        select e).AsNoTracking().FirstOrDefault();
            ///
            ///Console.WriteLine(res?.Name ?? "No Employee");

            ///Update
            ///var emp=(from e in db.employees
            ///         select e).FirstOrDefault();
            ///Console.WriteLine(db.Entry(emp).State);
            ///Console.WriteLine(emp.Salary);
            ///
            ///emp.Salary = 100000;
            ///Console.WriteLine(db.Entry(emp).State);
            ///db.SaveChanges();
            ///Console.WriteLine(emp.Salary);

            ///Delete
            ///var emp = (from e in db.employees
            ///         select e).FirstOrDefault();
            ///
            ///Console.WriteLine(db.Entry(emp).State);
            ///
            ///db.employees.Remove(emp);
            ///Console.WriteLine(db.Entry(emp).State);
            ///db.SaveChanges();

            #endregion

        }
    }
}