using Converter.Models;


// This code is not used as it contains some logic from stackoverflow

namespace Converter.Services.CurrencyConverter
{
    public class CurrencyConverter: ICurrencyConverter
    {
        public string NumberToWords(int number)
        {
            string words = "";

            if (number == 0)
                return "zero";

            Dictionary<int, string> unitsMap = new Dictionary<int, string>()
    {
        { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" },
        { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "ten" }, { 11, "eleven" },
        { 12, "twelve" }, { 13, "thirteen" }, { 14, "fourteen" }, { 15, "fifteen" }, { 16, "sixteen" },
        { 17, "seventeen" }, { 18, "eighteen" }, { 19, "nineteen" }
    };

            Dictionary<int, string> tensMap = new Dictionary<int, string>()
    {
        { 2, "twenty" }, { 3, "thirty" }, { 4, "forty" }, { 5, "fifty" },
        { 6, "sixty" }, { 7, "seventy" }, { 8, "eighty" }, { 9, "ninety" }
    };

            if (number >= 1000000)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if (number >= 1000)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if (number >= 100)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number >= 20)
            {
                words += tensMap[number / 10];
                number %= 10;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                words += unitsMap[number];
            }

            return words.Trim();
        }
        public string ConvertCentsToWords(int number)
        {
            if (number == 0)
                return "zero";

            string words = "";

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new Dictionary<int, string>
        {
            {0, "zero"}, {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"}, {5, "five"},
            {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"}, {10, "ten"},
            {11, "eleven"}, {12, "twelve"}, {13, "thirteen"}, {14, "fourteen"},
            {15, "fifteen"}, {16, "sixteen"}, {17, "seventeen"}, {18, "eighteen"}, {19, "nineteen"}
        };

                var tensMap = new Dictionary<int, string>
        {
            {0, "zero"}, {1, "ten"}, {2, "twenty"}, {3, "thirty"}, {4, "forty"},
            {5, "fifty"}, {6, "sixty"}, {7, "seventy"}, {8, "eighty"}, {9, "ninety"}
        };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

    }
}
