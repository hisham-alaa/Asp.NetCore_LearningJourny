using BridgeDP.Abstraction;
using BridgeDP.ConcreteImplementation;
using BridgeDP.RefinedAbstraction;

namespace BridgeDP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Shape RedSquare = new Square();
            Shape BlueCircle = new Circle();


            RedSquare.Draw();
            RedSquare.ShapeColor = new RedColor();
            RedSquare.ShapeColor.Colorize();

            Console.WriteLine("******************************");

            BlueCircle.Draw();
            BlueCircle.ShapeColor = new BlueColor();
            BlueCircle.ShapeColor.Colorize();




        }
    }
}