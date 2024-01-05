namespace Converter.Models
{
    public interface ICurrencyConverter
    {
        string NumberToWords(int number);
        string ConvertCentsToWords(int number);
    }
}
