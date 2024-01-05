using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Converter.Services.CurrencyConverter;

namespace Converter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrencyConverterValuesController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult GetCurrencyText(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("The 'id' parameter cannot be null or empty.");
            }

            id = id.Replace(" ", "");

            if (id.Contains("."))
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please use comma." });
            }

            string[] partsOfInput = id.Split(',');

            if (partsOfInput[0].Length > 9)
            {
                return Ok(new { amount = id, currencyText = $"Please enter no more than 9 numbers for dollars." });
            }

            if (partsOfInput[0].StartsWith("00"))
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please do not start with more than one zero" });
            }

            if (partsOfInput.Length > 1 && partsOfInput[1].Length > 2)
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please use only two numbers after the comma." });
            }

            if (partsOfInput.Length > 1 && partsOfInput[0].Length == 0)
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please add dollars." });
            }

            if (partsOfInput.Length > 1 && partsOfInput[1].Length == 0)
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please add cents or remove comma." });
            }

            if (partsOfInput.Length > 1 && partsOfInput[1].Length == 1)
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please add zero to the end." });
            }

            int commaCount = id.Count(c => c == ',');
            if (commaCount > 1)
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please use comma only one time." });
            }

            Regex regex = new Regex(@"^(\d+,)*\d+$");

            if (!regex.IsMatch(id))
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please use only numbers and comma." });
            }

            if (id.Contains("?"))
            {
                return Ok(new { amount = id, currencyText = $"Incorrect currency format, please do not use the '?' character." });
            }

            var cc = new CurrencyConverter2();

            string dollars = cc.NumberToWords(Convert.ToInt32(partsOfInput[0]));
            string currencyText = $"{dollars} dollars";

            if (partsOfInput.Length > 1)
            {
                string cents = cc.ConvertCentsToWords(Convert.ToInt32(partsOfInput[1]));
                currencyText += $" and {cents} cents";
            }

            return Ok(new { amount = id, currencyText = currencyText });

        }
    }
}
