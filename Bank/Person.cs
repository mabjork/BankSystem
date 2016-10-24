using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Person
    {
        private List<Account> accounts;
        private String name;
        private int runningNumber;
        public Person(String name)
        {
            this.name = name;
            accounts = new List<Account>();
            runningNumber = 1;
        }

        // Adds the specified account.
        public bool AddAccount(Account account)
        {
            if (HasAccount(account))
            {
                return false;
            }
            accounts.Add(account);
            account.SetName(name + runningNumber);
            runningNumber+=1;
            Console.WriteLine(runningNumber);
            return true;

        }
        // Removes the specified account.
        public bool RemoveAccount(Account account)
        {
            if (HasAccount(account))
            {
                accounts.Remove(account);
                return true;
            }
            return false;
        }

        // Checks if the account is allready registered for the user.
        public bool HasAccount(Account account)
        {
            return accounts.Contains(account);
        }
        // Return all accounts for the user as a list.
        public List<Account> GetAllAccounts()
        {
            return accounts;
        }
    }
}
