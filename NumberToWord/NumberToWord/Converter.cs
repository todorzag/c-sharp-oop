using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWord
{
    public class Converter
    {
        private static Converter _instance = null;
        private static Dictionary<int, string> SpecialNamed =
            new Dictionary<int, string>
            {
                {0, "Zero"},
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"},
            };
        private static Dictionary<int, string> Dozens =
            new Dictionary<int, string>
            {
                {2, "Twenty"},
                {3, "Thirty"},
                {4, "Fourty"},
                {5, "Fifty"},
                {6, "Sixty"},
                {7, "Seventy"},
                {8, "Eighty"},
                {9, "Ninety"},
            };
        public static Converter GetInstance
        {
            get
            {
                if (_instance == null)
                    _instance = new Converter();

                return _instance;
            }
        }
        private int[] _digits;

        private Converter()
        {
        }

        public string ConvertToWord(int number)
        {
            string word = default;
            _digits = GetDigits(number).ToArray();

            if (number < 100)
            {
                return GetTwoDigitWord(number);
            }
            else if (number < 1000)
            {
                return GetThreeDigitWord(number);
            }

            return word;
        }

        private string GetTwoDigitWord(int number)
        {
            if (number < 20)
            {
                return SpecialNamed[number];
            }
            else
            {
                return _digits[0] == 0
                    ? Dozens[_digits[1]]
                    : $"{Dozens[_digits[1]]} {SpecialNamed[_digits[0]]}";
            }
        }

        private string GetThreeDigitWord(int number)
        {
            string word = $"{SpecialNamed[_digits[2]]} Hundred";

            if (_digits[1] == 0 && _digits[0] == 0)
            {
                return word;
            }
            else
            {
                int lastTwoDigitsNumber = number - (_digits[2] * 100);

                return word += $" And {GetTwoDigitWord(lastTwoDigitsNumber)}";
            }
        }

        private IEnumerable<int> GetDigits(int number)
        {
            while(number > 0)
            {
                int digit = number % 10;
                number /= 10;
                yield return digit;
            }
        }
    }
}
