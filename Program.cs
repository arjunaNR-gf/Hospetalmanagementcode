using System;

namespace Hospetal
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("__________________________________________________________________________________________________________________________________________________________________________________________________________________");

                Console.Write("Welcome to HostitalManagement\t\t\t\t\t\t\t\t\t\t\t");
                Console.Write("1 for USER\t");
                Console.Write("2 for DEPARTMENT\t");
                Console.Write("3 for DOCTOR\t");
                Console.Write("4 for LAB\t");
                Console.WriteLine();
                Console.WriteLine("__________________________________________________________________________________________________________________________________________________________________________________________________________________");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Enter your choice");
                Console.WriteLine("__________________");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("__________________");

                switch (choice)
                {
                    case 1:
                        Loginpage lgnp = new Loginpage();

                        lgnp.mylogin("Patient");
                        break;

                    case 2:
                        Loginpage lgnd = new Loginpage();
                        lgnd.mylogin("Deparment");
                        break;



                    case 3:
                        Loginpage lgndctr = new Loginpage();
                        lgndctr.mylogin("Doctor");
                        break;



                    case 4:
                        Loginpage lab = new Loginpage();
                        lab.mylogin("Lab");
                        break;

                }
            }
        }
    }
}
