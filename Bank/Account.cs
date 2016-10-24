using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class Account
    {
        
        private int withdraws;
        private readonly Person owner;
        private Money balance;
        private String name;

        public Account(Person owner, Money amount)
        {
            this.balance = amount;
            this.owner = owner;
        }
        // Sets the name for the account.
        public void SetName(String name) {
            this.name = name;
        }
        public String GetName() {
            return name;
        }
        // Checks if its a valid amount, then makes the deposit.
        public void makeDeposit(Money amount)
        {
            if (!ValidAmount(amount.Amount))
            {
                throw new InvalidOperationException("Not a valid amount");
                
            }
            balance.Amount += amount.Amount;
            
        }
        // Checks if its a valid amount and not greater than the balance,
        // then makes the withdraw.
        public void makeWithdraw(Money amount)
        {
            if (!ValidAmount(amount.Amount))
            {
                throw new InvalidOperationException("Not a valid amount");
            }
            if (amount.Amount > balance.Amount)
            {
                throw new InvalidOperationException("Tried to withdraw to much");
            }
            balance.Amount -= amount.Amount;
            
        }
        // Checks if amount is negative.
        private bool ValidAmount(double amount)
        {
            return amount >= 0;
        }

        public Money getBalance()
        {
            return balance;
        }

    }
}
