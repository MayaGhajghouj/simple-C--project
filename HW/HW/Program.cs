using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW
{
    class Program
    {
        public static string[] names = new string[50]; // main matrix
        public static string[] UniNumber = new string[50]; // main matrix
        public static int[] uniqe_numbers = new int[50];
        public static int index = 0; // index for uniqe_numbers matrix (number of all students)
        public static string factulity_Type(string Factulity)
        {
            if (Factulity == "Engineer")
            {
               return  "12";
            }
            else if (Factulity == "Human_Medicine")
            {
                return  "13";
            }
            else if (Factulity == "Literature")
            {
                return  "14";
            }
            else if (Factulity == "Sciense")
            {
                return  "15";
            }
            else
            {
                return " no Factulity in this name\n";
            }

        }
        public static string uniqNumber()
        {
            Random ran = new Random();
            int rr = ran.Next(1000, 9999);
            while(uniqe_numbers.Contains<int>(rr))
            {
                rr = ran.Next(1000, 9999);
            }
            uniqe_numbers[index] = rr;
            return rr.ToString();
        }
        public static void printStudentNumber()
        {
            // 23120000
            // UniNumber[i].Substring(0, 2);// get year from university number (23)
            // UniNumber[i].Substring(2, 2);//get factulity from university number (12)
            // UniNumber[i].Substring(0, 4);// get year with factulity (2312)
            int count = 0; // for student counter
            Console.WriteLine("\n enter year you want to search on it");
           string year = Console.ReadLine().Substring(2);
            Console.WriteLine("\n enter factulity you want to search on it");
            string factulity = Console.ReadLine();
            factulity = factulity_Type(factulity);
            string data = year + factulity; // merge year with factulity number (2312)
            for (int i =0;i<index;i++)
            {
                if (UniNumber[i].Substring(0, 4)==data)
                {
                    
                    count += 1;
                } 
            }
            Console.WriteLine("\n students number :  "+count+"\n\n");
           
        }
        public static void printMedicineInfo()
        {
            // UniNumber[i].Substring(0, 2);// get year from university number (23)
            // UniNumber[i].Substring(2, 2);//get factulity from university number (12)
            string[] MedicineNames = new string[50];
            string[] MedicineNumbers = new string[50];
            int MedIndex = 0;
            for(int i = 0;i< index;i++)
            {
                if(UniNumber[i].Substring(2, 2)=="13") // get all medicine info in two matrix
                {
                    MedicineNames[MedIndex] = names[i]; // medicine students name
                    MedicineNumbers[MedIndex]= UniNumber[i]; // medicine students numbers
                    MedIndex++;
                }
            }

            Console.WriteLine("\n enter year you want to show informations on it\t");
            string year = Console.ReadLine().Substring(2); //2022 => 22

            if (MedIndex == 0)
            {
                Console.WriteLine("\t no medicine students\n");

            }
            else
            {
                for (int i = 0; i < MedIndex; i++)
                {
                    if (MedicineNumbers[i].Substring(0, 2) == year)
                    {
                        Console.WriteLine("\nstudent : " + MedicineNames[i] + "  " + MedicineNumbers[i]);
                    }

                }
            }

        }
        public static void searchByName()
        {
            string factulity;
            string year;
            // UniNumber[i].Substring(0, 2);// get year from university number (23)
            // UniNumber[i].Substring(2, 2);//get factulity from university number (12)
            Console.Write(" enter student name\t");
            string name = Console.ReadLine();
            for(int i =0;i<index;i++)
            {
                year = "";
                factulity = "";
                if(name==names[i])
                {
                     year = UniNumber[i].Substring(0,2);//23120000 => 2023
                     year = "20" + year;
                     factulity = UniNumber[i].Substring(2, 2);
                    if (factulity == "12")
                    {
                        factulity = "Engineer";
                    }
                    else if (factulity == "13")
                    {
                        factulity = "human_Medicine";
                    }
                    else if (factulity == "14")
                    {
                        factulity = "Literature";
                    }
                    else if (factulity == "15")
                    {
                        factulity = "Science";
                    }
                Console.WriteLine("\n student :  " + name + " register in " + year + " in factulity " + factulity);
                }

            }
            

        }

            static void Main(string[] args)
        {

            for (int i = 0; i <3 ; i++)
            {
                string Factulity, year, number, UniversityNum;
                Console.Write(" Enter Student name\t");
                names[index] = Console.ReadLine();// we enter student name to main matrix
                Console.Write(" Enter Register year\t");
                year = Console.ReadLine().Substring(2); // 2024 =>24 
                Console.Write(" Enter Student Factulity\t");
                Factulity = Console.ReadLine();
                Factulity = factulity_Type(Factulity);// convert name of factulity to number
                number = uniqNumber(); // verify that random number is uniqe
                UniversityNum = year + Factulity + number;
                UniNumber[index] = UniversityNum;
                index++;
                Console.Write(" university number is \t");
                Console.Write(UniversityNum); // we enter uni_number to main matrix
                Console.WriteLine("\n");
            }// for 
            Console.WriteLine("\n\n choose the number for service you want ");
            Console.WriteLine("1) print number of students by year and factulity");
            Console.WriteLine("2) print students name and university numbers for medicine factulity by year");
            Console.WriteLine("3) search by name for student information\n");
            int choose = int.Parse(Console.ReadLine());
            switch(choose)
            {
                case 1:
                    printStudentNumber();
                    break;
                case 2:
                    printMedicineInfo();
                    break;
                case 3:
                    searchByName();
                    break;
                default: Console.WriteLine("no choice for this number ");
                    break;
            }









        }
    }
}
