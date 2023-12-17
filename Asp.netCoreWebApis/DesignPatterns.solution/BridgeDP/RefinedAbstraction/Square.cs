using BridgeDP.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDP.RefinedAbstraction
{
    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("I'm a square");
        }
    }
}
