using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

    namespace Hospetal
    {

        public abstract class Lab
        {
           

        abstract public String pName { get; set; }
        abstract public String pEmail { get; set; }
        abstract public int pAge { get; set; }
        abstract public String pProblem { get; set; }



        abstract public long pMobile { get; set; }
        abstract public String Preport { get; set; }

    }
        class UserLab : Lab
        {
            String Name;
            int Age;
            long mobile;
            String problem;
            String email;
            String report;

            public UserLab(String Name, String email ,int Age,String problem ,String report)
            {
                this.Name = Name;
                this.Age = Age;
                this.problem = problem;
                this.email = email;
                createMyFile(email, Name, Age, problem,report);
            }

            public static void createMyFile(String peml, String pname, int page, String pproblem,String preport)
            {
                try
                {
                    String path = @"D:\HospetalManagement\labdata\patientLabReport\" + peml + ".txt";
                    if (!File.Exists(path))
                    {
                        FileStream fs = new FileStream(@"D:\HospetalManagement\labdata\patientLabReport\" + peml + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                        fs.Close();
                        using (TextWriter ts = File.AppendText(path))
                        {
                            ts.Write(pname + " " + peml + " " + page +  " " + pproblem+" "+preport);
                            ts.Close();
                        }

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            public override String pName
            {
                get
                {
                    return Name;
                }
                set
                {
                    Name = value;

                }
            }

            public override String pEmail
            {
                get
                {
                    return email;
                }
                set
                {
                    email = value;

                }
            }

            public override int pAge
            {
                get
                {
                    return Age;
                }
                set
                {
                    Age = value;

                }
            }

            public override long pMobile
            {
                get
                {
                    return mobile;
                }
                set
                {
                    mobile = value;

                }
            }
        public override string pProblem 
            {
                get
                {
                    return problem;
                }
                set
                {
                    Name = value;

                }
            }

        public override string Preport 
        {
            get
            {
                return report;
            }
            set
            {
                report = value;

            }
        }

        public static void Display(List<UserLab> l)
            {

                Console.WriteLine("");
                Console.WriteLine("_____________________________________________________________________________________________________");
                Console.WriteLine("|\tNAME\t\tEMAIL\t\t\t AGE\t\t tMobile\t\tReport|");
                Console.WriteLine("______________________________________________________________________________________________________");
                foreach (var v in l)
                {
                    Console.Write("|\t" + v.pName + "\t  " + v.pEmail + " \t\t" + v.pAge + "\t\t " + v.pMobile + " \t\t" + v.Preport + "\t|");
                    Console.WriteLine();

                }
                Console.WriteLine("________________________________________________________________________________________________________");
                Console.WriteLine("");

            }

            public static void Update(List<UserLab> l, String uname, String uemail, int uage, String uproblem, String Preport)
            {
                int countval = 0;

                try
                {
                    foreach (var v in l)
                    {
                        if (v.pEmail == uemail)
                        {
                            v.pName = uname;
                            v.pAge = uage;
                            v.Preport =Preport;
                            v.pEmail= uemail;
                            String path = @"D:\HospetalManagement\userdata\" + uemail + ".txt";
                            File.Delete(path);
                            FileStream fs = new FileStream(@"D:\HospetalManagement\userdata\" + uemail + ".txt", FileMode.OpenOrCreate, FileAccess.Write);

                            fs.Close();
                            using (TextWriter ts = File.AppendText(path))
                            {
                                ts.Write(uname + " " + uemail + " " + uage + " " + uproblem);
                                ts.Close();
                            }

                            countval++;




                        }


                    }

                    if (countval == 0)
                    {
                        throw new UserPasswordNotMatcching("Invalid Email");
                    }
                    else
                    {
                        throw new Successfull("Update successfull");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }



            }

            public static void Delete(List<UserLab> l, String uemail)
            {
                int countval = 0;
                try
                {
                    foreach (var v in l)
                    {
                        if (v.pEmail == uemail)
                        {
                            l.Remove(v);
                            Console.WriteLine("Data Deleted successfuly");
                            String path = @"D:\HospetalManagement\labdata\patientLabReport\" + uemail + ".txt";
                            File.Delete(path);
                            countval++;

                        }

                    }

                    if (countval == 0)
                    {
                        throw new UserPasswordNotMatcching("Invalid Email");
                    }
                    else
                    {
                        new Successfull("Delete successfull");
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            public static void DReport()
            {
                String path = @"D:\HospetalManagement\Doctordata\patientlabdata\";
                String[] files = Directory.GetFiles(path);

                Console.WriteLine("_____________________________________________________________________________________");
                Console.WriteLine("|\t\tNAME\t\tEMAIL\t\t AGE\t\t PROBLEM\t TEST\t|");
                Console.WriteLine("_____________________________________________________________________________________");

                foreach (String name in files)
                {

                    String[] data = File.ReadAllLines(name);
                    for (int i = 0; i < data.Length; i++)
                    {
                        String[] databydata = data[i].Split(" ");
                        for (int j = 0; j < databydata.Length; j++)
                        {
                            Console.Write("\t" + databydata[j] + "\t");

                        }
                        Console.WriteLine();
                    }
                }
            Console.WriteLine("_____________________________________________________________________________________");
            Console.WriteLine("");







        }

        public class LabPage
            {
                String Name;
                int Age;
                String problem;
                String email;
                String Report;



                public void user()
                {
                    List<UserLab> UD = new List<UserLab>();

                    while (true)
                    {
                        Console.WriteLine("__________________________________________________________________________________________________________________________________________________________________________________________________________________");
                        Console.Write("\tWELCOME TO MYHOSPETAL LAB\t\t\t\t\t\t\t\t\t\t");
                        Console.Write("1.doctor reports\t");
                        Console.Write("2.AddReport\t");
                        Console.Write("3.option:display/update/delete\t");
                        Console.Write("4.for LogOut");
                        Console.WriteLine();
                        Console.WriteLine("___________________________________________________________________________________________________________________________________________________________________________________________________________________");
                        Console.WriteLine();
                        Console.WriteLine("\t\tEnter you choice");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {


                            case 1:
                                UserLab.DReport();
                                break;


                            case 2:
                            Console.WriteLine("Enter your name");
                            Name = Console.ReadLine();
                            Console.WriteLine("__________________________________");
                            Console.WriteLine("");

                            Console.WriteLine("Enter your email");
                            email = Console.ReadLine();
                            Console.WriteLine("");

                            Console.WriteLine("Enter your Age");
                            Age = int.Parse(Console.ReadLine());
                            Console.WriteLine("__________________________________");
                            Console.WriteLine("");

                            Console.WriteLine("Enter patient problem");
                            problem = Console.ReadLine();
                            Console.WriteLine("____________________________________");
                            Console.WriteLine("");
                            Console.WriteLine("Enter your Problem");
                            Report = Console.ReadLine();
                            UD.Add(new UserLab(Name, email, Age, problem, Report));
                            break;

                           


                            case 3:
                                Console.WriteLine("___________________________________________________________________________________________");
                                Console.Write("1.for update report\t ");
                                Console.Write("2.for display report\t");
                                Console.Write("3.for Delete report\t");
                                Console.WriteLine();
                                Console.WriteLine("___________________________________________________________________________________________");
                                Console.WriteLine();

                                Console.WriteLine("Enter you choice");
                                Console.Write("\t\t");
                                Console.WriteLine("________________________");

                            int choices = int.Parse(Console.ReadLine());

                                switch (choices)
                                {
                                    case 1:
                                        Console.WriteLine("Enter your name");
                                        Name = Console.ReadLine();
                                        Console.WriteLine("__________________________________");
                                        Console.WriteLine("");

                                        Console.WriteLine("Enter your email");
                                        email = Console.ReadLine();
                                         Console.WriteLine("__________________________________");
                                         Console.WriteLine("");

                                        Console.WriteLine("Enter your Age");
                                        Age = int.Parse(Console.ReadLine());
                                        Console.WriteLine("__________________________________");
                                        Console.WriteLine("");

                                    Console.WriteLine("Enter patient problem");
                                        problem = Console.ReadLine();
                                    Console.WriteLine("____________________________________");
                                        Console.WriteLine("");
                                        Console.WriteLine("Enter patient Report");
                                        Report= Console.ReadLine();
                                        UserLab.Update(UD, Name, email, Age, problem,Report);
                                        break;


                                    case 2:
                                        UserLab.Display(UD);
                                        break;



                                    case 3:

                                        Console.WriteLine("Enter your Email");
                                        email = Console.ReadLine();
                                        UserLab.Delete(UD, email);
                                        break;
                                    case 4: return;


                                }
                                break;

                           





                        }

                    }

                }
            }

        internal static void Delete(LinkedList<cardiologist> cd, string depDoctorEmail)
        {
            throw new NotImplementedException();
        }
    }
    }


