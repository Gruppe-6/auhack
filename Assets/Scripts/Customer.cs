using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class Customer
    {
        public List<Account> _accounts;
        private int _id;
        private string _name;
        private AccountReaderCSV accountReaderCsv;

        public Customer(int id, string name)
        {
            _id = id;
            _name = name;
            accountReaderCsv = new AccountReaderCSV();
            _accounts = new List<Account>();
        }

        public void AddAccount(string name, string file)
        {
            _accounts.Add(new Account(name));
            accountReaderCsv.ReadData(file, _accounts.Last());
        }

    }
}


