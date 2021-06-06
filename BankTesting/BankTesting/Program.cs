//using BankTesting;
using NUnitEg;
using System;

namespace UnitTest

{
    public class Program
    {
        public static void Main(string[] args)
        {
            Banking obj = new Banking();
            obj.DepositAmt(-87);
            Console.WriteLine("Balance:" + obj.balance);
            obj.DepositAmt(5000);
            Console.WriteLine("Balance:" + obj.balance);

        }
    }
}