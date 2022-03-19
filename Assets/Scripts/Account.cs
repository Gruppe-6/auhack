
using System;
using System.Collections.Generic;

namespace Banking
{
    public class Account
    {  
        public decimal Balance {get; private set;}
        public List<Transaction> Transactions = new List<Transaction>();
        public string AccountName;

        public Account(string accountName)
        {
            AccountName = accountName;
        }
        
        public void GetTransactions(decimal balance, List<Transaction> transactions)
        {
            foreach (Transaction transaction in Transactions)
            {
                transaction.ToString();
            }
        }

        public void NewTransaction(DateTime dateTime, string category, decimal amount)
        {
            Transactions.Add(new Transaction(dateTime, category, amount));
        }
    } 
}



