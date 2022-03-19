using System;
using System.IO;

namespace Banking
{
    public class AccountReaderCSV : IAccountReader
    {
        public AccountReaderCSV()
        {
            
        }
    
        public void ReadData(string file, Account account)
        {
            
            foreach (string line in File.ReadLines(file))
            {
                string[] temp = line.Split(';');
                account.NewTransaction(DateTime.Parse(temp[0]), temp[1],decimal.Parse(temp[2]));
            }
        }
        
    }    
}

