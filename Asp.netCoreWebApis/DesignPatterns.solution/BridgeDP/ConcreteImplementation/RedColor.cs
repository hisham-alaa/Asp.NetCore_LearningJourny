using BridgeDP.Implementor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDP.ConcreteImplementation
{
    public class RedColor : IColor
    {
        public void Colorize()
        {
            Console.WriteLine("My color is Red");
        }
    }
}
