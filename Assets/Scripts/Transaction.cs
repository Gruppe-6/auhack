using System;

namespace Banking
{
    public class Transaction
    {
        public decimal _price;

        private string _category;

        private DateTime _dateTime;

        public Transaction(DateTime dateTime, string category, decimal price )
        {
            _dateTime = dateTime;
            _category = category; 
            _price = price;
        }

        public override string ToString()
        {
            return string.Format($"{_dateTime} - {_category}    {_price} DKK");
        }
    }
}


