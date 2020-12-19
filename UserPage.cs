using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hospetal
{

    public abstract class User
    {
        public virtual String myName {get; set;}
        public virtual String myEmail { get; set; }
        public virtual int myAge {get; set;}
        public virtual long myMobile { get; set;}
        public virtual String myProblem { get; set;}

    }
    class UserDetails:User
    {
        String Name;
        int Age;
        long mobile;
        String problem;
        String email;

        public UserDetails(String Name,String email,int Age,long mobile,String problem)
        {
            this.Name = Name;
            this.Age = Age;
            this.mobile = mobile;
            this.problem = problem;
            this.email = email;
            createMyFile(email,Name,Age,mobile,problem);
        }

        public static void createMyFile(String eml,String name,int age,long mobile,String uproblem)
        {
            try
            {
                String path= @"D:\HospetalManagement\userdata\" + eml+".txt";
                if (!File.Exists(path))
                {
                    FileStream fs = new FileStream(@"D:\HospetalManagement\userdata\" + eml + ".txt", FileMode.OpenOrCreate,FileAccess.Write);
                    fs.Close();
                    using (TextWriter ts=File.AppendText(path))
                    {
                        ts.Write(name+" "+eml + " "+ age+" "+mobile+" " +uproblem);
                        ts.Close();
                    }
                    
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public override String myName
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

        public override String myEmail
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

        public override int myAge
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

        public override long myMobile
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
        public override String myProblem
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

         public static void Display(List<UserDetails> l)
        {

            Console.WriteLine("");
            Console.WriteLine("_____________________________________________________________________________________________________");
            Console.WriteLine("|\tNAME\t\tEMAIL\t\t\t AGE\t\t tMobile\t\tHEALTH PROBLEM|");
            Console.WriteLine("______________________________________________________________________________________________________");
            foreach (var v in l)
            {
                Console.Write("|\t"+ v.myName + "\t  " + v.email + " \t\t" + v.myAge + "\t\t " + v.myMobile + " \t\t" + v.myProblem+"\t|");
                Console.WriteLine();

            }
            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine("");

        }

        public static void Update(List<UserDetails> l,String uname, String uemail, int uage,String uproblem,long unum)
        {
            int countval = 0;
         
            try
            {
                foreach (var v in l)
                {
                    if (v.myEmail == uemail)
                    {
                        v.myName = uname;
                        v.myAge = uage;
                        v.myMobile = unum;
                        v.myEmail = uemail;
                                String path = @"D:\HospetalManagement\userdata\" +uemail + ".txt";
                                File.Delete(path);
                                FileStream fs = new FileStream(@"D:\HospetalManagement\userdata\" + uemail + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                            
                            fs.Close();
                            using (TextWriter ts = File.AppendText(path))
                            {
                                ts.Write(uname + " " + uemail + " " + uage + " " + unum + " " + uproblem);
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

        }

        public static  void Delete(List<UserDetails> l,String uemail)
        {
            int countval = 0;
            try
            { 
            foreach (var v in l)
            {
                if (v.myEmail == uemail)
                {
                    l.Remove(v);
                        Console.WriteLine("Data Deleted successfuly");
                        String path = @"D:\HospetalManagement\userdata\" + uemail + ".txt";
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
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

    }


        public static void Preescriptionn(String email)
        {
            String path = @"D:\HospetalManagement\Doctordata\patientprescription";
            String[] files = Directory.GetFiles(path);


            Console.WriteLine("_____________________________________________________________________________________");
            Console.WriteLine("|\t\tNAME\t\tEMAIL\t\t PROBLEM\t MEDICIEN\t|");
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

        }


            public static void Report(String email)
        {
            String path = @"D:\HospetalManagement\labdata\patientLabReport";
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

        public class UserPage
    {
        String Name;
        int Age;
        long mobile;
        String problem;
        String email;



        public  void user()
        {
                List<UserDetails> UD = new List<UserDetails>();
                
                while (true)
            { 
            Console.WriteLine("__________________________________________________________________________________________________________________________________________________________________________________________________________________");
            Console.Write("\tWELCOME TO MYHOSPETAL\t\t\t\t\t\t\t\t");
            Console.Write("1.for oppointment\t\t");
            Console.Write("2.option:display/update/delete\t\t");
                    Console.Write("3, for Report\t");
                    Console.Write("4, for Prescription\t");
                    Console.WriteLine("5.for Close");
                        
            Console.WriteLine();
            Console.WriteLine("___________________________________________________________________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine();
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\tEnter you choice");
            int choice = int.Parse(Console.ReadLine());
            
                    switch (choice)
                {
                    case 1:
                            

                                Console.WriteLine("Enter your name");
                                Name = Console.ReadLine();
                                Console.WriteLine("___________");

                                Console.WriteLine("Enter your email");
                                email = Console.ReadLine();
                                Console.WriteLine("___________");
                                Console.WriteLine("");
                                Console.WriteLine("Enter your Age");
                                Age = int.Parse(Console.ReadLine());
                                Console.WriteLine("___________");
                                Console.WriteLine("");
                                Console.WriteLine("Enter your Mobile Number");
                                mobile = long.Parse(Console.ReadLine());
                                Console.WriteLine("___________");

                                Console.WriteLine("Enter your Health Problem");
                                problem = Console.ReadLine();
                                UD.Add(new UserDetails(Name, email, Age, mobile, problem));
                                
                           
                            
                                break;


                        case 2:
                            Console.WriteLine("___________________________________________________________________________________________");
                            Console.Write("1.for update oppointment\t ");
                            Console.Write("2.for display data\t");
                            Console.Write("3.for Delete oppointment\t");
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
                                    UserDetails.Update(UD,Name, email, Age,  problem,mobile);
                                    break;


                                case 2:
                                    UserDetails.Display(UD);
                                    break;



                                case 3:

                                    Console.WriteLine("Enter your Email");
                                    email = Console.ReadLine();
                                    UserDetails.Delete(UD, email);
                                    break;
                                case 4: return;
                                   

                            }
                            break;

                   case 3:
                            Console.WriteLine("Enter your Email");
                            email = Console.ReadLine();
                            UserDetails.Report(email);
                            break;


                        case 4:
                            Console.WriteLine("Enter your Email");
                            email = Console.ReadLine();
                            UserDetails.Preescriptionn(email);
                            break;
                   case 5:return;
                           





                    }
                    
               }

            }
         }

        private static void Display(SortedSet<UserDetails> uD)
        {
            throw new NotImplementedException();
        }

        private static void Update(SortedSet<UserDetails> uD, string name, string email, int age, string problem, long mobile)
        {
            throw new NotImplementedException();
        }
    }
}
