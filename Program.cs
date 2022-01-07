using System;
using System.IO;

namespace ProgrammingConstructs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter("OurData.csv");
            Console.WriteLine("Hello");
            string name = "Peter";
            //25 is a piece of data that is well within the true for being eligible
            //16 is the lower limit of being eligible
            //12 is too young
            int age = 25;
            float weight = 69;
            float heightInCm = 160;
            // the / means division
            float heightInMetres = heightInCm / 100;
            //the * means multiplication
            float bmi = weight / (heightInMetres * heightInMetres);
            //We can also use the Math library and the Pow function raises a number to a power
            float heightSquared = (float) Math.Pow(heightInMetres, 2);
            string message = "Name," + name +
                "\nAge," + age
                +"\nHeight in metres,"+heightInMetres
                +"\nBMI," + bmi;/**/
            //I have refactored the code to be able to reuse the same message
            //in two places
            Console.WriteLine(message);
            textWriter.WriteLine(message);
           // Console.WriteLine(heightInMetres);
            //Console.WriteLine("Bmi is " + bmi);
            Console.WriteLine(heightSquared);
            /*
             * < means less than > greater than
             * || means logical or which means if either condition is true
             * the result is true
             * if is a selection code which means "Do the following IF 
             * the thing in the brackets is true
             * IF not true then the line after the else will be done
             */
            if (age < 16 || age > 126)
            {
                Console.WriteLine("You are outside the eligible range for this class");
            }
            else
            {
                Console.WriteLine("You are old enough to be in the class");
            }
            /*
             * if the weight is >= Greater than or equal to
             * 69 AND the height is less than or equal to
             * 160 you are too heavy
             * */
            if(bmi > 25)
            {
                Console.WriteLine("You are too heavy");
            }
            textWriter.Close();
            Console.ReadLine();
            //You must always close a file to finish writing it
            
        }
    }
}
