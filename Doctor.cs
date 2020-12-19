using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

        namespace Hospetal
        {

            public abstract class Doctor
            {
                
               abstract public  String pName { get; set; }
                abstract public String pEmail { get; set; }
               abstract public  int pAge { get; set; }
               abstract public String pProblem { get; set; }
             

               
                abstract public long pMobile { get; set; }
                abstract public  String Preport { get; set; }
              


            }
            class UserDoctor : Doctor
            {
                String Name;
                int Age;
                long mobile;
                String problem;
                String email;
                String Test;
                String medi;

                public UserDoctor(String Name, String email, int Age, long mobile, String problem,String Test)
                {
                    this.Name = Name;
                    this.Age = Age;
                    this.mobile = mobile;
                    this.problem = problem;
                    this.email = email;
                    this.Test = Test;
            createMyPatientLabTest(email, Name, Age, mobile, problem, Test);
                }

                public UserDoctor(String Name,String email,String problem,String medi)
                {
                    this.Name = Name;
                    
                    this.email = email;
                    this.medi = medi;
                    this.problem = problem;
                    createMypricreption(email, Name, problem,medi);

                }

                public static void createMypricreption(String eml, String name,String pproblem,String pmedicien)
                {
                    try
                    {
                        String path = @"D:\HospetalManagement\Doctordata\patientprescription\" + eml + ".txt";
                        if (!File.Exists(path))
                        {
                            FileStream fs = new FileStream(@"D:\HospetalManagement\Doctordata\patientprescription\" + eml + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                            fs.Close();
                            using (TextWriter ts = File.AppendText(path))
                            {
                                ts.Write(name + " \t" + eml + "\t " +pproblem+"\t "+ pmedicien);
                                ts.Close();
                            }

                        }


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }



                public static void createMyPatientLabTest(String eml, String name,int age,long mobile,String problem, String Test)
                {
            Console.WriteLine("create file");
                    try
                    {
                        String path = @"D:\HospetalManagement\Doctordata\patientlabdata\" + eml + ".txt";
                        if (!File.Exists(path))
                        {
                            FileStream fs = new FileStream(@"D:\HospetalManagement\Doctordata\patientlabdata\" + eml + ".txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            fs.Close();
                            using (TextWriter ts = File.AppendText(path))
                            {
                                ts.Write( eml +"\t"+name+"\t"+age+"\t "+problem+"\t"+Test);
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

        public override String pProblem 
        {
            get
            {
                return problem;
            }
            set
            {
                problem= value;

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
                public override String Preport
                {
                    get
                    {
                        return Test;
                    }
                    set
                    {
                        Test = value;

                    }
                }

                public String Pmed
                {
                    get
                    {
                        return medi;
                    }
                    set
                    {
                        medi = value;
                    }
                }



                public static void Oppointmnent()
                {


                    String path = @"D:\HospetalManagement\userdata\";
                    String[] files = Directory.GetFiles(path);

            Console.WriteLine("_____________________________________________________________________________________");
            Console.WriteLine("|\t\tNAME\t\tEMAIL\t\t AGE\t\t Mobile\\ttReport\t|");
            Console.WriteLine("_____________________________________________________________________________________");

            foreach (String name in files)
                    {

                        String[] data = File.ReadAllLines (name);
                        for(int i=0;i<data.Length;i++)
                        {
                        String[] databydata = data[i].Split(" ");
                         for (int j = 0; j< databydata.Length; j++)
                            {
                        Console.Write("\t" + databydata[j] + "\t");
                        
                            }
                    Console.WriteLine();
                        }

                        



                }
            Console.WriteLine("______________________________________________________________________________________________________");

            Console.WriteLine("\n");

        }

        public static void Displaypres(List<UserDoctor> k)
        {

            Console.WriteLine("");
            Console.WriteLine("_________________________________________________________________________________________");
            Console.WriteLine("|\tNAME\t\tEMAIL\t\t PROBLEM\t\t MEDICIEN\t\t|");
            Console.WriteLine("_________________________________________________________________________________________");
            foreach (var v in k)
            {
                Console.Write("|\t" + v.pName + "\t\t  " + v.pEmail + " \t\t" + v.pProblem + "\t\t " + v.Pmed+ "\t|");
                Console.WriteLine();

            }
            Console.WriteLine("_______________________________________________________________________________________");
            Console.WriteLine("");

        }
        public static void Display(List<UserDoctor> k)
                {

                    Console.WriteLine("");
                    Console.WriteLine("___________________________________________________________________________________________________________");
                    Console.WriteLine("|\tNAME\t\tEMAIL\t\t\t AGE\t\t Mobile\t\tReport|");
                    Console.WriteLine("__________________________________________________________________________________________________________");
                    foreach (var v in k)
                    {
                        Console.Write("|\t" + v.pName + "\t\t  " + v.pEmail + " \t\t\t" + v.pAge + "\t\t " + v.pMobile + " \t\t" + v.Preport + "\t|");
                        Console.WriteLine();

                    }
                    Console.WriteLine("____________________________________________________________________________________________________________");
                    Console.WriteLine("");

                }

                public static void Update(List<UserDoctor> l, String pname, String pemail,long pmobile,String ptest,int page,String pproblem)
                {
                    int countval = 0;

                    try
                    {
                        foreach (var v in l)
                        {
                            if (v.pEmail == pemail)
                            {
                                v.pName = pname;
                                v.pMobile = pmobile;
                                v.pAge = page;
                                v.problem = pproblem;
                                v.Preport = ptest;
                               
                                String path = @"D:\HospetalManagement\Doctordata\patientlabdata\" + pemail + ".txt";
                                File.Delete(path);
                                FileStream fs = new FileStream(@"D:\HospetalManagement\Doctordata\patientlabdata\" + pemail + ".txt", FileMode.OpenOrCreate, FileAccess.Write);

                                fs.Close();
                                using (TextWriter ts = File.AppendText(path))
                                {
                                    ts.Write(pname + " "+pmobile+" "+ pemail + " "  + ptest);
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

                public static void Delete(List<UserDoctor> k, String uemail)
                {
                    int countval = 0;
                    try
                    {
                        foreach (var v in k)
                        {
                            if (v.pEmail == uemail)
                            {
                                k.Remove(v);
                                Console.WriteLine("Data Deleted successfuly");
                                String path = @"D:\HospetalManagement\Doctordata\patientlabdata\" + uemail + ".txt";
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

               

     public class DoctorPage
                {
                    String Name;
                    int Age;
                    long mobile;
                    String problem;
                    String email;
                    String medicien;
                    String Test;



                    public void user()
                    {
                        List<UserDoctor> UD = new List<UserDoctor>();

                        while (true)
                        {
                            Console.WriteLine("__________________________________________________________________________________________________________________________________________________________________________________________________________________");
                            Console.Write("\tWELCOME TO MYHOSPETAL DOCTOR\t\t\t\t\t\t\t");
                            Console.Write("1.CheckPatientOpointment\t");
                            Console.Write("2.AddPrescription\t");
                            Console.Write("3.AddReport\t");
                            Console.Write("4.option:display/update/delete\t");
                            Console.Write("5.for LogOut");
                            Console.WriteLine();
                            Console.WriteLine("___________________________________________________________________________________________________________________________________________________________________________________________________________________");
                            Console.WriteLine();
                            Console.WriteLine("\tEnter you choice");
                            int choice = int.Parse(Console.ReadLine());

                            switch (choice)
                            {


                                case 1:
                                    UserDoctor.Oppointmnent();
                                    break;

                                case 2:
                          
                                    Console.WriteLine("Enter patient name");
                                    Name = Console.ReadLine();
                                    Console.WriteLine("_______________________");

                                    Console.WriteLine("Enter patien email");
                                    email = Console.ReadLine();
                                    Console.WriteLine("________________________");
                                    Console.WriteLine("");
                                   
                                    Console.WriteLine("Enter patient Health Problem");
                                    problem= Console.ReadLine();
                                    Console.WriteLine("________________________");
                                        Console.WriteLine("");
                                        Console.WriteLine("Enter  medicien");
                                        medicien = Console.ReadLine();
                                    Console.WriteLine("________________________");
                                    Console.WriteLine("");
                            List<UserDoctor> dm = new List<UserDoctor>();
                                    dm.Add(new UserDoctor(Name, email,problem,medicien));
                                    UserDoctor.Displaypres(dm);
                                    
                                    break;


                                case 3:
                                    Console.WriteLine("Enter your name");
                                    Name = Console.ReadLine();
                                    Console.WriteLine("___________________________");

                                    Console.WriteLine("Enter your email");
                                    email = Console.ReadLine();
                                    Console.WriteLine("___________________________");
                                    Console.WriteLine("");
                                    Console.WriteLine("Enter your Age");
                                    Age = int.Parse(Console.ReadLine());
                                    Console.WriteLine("___________________________");
                                    Console.WriteLine("");
                                    Console.WriteLine("Enter your Health Problem");
                                    problem = Console.ReadLine();
                                    Console.WriteLine("___________________________");
                                    Console.WriteLine("");
                                    Console.WriteLine("Enter patient Medical test needs");
                                    Test = Console.ReadLine();

                                    UD.Add(new UserDoctor(Name, email,Age,mobile,problem,Test));
                                    break;
                                    

                                case 4:
                                    Console.WriteLine("___________________________________________________________________________________________");
                                    Console.Write("1.for update report\t ");
                                    Console.Write("2.for display report\t");
                                    Console.Write("3.for Delete report\t");
                                    Console.WriteLine();
                                    Console.WriteLine("___________________________________________________________________________________________");
                                    Console.WriteLine();

                                    Console.WriteLine("Enter you choice");
                                    Console.Write("\t\t\t\t\t\t\t\t\t\t\t\t");

                                    int choices = int.Parse(Console.ReadLine());

                                    switch (choices)
                                    {
                                        case 1:
                                            Console.WriteLine("Enter your name");
                                            Name = Console.ReadLine();
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");

                                            Console.WriteLine("Enter your email");
                                            email = Console.ReadLine();
                                            Console.WriteLine("___________");
                                            Console.WriteLine("Enter your Age");
                                            Age = int.Parse(Console.ReadLine());
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");
                                            Console.WriteLine("Enter your Mobile Number");
                                            mobile = long.Parse(Console.ReadLine());
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");
                                            Console.WriteLine("Enter your Problem");
                                            problem = Console.ReadLine();
                                            Console.WriteLine("Enter your LabTest Need");
                                            String test= Console.ReadLine();
                                            UserDoctor.Update(UD, Name, email, mobile, problem,Age, test);
                                            break;


                                        case 2:
                                            UserDoctor.Display(UD);
                                            break;



                                        case 3:

                                            Console.WriteLine("Enter your Email");
                                            email = Console.ReadLine();
                                            UserDoctor.Delete(UD, email);
                                            break;
                                        case 4: return;


                                    }
                                    break;
                        case 5:return;







                            }

                        }

                    }
                }

               
            }
        }

    


