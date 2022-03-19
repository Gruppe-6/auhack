using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Banking
{
    public class Customer
    {
        private List<Account> _accounts;
        private int _id;
        private string _name;
        private AccountReaderCSV accountReaderCsv;

        public Customer(int id, string name)
        {
            _id = id;
            _name = name;
            accountReaderCsv = new AccountReaderCSV();
        }

        public void AddAccount(string name, string file)
        {
            _accounts.Add(new Account(name));
            accountReaderCsv.ReadData(file, _accounts.Last());
        }

    }
}


