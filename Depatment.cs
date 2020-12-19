using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Hospetal
{

    interface Department
    {
        String depName { get; set; }
        int depid { get; set; }
        String depDoctorName { get; set; }

        String depDoctorEmail { get; set; }
        long depDoctorMobile { get; set; }

        String depDoctorQualification { get; set; }

    }


    public class cardiologist : Department
    {
        String DepName;
        int DepId;
        String DepDoctorName;
        String DepDoctorEmail;
        long DepDoctorMobile;
        String DepDoctorQualification;

        public cardiologist(String DepName, int DepId, String DepDoctorName, String DepDoctorEmail, long DepDoctorMobile, String DepDoctorQualification)
        {
            this.DepName = DepName;
            this.DepId = DepId;
            this.DepDoctorName = DepDoctorName;
            this.DepDoctorEmail = DepDoctorEmail;
            this.DepDoctorMobile = DepDoctorMobile;
            this.DepDoctorQualification = DepDoctorQualification;
            createMyFile(DepName, DepId, DepDoctorName, DepDoctorEmail, DepDoctorMobile, DepDoctorQualification);

        }

        public static void createMyFile(String dDepName, int dDepId, String dDepDoctorName, String dDepDoctorEmail, long dDepDoctorMobile, String dDepDoctorQualification)
       
        {
            try
            {
                String path = @"D:\HospetalManagement\department\Cardiology\" + dDepDoctorEmail + ".txt";
                if (!File.Exists(path))
                {
                    FileStream fs = new FileStream(@"D:\HospetalManagement\department\Cardiology\" + dDepDoctorEmail + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                    using (TextWriter ts = File.AppendText(path))
                    {
                        ts.Write(dDepDoctorName+" "+dDepDoctorEmail+" "+dDepId+" "+dDepName+ " "+dDepDoctorQualification+" "+dDepDoctorMobile);

                        ts.Close();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public String depName
        {
            get
            {
                return DepName;
            }
            set
            {
                DepName = value;
            }
        }
        public int depid
        {
            get
            {
                return DepId;
            }
            set
            {
                DepId = value;
            }
        }
        public String depDoctorName
        {
            get
            {
                return DepDoctorName;
            }
            set
            {
                DepDoctorName = value;
            }
        }

        public String depDoctorEmail
        {
            get
            {
                return DepDoctorEmail;
            }
            set
            {
                depDoctorEmail = value;
            }
        }
        public long depDoctorMobile
        {
            get
            {
                return DepDoctorMobile;
            }
            set
            {
                DepDoctorMobile = value;
            }
        }


        public String depDoctorQualification
        {
            get
            {
                return DepDoctorQualification;
            }
            set
            {
                DepDoctorQualification = value;
            }
        }

        public static void Display(LinkedList<cardiologist> l)
        {

            Console.WriteLine("");
            Console.WriteLine("_____________________________________________________________________________________________________");
            Console.WriteLine("|\tName\t\t Email\t\t DepartmentName\t\t DepartmentId \t\t Qualification\t\t Mobile|");
            Console.WriteLine("______________________________________________________________________________________________________");
            foreach (var v in l)
            {
                Console.Write("|\t" + v.depDoctorName + "\t\t" + v.DepDoctorEmail + "\t\t" + v.depName + "\t  " + v.depid + " \t\t" + v.depDoctorQualification + "\t" + v.depDoctorMobile + "\t|");
                Console.WriteLine();

            }
            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine("");

        }

        public static void Update(LinkedList<cardiologist> l, String dDepName, int dDepId, String dDepDoctorName, String dDepDoctorEmail, long dDepDoctorMobile, String dDepDoctorQualification)
        {
            int countval = 0;

            try
            {
                foreach (var v in l)
                {
                    if (v.depDoctorEmail == dDepDoctorEmail)
                    {
                        v.depDoctorName = dDepDoctorName;
                        v.DepDoctorEmail = dDepDoctorEmail;
                        v.depName = dDepName;
                        v.depid = dDepId;
                        v.depDoctorQualification = dDepDoctorQualification;
                        v.depDoctorMobile = dDepDoctorMobile;


                        String path = @"D:\HospetalManagement\department\Cardiology\" + dDepDoctorEmail + ".txt";
                        File.Delete(path);
                        FileStream fs = new FileStream(@"D:\HospetalManagement\department\Cardiology\" + dDepDoctorEmail + ".txt", FileMode.OpenOrCreate, FileAccess.Write);

                        fs.Close();
                        using (TextWriter ts = File.AppendText(path))
                        {
                            ts.Write(v.depDoctorName + " " + v.DepDoctorEmail + " " + v.depName + "  " + v.depid + " " + v.DepDoctorMobile + " " + v.DepDoctorMobile);

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

        public static void Delete(LinkedList<cardiologist> l, String uemail)
        {
            int countval = 0;
            try
            {
                foreach (var v in l)
                {
                    if (v.depDoctorEmail == uemail)
                    {
                        l.Remove(v);
                        Console.WriteLine("Data Deleted successfuly");
                        String path = @"D:\HospetalManagement\department\Cardiology\" + uemail + ".txt";
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

       
    }


   public class Dentist : Department
    {
        String DepName;
        int DepId;
        String DepDoctorName;
        String DepDoctorEmail;
        long DepDoctorMobile;
        String DepDoctorQualification;

        public Dentist(String DepName, int DepId, String DepDoctorName, String DepDoctorEmail, long DepDoctorMobile, String DepDoctorQualification)
        {
            this.DepName = DepName;
            this.DepId = DepId;
            this.DepDoctorName = DepDoctorName;
            this.DepDoctorEmail = DepDoctorEmail;
            this.DepDoctorMobile = DepDoctorMobile;
            this.DepDoctorQualification = DepDoctorQualification;
            createMyFile(DepName, DepId, DepDoctorName, DepDoctorEmail, DepDoctorMobile, DepDoctorQualification);



        }

        public static void createMyFile(String dDepName, int dDepId, String dDepDoctorName, String dDepDoctorEmail, long dDepDoctorMobile, String dDepDoctorQualification)

        {
            try
            {
                String path = @"D:\HospetalManagement\department\dentist\" + dDepDoctorEmail + ".txt";
                if (!File.Exists(path))
                {
                    FileStream fs = new FileStream(@"D:\HospetalManagement\labdata\patientLabReport\" + dDepDoctorEmail + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                    using (TextWriter ts = File.AppendText(path))
                    {
                        ts.Write(dDepDoctorName + " " + dDepDoctorEmail + " " + dDepId + " " + dDepName + " " + dDepDoctorQualification + " " + dDepDoctorMobile);

                        ts.Close();
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public String depName
        {
            get
            {
                return DepName;
            }
            set
            {
                DepName = value;
            }
        }
        public int depid
        {
            get
            {
                return DepId;
            }
            set
            {
                DepId = value;
            }
        }
        public String depDoctorName
        {
            get
            {
                return DepDoctorName;
            }
            set
            {
                DepDoctorName = value;
            }
        }

        public String depDoctorEmail
        {
            get
            {
                return DepDoctorEmail;
            }
            set
            {
                depDoctorEmail = value;
            }
        }
        public long depDoctorMobile
        {
            get
            {
                return depDoctorMobile;
            }
            set
            {
                depDoctorMobile = value;
            }
        }

        public String depDoctorQualification
        {
            get
            {
                return DepDoctorQualification;
            }
            set
            {
                DepDoctorQualification = value;
            }
        }

        //
        public static void Display(LinkedList<Dentist> l)
        {

            Console.WriteLine("");
            Console.WriteLine("_____________________________________________________________________________________________________");
            Console.WriteLine("|\tName\t\t Email\t\t DepartmentName\t\t DepartmentId \t\t Qualification\t\t Mobile|");
            Console.WriteLine("______________________________________________________________________________________________________");
            foreach (var v in l)
            {
                Console.Write("|\t" + v.depDoctorName + "\t\t" + v.DepDoctorEmail + "\t\t" + v.depName + "\t  " + v.depid + " \t\t" + v.depDoctorQualification +"\t" + v.depDoctorMobile + "\t|");
                Console.WriteLine();

            }
            Console.WriteLine("________________________________________________________________________________________________________");
            Console.WriteLine("");

        }

        public static void Update(LinkedList<Dentist> l, String dDepName, int dDepId, String dDepDoctorName, String dDepDoctorEmail, long dDepDoctorMobile, String dDepDoctorQualification)
        {
            int countval = 0;

            try
            {
                foreach (var v in l)
                {
                    if (v.depDoctorEmail == dDepDoctorEmail)
                    {
                        v.depDoctorName = dDepDoctorName;
                        v.DepDoctorEmail = dDepDoctorEmail;
                        v.depName = dDepName;
                        v.depid = dDepId;
                        v.depDoctorQualification = dDepDoctorQualification;
                        v.depDoctorMobile = dDepDoctorMobile;


                        String path = @"D:\HospetalManagement\department\dentist\" + dDepDoctorEmail + ".txt";
                        File.Delete(path);
                        FileStream fs = new FileStream(@"D:\HospetalManagement\department\dentist\" + dDepDoctorEmail + ".txt", FileMode.OpenOrCreate, FileAccess.Write);

                        fs.Close();
                        using (TextWriter ts = File.AppendText(path))
                        {
                            ts.Write(v.depDoctorName + " " + v.DepDoctorEmail + " " + v.depName + "  " + v.depid + " " + v.DepDoctorMobile + " " + v.DepDoctorMobile);

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

        public  static void Delete(LinkedList<Dentist> l, String uemail)
        {
            int countval = 0;
            try
            {
                foreach (var v in l)
                {
                    if (v.depDoctorEmail == uemail)
                    {
                        l.Remove(v);
                        Console.WriteLine("Data Deleted successfuly");
                        String path = @"D:\HospetalManagement\department\dentist\" + uemail + ".txt";
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


       public class DepartmentMain
        {

            public String DepName;
            int DepId;
            String DepDoctorName;
            String DepDoctorEmail;
            long DepDoctorMobile;
            String DepDoctorQualification;
            LinkedList<cardiologist> cd = new LinkedList<cardiologist>();
            LinkedList<Dentist> den = new LinkedList<Dentist>();
            public void userDep()
            {

               
                while (true)
                {
                    Console.WriteLine("___________________________________________________________________________________________");
                    Console.Write("1 for cordinology\t");
                    Console.Write("2 for dentist \t");
                    Console.Write("3.for updtae/dispay/delete\t ");
                    Console.Write("3 for close");
                    Console.WriteLine();
                    Console.WriteLine("___________________________________________________________________________________________");
                    Console.WriteLine();

                    Console.WriteLine("Enter your choice");
                    int choice = 0;
                    int.TryParse(Console.ReadLine(), out choice);
                    switch (choice)
                    {
                        case 1:

                            Console.WriteLine("Enter department name");
                            DepName = Console.ReadLine();
                            Console.WriteLine("___________");
                            Console.WriteLine("Enter Department id");
                            DepId = int.Parse(Console.ReadLine());
                            Console.WriteLine("___________");
                            Console.WriteLine("");
                            Console.WriteLine("Enter doctor name");
                            DepDoctorName = Console.ReadLine();
                            Console.WriteLine("___________");
                            Console.WriteLine("");
                            Console.WriteLine("Enter Doctor email");
                            DepDoctorEmail = Console.ReadLine();
                            Console.WriteLine("___________");
                            Console.WriteLine("");

                            Console.WriteLine("Enter Doctor Qualification Number");
                            DepDoctorQualification = Console.ReadLine();
                            Console.WriteLine("___________");

                            Console.WriteLine("Enter Mobile number");
                            DepDoctorMobile = long.Parse(Console.ReadLine());
                            cd.AddLast(new cardiologist(DepName, DepId, DepDoctorName, DepDoctorEmail, DepDoctorMobile, DepDoctorQualification));
                            break;

                        case 2:
                            Console.WriteLine("Enter department name");
                            DepName = Console.ReadLine();
                            Console.WriteLine("___________");
                            Console.WriteLine("Enter Department id");
                            DepId = int.Parse(Console.ReadLine());
                            Console.WriteLine("___________");
                            Console.WriteLine("");
                            Console.WriteLine("Enter doctor name");
                            DepDoctorName = Console.ReadLine();
                            Console.WriteLine("___________");
                            Console.WriteLine("");

                            Console.WriteLine("Enter Doctor email");
                            DepDoctorEmail = Console.ReadLine();
                            Console.WriteLine("___________");
                            Console.WriteLine("");

                            Console.WriteLine("Enter Doctor Qualification Number");
                            DepDoctorQualification = Console.ReadLine();
                            Console.WriteLine("___________");

                            Console.WriteLine("Enter Mobile number");
                            DepDoctorMobile = long.Parse(Console.ReadLine());
                            den.AddLast(new Dentist(DepName, DepId, DepDoctorName, DepDoctorEmail, DepDoctorMobile, DepDoctorQualification));
                            break;



                        case 3:
                            Console.WriteLine("1 for cordinology");
                            Console.WriteLine("2 for dentist ");
                            Console.WriteLine("3 for close");
                            Console.WriteLine("Enter your choice");
                            int ch = 0;
                            int.TryParse(Console.ReadLine(), out ch);
                            switch (ch)
                            {
                                case 1:
                                    Console.WriteLine("___________________________________________________________________________________________");
                                    Console.Write("1.for update \t ");
                                    Console.Write("2.for display \t");
                                    Console.Write("3.for Delete \t");
                                    Console.WriteLine();
                                    Console.WriteLine("___________________________________________________________________________________________");
                                    Console.WriteLine();

                                    Console.WriteLine("Enter you choice");
                                    Console.Write("\t\t");
                                   

                                    int choices = int.Parse(Console.ReadLine());
                                    Console.WriteLine("________________________");

                                    switch (choices)
                                    {
                                        case 1:
                                            Console.WriteLine("Enter department name");
                                            DepName = Console.ReadLine();
                                            Console.WriteLine("___________");
                                            Console.WriteLine("Enter Department id");
                                            DepId = int.Parse(Console.ReadLine());
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");
                                            Console.WriteLine("Enter doctor name");
                                            DepDoctorName = Console.ReadLine();
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");
                                            Console.WriteLine("Enter Doctor email");
                                            DepDoctorEmail = Console.ReadLine();
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");

                                            Console.WriteLine("Enter Doctor Qualification Number");
                                            DepDoctorQualification = Console.ReadLine();
                                            Console.WriteLine("___________");

                                            Console.WriteLine("Enter Mobile number");
                                            DepDoctorMobile = long.Parse(Console.ReadLine());
                                            cardiologist.Update(cd, DepName, DepId, DepDoctorName, DepDoctorEmail, DepDoctorMobile, DepDoctorQualification);
                                            break;


                                        case 2:
                                            cardiologist.Display(cd);
                                            break;



                                        case 3:

                                            Console.WriteLine("Enter your Email");
                                            DepDoctorEmail = Console.ReadLine();
                                            UserLab.Delete(cd, DepDoctorEmail);
                                            break;
                                        case 4: return;


                                    }
                                    break;

                                case 2:
                                    Console.WriteLine("___________________________________________________________________________________________");
                                    Console.Write("1.for update \t ");
                                    Console.Write("2.for display \t");
                                    Console.Write("3.for Delete\t");
                                    Console.WriteLine();
                                    Console.WriteLine("___________________________________________________________________________________________");
                                    Console.WriteLine();

                                    Console.WriteLine("Enter you choice");
                                    Console.Write("\t\t");
                                    Console.WriteLine("________________________");

                                    int chh = int.Parse(Console.ReadLine());

                                    switch (chh)
                                    {
                                        case 1:
                                            Console.WriteLine("Enter department name");
                                            DepName = Console.ReadLine();
                                            Console.WriteLine("___________");
                                            Console.WriteLine("Enter Department id");
                                            DepId = int.Parse(Console.ReadLine());
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");
                                            Console.WriteLine("Enter doctor name");
                                            DepDoctorName = Console.ReadLine();
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");
                                            Console.WriteLine("Enter Doctor email");
                                            DepDoctorEmail = Console.ReadLine();
                                            Console.WriteLine("___________");
                                            Console.WriteLine("");

                                            Console.WriteLine("Enter Doctor Qualification Number");
                                            DepDoctorQualification = Console.ReadLine();
                                            Console.WriteLine("___________");

                                            Console.WriteLine("Enter Mobile number");
                                            DepDoctorMobile = long.Parse(Console.ReadLine());
                                            Dentist.Update(den, DepName, DepId, DepDoctorName, DepDoctorEmail, DepDoctorMobile, DepDoctorQualification);
                                            break;


                                        case 2:
                                            Dentist.Display(den);
                                            break;



                                        case 3:

                                            Console.WriteLine("Enter your Email");
                                            DepDoctorEmail = Console.ReadLine();
                                            Dentist.Delete(den, DepDoctorEmail);
                                            break;
                                        case 4: return;


                                    }
                                    break;



                            }
                            break;
                    }

                }

            }

        }

       
    }
}
