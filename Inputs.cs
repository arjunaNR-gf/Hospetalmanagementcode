using System;
using System.Collections.Generic;
using System.Text;

namespace Hospetal
{
    class Inputs
    {
        static Inputs()
        {

        }
        public void Inputmain()
        {
            int a = 0;
            int.TryParse(Console.ReadLine(), out a);
            Console.WriteLine(a);

            double d = 0;
            double.TryParse(Console.ReadLine(), out d);
            Console.WriteLine(d);

        }
    }
}
