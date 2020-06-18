using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm1 = new ATM(1);
            ATM atm2 = new ATM(2);

            int personsATM1 = 0;
            int personsATM2 = 0;

            Console.WriteLine("*****BANK ATMs*****\n");
            Console.WriteLine("How much persons will withdraw money from ATM 1:");
            string input = Console.ReadLine();
            bool success1 = int.TryParse(input, out personsATM1);
            while (!success1 || personsATM1 <= 0)
            {
                Console.WriteLine("You didn't entered positive number. Try again:");
                input = Console.ReadLine();
                success1 = int.TryParse(input, out personsATM1);
            }
            Console.WriteLine("\nHow much persons will withdraw money from ATM 2:");
            string input2 = Console.ReadLine();
            bool success2 = int.TryParse(input2, out personsATM2);
            while (!success2 || personsATM2 <= 0)
            {
                Console.WriteLine("You didn't entered positive number. Try again:");
                input2 = Console.ReadLine();
                success2 = int.TryParse(input2, out personsATM2);
            }
        }
    }
}
