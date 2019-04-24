using System.Linq;
using System.Text;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace kataTry
{
    internal class StringCalculator
    {
        internal int add(string number)
        {
            if(String.IsNullOrEmpty(number)){
                return 0;
            }

            var args = GetArrayInt(number);
            ValidateNegativeNumbers(args);

            return args.Sum(i => i );
        }
        public static void ValidateNegativeNumbers(IEnumerable<int> args)
        {
            var negativeNumbers = args.Where(i => i < 0).ToList();

            if (negativeNumbers.Any())
            {
                throw new ArgumentException("negative numbers not allowed: " + String.Join(",", negativeNumbers));
            }

        }
        private static List<int> GetArrayInt(string numbers)
        {
            numbers = ReplaceNonDelimWithCommas(numbers);

            return numbers.Split(',').Select(int.Parse).ToList();
        }

        private static string ReplaceNonDelimWithCommas(string numbers)
        {
            numbers = ReplaceUserSpecDelimWithComma(numbers);
             numbers = numbers.Replace("\n", ",");
            return numbers;
        }

        private static string ReplaceUserSpecDelimWithComma(string numbers)
        {
            const string delimPattern = "^//(.)\n";
            var regex = new Regex(delimPattern);
            var match = regex.Match(numbers);
            if (match.Success)
            {
                var delimiter = match.Groups[1].Value;
                numbers = regex.Replace(numbers, "");
                numbers = numbers.Replace(delimiter, ",");
            }

            return numbers;
        }
    }
}
