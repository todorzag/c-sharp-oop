using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Transaction
    {
        private string _note;
        private string _type;

        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Note 
        { 
            get => _note;
            init
            {
                ValidateNoteThrowException(value);
                _note = value;
            }
        }

        public Transaction(decimal amount, DateTime date, string type, string note)
        {
            Amount = amount;
            Date = date;
            _type = type;
            Note = note;
        }

        private void ValidateNoteThrowException(string note)
        {
            if (note == null || note == " ")
            {
                throw new ArgumentNullException
                    (nameof(note), "Note cannot be empty or null!");
            }
        }
    }
}
