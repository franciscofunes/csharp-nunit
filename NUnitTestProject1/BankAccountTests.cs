using Bank;
using System;
using NUnit.Framework;

namespace BankUnitTests
{
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            //ARRANGE
            account = new BankAccount(1000);
        }

        [Test]
        public void Adding_Funds_Updates_Balance()
        {

            // ACT
            account.Add(500);

            // ASSERT
            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void Adding_Negative_Funds_Throws()
        {

            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-500));
        }

        [Test]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // ACT
            account.Withdraw(500);

            // ASSERT
            Assert.AreEqual(500, account.Balance);
        }

        [Test]
        public void Withdrawing_Negative_Funds_Throws()
        {
            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-500));
        }

        [Test]
        public void Withdrawing_More_Than_Balance_Throws()
        {
            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Test]
        public void Transfering_Funds_Updates_Both_Accounts()
        {
            // ARRANGE
            var account_2 = new BankAccount();
            
            // ACT
            account.TransferFundsTo(account_2, 500);

            // ASSERT
            Assert.AreEqual(500, account.Balance);
            Assert.AreEqual(500, account_2.Balance);
        }

        [Test]
        public void Transfer_To_Non_Existing_Account()
        {
            // ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}