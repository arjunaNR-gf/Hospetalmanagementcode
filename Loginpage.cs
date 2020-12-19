using System;
using System.Collections.Generic;
using System.Text;

namespace Hospetal
{
    class Loginpage
    {

        String userName = "arjuna";
        int password = 1234;
        String uname;
        int upassword;
        public void mylogin(String type)
        {
            if(type == "Patient")
            {
               
                Console.WriteLine("\n");
                Console.WriteLine("\n");

                
                Console.WriteLine("\tUser Login\t\t\t\t");
                Console.WriteLine("___________________________\n");

                try
                {
                    Console.WriteLine("\tEnter your UserName");
                     uname = Console.ReadLine();
                    Console.WriteLine("\tEnter your Password");
                    upassword = int.Parse(Console.ReadLine());
                    if(userName==uname && password==upassword)
                    {
                        UserDetails.UserPage d = new UserDetails.UserPage();
                        Console.WriteLine("___________________________\n");
                        d.user();
                        
                    }
                    else
                    {
                        throw new UserPasswordNotMatcching("UserName and Password not matching\n");
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
              





            }
            else if(type == "Deparment")
            {

                Console.WriteLine("\n");
                Console.WriteLine("\n");


                Console.WriteLine("\tDepartment Login\t\t\t\t");
                Console.WriteLine("___________________________\n");

                try
                {
                    Console.WriteLine("\tEnter your UserName");
                    uname = Console.ReadLine();
                    Console.WriteLine("\tEnter your Password");
                    upassword = int.Parse(Console.ReadLine());
                    if (userName == uname && password == upassword)
                    {

                        Dentist.DepartmentMain dd = new Dentist.DepartmentMain();
                Console.WriteLine("___________________________\n");
                dd.userDep();
                    }
                    else
                    {
                        throw new UserPasswordNotMatcching("UserName and Password not matching\n");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else if(type == "Doctor")
            {

                        Console.WriteLine("\n");
                        Console.WriteLine("\n");


                        Console.WriteLine("\tDoctor Login\t\t\t\t");
                        Console.WriteLine("___________________________\n");

                        try
                        {
                            Console.WriteLine("\tEnter your UserName");
                            uname = Console.ReadLine();
                            Console.WriteLine("\tEnter your Password");
                           upassword = int.Parse(Console.ReadLine());
                            if (userName == uname && password == upassword)
                            {
                                UserDoctor.DoctorPage d = new UserDoctor.DoctorPage();
                Console.WriteLine("___________________________\n");
                d.user();
                    }
                    else
                    {
                        throw new UserPasswordNotMatcching("UserName and Password not matching\n");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else if(type == "Lab")
            {
                                Console.WriteLine("\n");
                                Console.WriteLine("\n");


                                Console.WriteLine("\tLab Login\t\t\t\t");
                                Console.WriteLine("___________________________\n");

                                try
                                {
                                    Console.WriteLine("\tEnter your UserName");
                                    uname = Console.ReadLine();
                                    Console.WriteLine("\tEnter your Password");
                                     upassword = int.Parse(Console.ReadLine());
                                    if (userName == uname && password == upassword)
                                    {
                                        UserLab.LabPage d = new UserLab.LabPage();
                Console.WriteLine("___________________________\n");
                d.user();
                    }
                    else
                    {
                        throw new UserPasswordNotMatcching("UserName and Password not matching\n");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else
            {
                return;
            }



        }

    }
}
