using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Tests
{
    [TestClass()]
    public class BankTests
    {
        Bank controller = new Bank();
        Person person1 = new Person("Marius");
        Person person2 = new Person("Per");
        Money startAmount = new Money();
        Money transferAmount = new Money();
        Money falseAmount = new Money();
        Money toBigAmount = new Money();

        
        // Tests if a user can be added, and if it can be added if it
        // is already registered.
        [TestMethod()]
        public void AddNewCustomerTest()
        {
            Assert.AreEqual(true ,controller.AddNewCustomer(person1));
            Assert.AreEqual(false, controller.AddNewCustomer(person1));
            Assert.AreEqual(true, controller.AddNewCustomer(person2));
        }

        // Test for removing customer and removing customer again.
        [TestMethod()]
        public void RemoveCustomerTest()
        {
            Assert.AreEqual(true, controller.AddNewCustomer(person1));
            Assert.AreEqual(true, controller.RemoveCustomer(person1));
            Assert.AreEqual(false, controller.RemoveCustomer(person1));
        }

        // Test for seeing if a person is a customer.
        [TestMethod()]
        public void isCustomerTest()
        {
            Assert.AreEqual(true, controller.AddNewCustomer(person2));
            Assert.AreEqual(true, controller.isCustomer(person2));
        }

        // Test for getting all accounts for a customer.
        [TestMethod()]
        public void GetAccountsForCustomerTest()
        {
            startAmount.Amount = 1000;
            controller.AddNewCustomer(person2);
            controller.CreateRegularAccountForCustomer(person2, startAmount);
            Assert.AreEqual(1, controller.GetAccountsForCustomer(person2).Count);
            
        }

        // Test for different scenarios for transfering money.
        [TestMethod()]
        public void TransferTest()
        {
            startAmount.Amount = 1000;
            falseAmount.Amount = -100;
            transferAmount.Amount = 100;
            toBigAmount.Amount = 1100;

            controller.AddNewCustomer(person1);
            controller.AddNewCustomer(person2);
            controller.CreateRegularAccountForCustomer(person1, startAmount);
            controller.CreateRegularAccountForCustomer(person2, startAmount);
            Account from = controller.GetAccountsForCustomer(person1).ElementAt(0);
            Account to = controller.GetAccountsForCustomer(person2).ElementAt(0);
            
            // Test with a negative amount.
            Assert.AreEqual(false, controller.Transfer(from, to, falseAmount));

            // Test with a too big amount.
            Assert.AreEqual(false, controller.Transfer(from, to, toBigAmount));

            // Test with a valid amount.
            Assert.AreEqual(true, controller.Transfer(from, to, transferAmount));
        }

        [TestMethod()]
        public void WithdrawTest()
        {
            startAmount.Amount = 1000;
            falseAmount.Amount = -100;
            transferAmount.Amount = 100;
            toBigAmount.Amount = 1100;
            controller.AddNewCustomer(person1);
            
            controller.CreateRegularAccountForCustomer(person1, startAmount);
            Account from = controller.GetAccountsForCustomer(person1).ElementAt(0);

            // Test with negative amount.
            Assert.AreEqual(false, controller.Withdraw(from, falseAmount));

            // Test with too big amount.
            Assert.AreEqual(false, controller.Withdraw(from, toBigAmount));

            // Test with valid amount.
            Assert.AreEqual(true, controller.Withdraw(from, transferAmount));

            // Test to see if balance is correct.
            Assert.AreEqual(900, from.getBalance().Amount);
        }

        [TestMethod()]
        public void DepositTest()
        {
            startAmount.Amount = 1000;
            falseAmount.Amount = -100;
            transferAmount.Amount = 100;
            toBigAmount.Amount = 1100;
            
            controller.AddNewCustomer(person2);            
            controller.CreateRegularAccountForCustomer(person2, startAmount);            
            Account to = controller.GetAccountsForCustomer(person2).ElementAt(0);

            // Test for negative amount.
            Assert.AreEqual(false, controller.Deposit(to, falseAmount));

            // Test for valid amount.
            Assert.AreEqual(true, controller.Deposit(to, transferAmount));

            // Test to see if balance is correct.
            Assert.AreEqual(1100, to.getBalance().Amount);

        }
        [TestMethod]
        public void RunningNumberTest()
        {

            startAmount.Amount = 1000;
            Assert.AreEqual(true, controller.AddNewCustomer(person1));
            Assert.AreEqual(true, controller.AddNewCustomer(person2));

            // Test to see if the runningnumber is correct for the first account.
            controller.CreateRegularAccountForCustomer(person1, startAmount);
            Account account1 = controller.GetAccountsForCustomer(person1).ElementAt(0);
            Assert.AreEqual("Marius1", account1.GetName());

            // Test to see if the runningnumber is correct for the second account.
            controller.CreateRegularAccountForCustomer(person1, startAmount);
            Account account2 = controller.GetAccountsForCustomer(person1).ElementAt(1);
            Assert.AreEqual("Marius2", account2.GetName());

            // Test to see if the runningnumber is correct for another person.
            controller.CreateRegularAccountForCustomer(person2, startAmount);
            Account account3 = controller.GetAccountsForCustomer(person2).ElementAt(0);
            Assert.AreEqual("Per1", account3.GetName());

        }

    }
}