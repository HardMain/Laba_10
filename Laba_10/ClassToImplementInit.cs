using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba_10
{
    internal class ClassToImplementInit : IInit     //класс реализующий интерфейс Init
    {
        public void Init()
        {
            Console.WriteLine("Работа метода Init класса ClassToImplementInit\n");
        }
        public void RandomInit()
        {
            Console.WriteLine("Работа метода RandomInit класса ClassToImplementInit\n");
        }
        public void Show()
        {
            Console.WriteLine("Работа метода Show класса ClassToImplementInit\n");
        }
    }
}
