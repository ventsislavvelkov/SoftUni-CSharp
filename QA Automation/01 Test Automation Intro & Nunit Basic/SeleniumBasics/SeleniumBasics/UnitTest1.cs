using System;
using Homework;
using NUnit.Framework;

namespace SeleniumBasics
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BankAccountHaveCorrectAmount_When_Deposit()
        {
            var sut = new BankAccount(1000);
            sut.Deposit(200);

            var amount = sut.Amount;
            Assert.AreEqual(1200, sut.Amount);
        }

        [Test]
        public void ExceptionIsThrown_When_DepositWithNegativeValue()
        {
            var sut = new BankAccount(1000);
            

            var amount = sut.Amount;
            Assert.Throws<ArgumentException>(() => sut.Deposit(-1));
        }

        [Test]
        public void BankAccountHaveCorrectAmount_When_WithdrawLessThen1000()
        {
            var sut = new BankAccount(1500);
            sut.Withdraw(500);

            var amount = sut.Amount;
            Assert.AreEqual(975, sut.Amount);
        }

        [Test]
        public void BankAccountHaveCorrectAmount_When_WithdrawMoreThen1000()
        {
            var sut = new BankAccount(1500);
            sut.Withdraw(1000);

            var amount = sut.Amount;
            Assert.AreNotEqual(500, sut.Amount);
        }

        [Test]
        public void BankAccountHaveCorrectAmount_When_WithdrawMoreThen1000_2()
        {
            var sut = new BankAccount(1500);
            sut.Withdraw(1000);

            var amount = sut.Amount;
            Assert.AreEqual(480, sut.Amount);
        }
    }
}