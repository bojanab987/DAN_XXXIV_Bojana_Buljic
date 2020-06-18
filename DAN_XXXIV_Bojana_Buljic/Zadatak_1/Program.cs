using System;
using System.Threading;

namespace Zadatak_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm1 = new ATM(1);
            ATM atm2 = new ATM(2);

            //user inputs of number of persons in an ATM row
            int personsATM1 = 0;
            int personsATM2 = 0;

            Console.WriteLine("*****BANK ATMs*****\n");
            Console.WriteLine("How much persons will withdraw money from ATM 1:");
            bool success1 = int.TryParse(Console.ReadLine(), out personsATM1);
            //validating if input is correct number for ATM1
            while (!success1 || personsATM1 < 0)
            {
                Console.WriteLine("You didn't entered a number. Try again:");            
                success1 = int.TryParse(Console.ReadLine(), out personsATM1);
            }
            
            Console.WriteLine("\nHow much persons will withdraw money from ATM 2:");            
            bool success2 = int.TryParse(Console.ReadLine(), out personsATM2);
            //validating if input is correct number for ATM1
            while (!success2 || personsATM2 <= 0)
            {
                Console.WriteLine("You didn't entered a number. Try again:");
                success2 = int.TryParse(Console.ReadLine(), out personsATM2);
            }

            //the sum of all persons who want to withdraw money. Variable represents the lenght of Thread array and number
            //of threads
            int totalPersons = personsATM1 + personsATM2;
            Thread[] threads = new Thread[totalPersons];

            //loop for creating threads
            for (int i = 0; i < totalPersons; i++)
            {
                //creating threads for all client in front of ATM 1
                if (i < personsATM1)
                {
                    Thread threadATM1 = new Thread(new ThreadStart(atm1.Withdraw));
                    threads[i] = threadATM1;
                }
                else
                {
                    //creating threads for all client in front of ATM 2
                    Thread threadATM2 = new Thread(new ThreadStart(atm2.Withdraw));
                    threads[i] = threadATM2;
                }
            }

            //Starting of all threads
            foreach (var i in threads)
            {
                i.Start();               
            }
            
            Console.ReadLine();
        }
    }
}
