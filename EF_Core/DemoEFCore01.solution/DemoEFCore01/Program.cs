namespace DemoEFCore01
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
            ///


            #endregion



        }
    }
}