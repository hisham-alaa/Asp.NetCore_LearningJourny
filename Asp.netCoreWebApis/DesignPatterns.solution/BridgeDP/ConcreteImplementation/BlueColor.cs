using BridgeDP.Implementor;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDP.ConcreteImplementation
{
    public class BlueColor : IColor
    {
        public void Colorize()
        {
            Console.WriteLine("My color is Blue");
        }
    }
}
