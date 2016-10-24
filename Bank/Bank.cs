using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Bank
    {
        List<Person> customers;

        public Bank()
        {
            customers = new List<Person>();
        }
        // Adds new customer if not allready registered.
        public bool AddNewCustomer(Person person)
        {
            if (isCustomer(person))
            {
                return false;
            }
            customers.Add(person);
            return true;
        }

        // Removes customer if registered.
        public bool RemoveCustomer(Person customer)
        {
            if (isCustomer(customer))
            {
                customers.Remove(customer);
                return true;
            }
            return false;
        }

        // Checks if the Person is a customer.
        public bool isCustomer(Person person)
        {
            return customers.Contains(person);
        }

        // Creates a regular account for a customer.
        public void CreateRegularAccountForCustomer(Person customer, Money amount)
        {
            customer.AddAccount(new RegularAccount(customer, amount));
        }

        // Returns all the accounts for a specified customer if registered.
        public List<Account> GetAccountsForCustomer(Person customer)
        {
            if (isCustomer(customer))
            {
                return customer.GetAllAccounts();
            }
            return null;
        }

        // Transfers the amount from an account to another, if the
        // amount is valid.
        public bool Transfer(Account from, Account to, Money amount)
        {
            
            bool sucsess = Withdraw(from, amount);
            if (sucsess)
            {
                Deposit(to, amount);
                return true;
            }
            return false;
        }

        // Withdraws the amount from an account if the amount is valid.
        public bool Withdraw(Account from, Money amount)
        {
            try
            {
                from.makeWithdraw(amount);
                return true;
            }
            catch (InvalidOperationException e) {
                return false;
            }
            

        }
        // Deposits the amount in to an account if the amount is valid.
        public bool Deposit(Account to, Money amount)
        {
            try
            {
                to.makeDeposit(amount);
                return true;
            }
            catch (InvalidOperationException e)
            {
                return false;
            }
        }
    }
}
