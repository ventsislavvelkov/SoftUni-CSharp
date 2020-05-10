using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount = new BankAccount(1000);
            bankAccount.Deposit(200);

            var amount = bankAccount.Amount;
        }
    }
}
