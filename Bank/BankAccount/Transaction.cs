using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Transaction
    {
        private readonly static List<string> _allowedTypes
            = new List<string>
            {
                "deposit",
                "withdrawal"
            };

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
        public string Type 
        { 
            get => _type;
            init
            {
                ValidateTypeThrowException(value);
                _type = value;
            }
        }

        public Transaction(decimal amount, DateTime date, string type, string note)
        {
            Amount = amount;
            Date = date;
            Type = type;
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

        private void ValidateTypeThrowException(string type)
        {
            if (!_allowedTypes.Contains(type))
            {
                throw new InvalidOperationException
                    ("Invalid Transactiion Type!");
            }
        }
    }
}
