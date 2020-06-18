using System;

namespace Zadatak_1
{
    /// <summary>
    /// Class ATM responsible for creating ATM objects and performing Withdrawal of money
    /// </summary>
    public class ATM
    {
        //object wich will lock the code in method
        private object thisLock = new object();
        //The amount of money in the bank on the start of aplication
        public static int availableMoney = 10000;
        public static int atmId;
        //field presents the number of customer that is in row for withdrawing money.
        public static int customerNo = 0;
        static Random rnd = new Random();

        /// <summary>
        /// ATM constructior passing it id number for ATM
        /// </summary>
        /// <param name="id"></param>
        public ATM(int id)
        {
            atmId = id;
        }

        /// <summary>
        /// Method for money withdrowal from ATM
        /// </summary>
        /// <param name="amount">Integer paramater representing the amount for withdrawal from ATM</param>
        public void Withdraw(int amount)
        {
            //locks the code preventing for another thread to perform the method at the same time
            //one client at a time can withdraw money from ATM
            lock (thisLock)
            {
                amount = rnd.Next(100, 10000);
                Console.WriteLine("Customer {0} trying to withdraw {1} RSD from ATM {2}", ++customerNo, amount, atmId);
                if (availableMoney >= amount)
                {
                    availableMoney -= amount;
                    Console.WriteLine("Customer {0} withdrew {1} RSD from ATM {2}", customerNo, amount, atmId);
                    Console.WriteLine("Available money left in bank: {0}", availableMoney);
                }
                else
                {
                    if (availableMoney <= 0)
                    {
                        Console.WriteLine("No available amount of {0} in ATM", amount);
                    }
                }
            }
        }
    }
}
