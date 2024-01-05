using Converter.Models;

namespace Converter.Services.CurrencyConverter
{
    public class CurrencyConverter2: ICurrencyConverter
    {
        public string NumberToWords(int number)
        {
            var map = new Dictionary<int, string>
        {
            { 0, "zero" }, { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" },
            { 5, "five" }, { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" },
            { 10, "ten" }, { 11, "eleven" }, { 12, "twelve" }, { 13, "thirteen" },
            { 14, "fourteen" }, { 15, "fifteen" }, { 16, "sixteen" }, { 17, "seventeen" },
            { 18, "eighteen" }, { 19, "nineteen" }, { 20, "twenty" }, { 30, "thirty" },
            { 40, "forty" }, { 50, "fifty" }, { 60, "sixty" }, { 70, "seventy" },
            { 80, "eighty" }, { 90, "ninety" }, { 100, "hundred" }, { 1000, "thousand" }, { 1000000, "million" }
        };

            if (number == 0)
            {
                return map[number];
            }
            else if (number <= 20)
            {
                return map[number];
            }
            else if (number < 100)
            {
                return map[number - number % 10] + (number % 10 != 0 ? " " + map[number % 10] : "");
            }
            else if (number < 1000)
            {
                return map[number / 100] + " " + map[100] + (number % 100 != 0 ? " and " + NumberToWords(number % 100) : "");
            }
            else if (number < 1000000)
            {
                return NumberToWords(number / 1000) + " " + map[1000] + (number % 1000 != 0 ? " " + NumberToWords(number % 1000) : "");
            }
            else
            {
                return NumberToWords(number / 1000000) + " " + map[1000000] + (number % 1000000 != 0 ? " " + NumberToWords(number % 1000000) : "");
            }
        }
        public string ConvertCentsToWords(int number)
        {
            var map = new Dictionary<int, string>
        {
            { 0, "zero" }, { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" },
            { 5, "five" }, { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" },
            { 10, "ten" }, { 11, "eleven" }, { 12, "twelve" }, { 13, "thirteen" },
            { 14, "fourteen" }, { 15, "fifteen" }, { 16, "sixteen" }, { 17, "seventeen" },
            { 18, "eighteen" }, { 19, "nineteen" }, { 20, "twenty" }, { 30, "thirty" },
            { 40, "forty" }, { 50, "fifty" }, { 60, "sixty" }, { 70, "seventy" },
            { 80, "eighty" }, { 90, "ninety" }
        };

            if (number == 0)
            {
                return map[number];
            }
            else if (number <= 20)
            {
                return map[number];
            }
            else if (number < 100)
            {
                return map[number - number % 10] + (number % 10 != 0 ? " " + map[number % 10] : "");
            }
            else
            {
                return "Number is out of range. Please enter a number between 0 and 99.";
            }
        }

    }
}
