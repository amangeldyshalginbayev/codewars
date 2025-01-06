using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Solutions;

public class Kata
{

    public static void Main(string[] args)
    {
        
    }
    /// <summary>
    /// https://www.codewars.com/kata/525f50e3b73515a6db000b83/train/csharp
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static string CreatePhoneNumber(int[] numbers)
    {
        var builder = new StringBuilder("(xxx) xxx-xxxx");
        var queue = new Queue<int>(numbers);

        for (var i = 0; i < builder.Length; i++)
        {
            if (builder[i] == 'x')
            {
                builder[i] = (char)(queue.Dequeue() + '0');
            }
        }
        return builder.ToString();
    }
    
    /// <summary>
    /// https://www.codewars.com/kata/5287e858c6b5a9678200083c/train/csharp
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool Narcissistic(int value)
    {
        var stringNumber = value.ToString();
        var power = stringNumber.Length;

        long sum = stringNumber.Select(number => (int)char.GetNumericValue(number)).Select(numericValue => (int)Math.Pow(numericValue, power)).Sum();

        return sum == value;
    }
    
    /// <summary>
    /// https://www.codewars.com/kata/54ff3102c1bad923760001f3/train/csharp
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static int GetVowelCount(string str)
    {
        var vowels = new[] { 'a', 'e', 'i', 'o', 'u' };

        return str.Count(t => vowels.Contains(t));
    }
    
    /// <summary>
    /// https://www.codewars.com/kata/551f37452ff852b7bd000139/train/csharp
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static string AddBinary(int a, int b)
    {
        var sum = a + b;
        return Convert.ToString(sum, 2);
    }
    
}