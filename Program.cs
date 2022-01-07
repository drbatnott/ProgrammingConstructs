using System;
using System.IO;

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
        public static void EnterData()
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

                if (bmi > 25)
                {
                    Console.WriteLine("You are too heavy");
                }

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
        public static void WriteData()
        {
            string inputLine;
            TextReader textReader = new StreamReader("OurData.csv");
            while ((inputLine = textReader.ReadLine()) != null)
            {
                Console.WriteLine(inputLine);
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
            
            Console.Write("Do you want to print data or add new? enter 1 to add new and 0 to print" +
                " or 3 to view data and then add new.");
            int choice = Int16.Parse(Console.ReadLine());
            switch (choice)
            {
                case 0:
                    WriteData();
                    break;
                case 1:
                    EnterData();
                    break;
                case 3:
                    WriteData();
                    EnterData();
                    break;
                default:
                    Console.WriteLine("Not a valid choice");
                    
                    break;
                
            }
            Console.ReadLine();
            

        }
    }
}
