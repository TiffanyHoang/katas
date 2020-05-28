using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class AppRunner
    {
        private static int _result { get; set; }
        private static IEnumerable<int> _numbers { get; set; }
       
        private readonly char[] _defaultDelimiter = {',', '\n'};

        public int Add(string value)
        {
            if (IsEmptyString(value))
            {
                return 0;
            }
            
            string[] _stringNumbers = RemoveDefaultDelimiters(value);
            _numbers = ConvertToInt(_stringNumbers);

            if (ContainNegativeNumbers())
            {
                ThrowException();
            }
            else if (ContainNumbersOverOneThousand())
            {
                ReturnNumbersUnderOneThousand();
            }
            else if (HasCustomDelimiter(value))
            {
                if (value.Contains("["))
                {
                    var firstIndex = 2; 
                    var lastIndex = value.LastIndexOf("]");
                    var delimiterSubstring = value.Substring(firstIndex + 1 , lastIndex - firstIndex - 1);
                    var delimiter = delimiterSubstring.Split("][");
                    var splitStringNumbers = value.Split("\n");
                    var valuesToSum = splitStringNumbers[1];
                    _stringNumbers = valuesToSum.Split(delimiter, StringSplitOptions.None); 
                    _numbers = ConvertToInt(_stringNumbers);
                    
                    //still need to complete the edge case delimiter [&&7] 
                }
                else
                {
                    var firstIndex = 2;
                    var lastIndex = value.LastIndexOf("\n");
                    var delimiter = value.Substring(firstIndex , lastIndex - firstIndex);
                    var splitStringNumbers = value.Split("\n");
                    var valuesToSum = splitStringNumbers[1];
                    _stringNumbers = valuesToSum.Split(delimiter);
                    _numbers = ConvertToInt(_stringNumbers);
                }
            }
            return SumOfNumbers();
        }

        private static int SumOfNumbers()
        {
            _result = _numbers.Sum();
            return _result;
        }

        private static bool IsEmptyString(string value)
        {
            return value == " ";
        }
        
        private string[] RemoveDefaultDelimiters(string value)
        {
            var _stringNumbers = value.Split(_defaultDelimiter);
            return _stringNumbers;
        }
        
        private static IEnumerable<int> ConvertToInt(string[] _stringNumbers)
        {
            var intNumbers = _stringNumbers.Select(s => new {Success = int.TryParse(s, out var value), value})
                .Where(pair => pair.Success)
                .Select(pair => pair.value);
            return intNumbers;
        }
        
        private static bool ContainNegativeNumbers()
        {
            return _numbers.Any(numbers => numbers < 0 );
        }
        
        private static void ThrowException()
        {
            var negativeNumbers = _numbers.Where(number => number < 0);
            throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negativeNumbers)}");
        }
        
        private static bool ContainNumbersOverOneThousand()
        {
            return _numbers.Any(number => number >= 1000);
        }
        
        private static IEnumerable<int> ReturnNumbersUnderOneThousand()
        {
            _numbers = _numbers.Where(number => number < 1000);
            return _numbers;
        }
        
        private static bool HasCustomDelimiter(string value)
        {
            return value.StartsWith("//");
        }
    }
}