using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Banking
{
    public class Bank
    {

        private List<Customer> _customers;
        private int _customerId = 0;

        public Bank(string file)
        {
            AddCustomer(file);
        }

        public void AddCustomer(string file)
        {
            string customerInformation = File.ReadLines(file).First();
            string[] infoFields = customerInformation.Split(';');
            _customers = new List<Customer>() {new Customer(_customerId, infoFields[0])};
            
            foreach (var line in File.ReadLines(file))
            {
                if (line == File.ReadLines(file).First()) break;
                string[] accountInfo = line.Split(';');
                
                _customers.Last().AddAccount(infoFields[0], infoFields[1]);
            }
        }
    }
}