using System;
using System.IO;
//the following library allows you to use Lists of complex data types
using System.Collections.Generic;

namespace ProgrammingConstructs
{
    internal class Program
    {
        /// <summary>
        /// Function to enter data for our non structured (or semi structured)
        /// database kept in the file "OurData.csv"
        /// It will loop until the user says no to the question whether there is
        /// more data to enter
        /// It will calculate the BMI based on data entry and try to say if the person
        /// is over weight
        /// </summary>
        public static void EnterData(List<string> l)
        {
            TextWriter textWriter = new StreamWriter("OurData.csv", true);
            Console.WriteLine("Hello Please Enter Your Data");
            string yn = "yes";
            int age;
            float weight;
            while (yn.Contains("y") || yn.Contains("Y"))
            {
                Console.Write("Enter your name: ");
                string name = Console.ReadLine();
                //25 is a piece of data that is well within the true for being eligible
                //16 is the lower limit of being eligible
                //12 is too young
                Console.Write("Enter your age: ");
                age = short.Parse(Console.ReadLine());
                Console.Write("Enter your weight in kg: ");
                weight = (float)double.Parse(Console.ReadLine());
                Console.Write("Enter your height in cm: ");
                float heightInCm = (float)Double.Parse(Console.ReadLine());
                // the / means division
                float heightInMetres = heightInCm / 100;
                //the * means multiplication
                float bmi = weight / (heightInMetres * heightInMetres);
                //We can also use the Math library and the Pow function raises a number to a power
                //float heightSquared = (float) Math.Pow(heightInMetres, 2);
                string message = "Name," + name +
                    ",Age," + age
                    + ",Height in metres," + heightInMetres
                    + ",BMI," + bmi;/**/
                //I have refactored the code to be able to reuse the same message
                //in two places
                Console.WriteLine(message);
                textWriter.WriteLine(message);
                l.Add(message);
                if (bmi > 25)
                {
                    Console.WriteLine("You are too heavy");
                }
                // == is if things are equal
                // != asks are they not equal
                if(bmi == 25)
                {
                    Console.WriteLine("BMI is 25");
                }
                else
                {
                    Console.WriteLine("BMI is not 25");
                }
                bool t = true;
                bool f = !t;
                Console.WriteLine(f); // this will write false

                Console.Write("More data? Enter yes or no");
                yn = Console.ReadLine();
            }
            //You must always close a file to finish writing it
            textWriter.Close();
            //Console.ReadLine();
        }
        /// <summary>
        /// This will loop through the unstructured data in OurData.csv and
        /// print out each line in the file
        /// </summary>
        public static void WriteData(List<string> l)
        {
            string inputLine;
            TextReader textReader = new StreamReader("OurData.csv");
            while ((inputLine = textReader.ReadLine()) != null)
            {
                Console.WriteLine(inputLine);
                l.Add(inputLine);
            }
            textReader.Close();
            Console.ReadLine();
        }
        /// <summary>
        /// Will allow choice of viewing current data and entering new data 
        /// to our semi structured (non structured) datbase
        /// </summary>
        /// <param name="args">Not used for this program</param>
        static void Main(string[] args)
        {
            //A new selection type called a switch case
            List<string> list = new List<string>();
            Console.Write("Do you want to print data or add new? enter 1 to add new and 0 to print" +
                " or 3 to view data and then add new.");
            int choice = Int16.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    WriteData(list);
                    break;
                case 1:
                    EnterData(list);
                    break;
                case 3:
                    WriteData(list);
                    EnterData(list);
                    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    
                    break;
                
            }
            //the next thing we will use if a foreach loop 
            //it is a different sort of iterator
            Console.WriteLine("The data is now");
            foreach(string s in list)
            {
                Console.WriteLine(s);
            }
            //the following loop is one normally used when we know the amount of 
            //data we are going to loop through.
            //for list the best way to loop through this is the foreach loop
            //but we could use the for loop in this case because we know how long
            //list is at this point
            int count = list.Count;
            //for i = 0 while i < count do what is in the {} then do the final
            // thing which is i++ ++ adds one to the value of i
            for(int i = 0; i < count; i++)
            {
                //in most programming languages arrays start at 0
                //so the last element in the array is count-1
                //so we stop once i is no longer less than count
                //i +=2 will add 2 to i
                // i *= 2; will replace i by 2*i
                Console.WriteLine(list[i]);
            }
            Console.ReadLine();
            

        }
    }
}
