using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Banking
{
    public class Bank : MonoBehaviour
    {
        [SerializeField] private List<Customer> _customers;
        private int _customerId = 0;

        private void Awake()
        {
            AddCustomer("Assets/Resources/customer.csv");
        }

        public void AddCustomer(string file)
        {
            string customerInformation = File.ReadLines(file).First();
            string[] infoFields = customerInformation.Split(';');
            _customers = new List<Customer>() {new Customer(_customerId, infoFields[0])};
            foreach (var line in File.ReadLines(file))
            {
                if (line == File.ReadLines(file).First()) continue;
                string[] accountInfo = line.Split(';');
                
                _customers.Last().AddAccount(accountInfo[0], accountInfo[1]);
            }
        }
    }
}