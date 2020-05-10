using System;
using SeleniumBasicDemo;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount = new SeleniumBasicDemo.BankAccount(1000);
            bankAccount.Deposit(200);

            var amount = bankAccount.Amount;
        }
    }
}
