using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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

        long sum = stringNumber.Select(number => (int)char.GetNumericValue(number))
            .Select(numericValue => (int)Math.Pow(numericValue, power)).Sum();

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

    /// <summary>
    /// https://www.codewars.com/kata/517abf86da9663f1d2000003/train/csharp
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string ToCamelCase(string str)
    {
        var words = str.Split('-', '_');
        var word = string.Join("", words.Select((word, index) => index == 0 ? word : Capitalize(word)));
        return word;
    }

    private static string Capitalize(string str)
    {
        return char.ToUpper(str[0]) + str[1..];
    }

    /// <summary>
    /// https://www.codewars.com/kata/514b92a657cdc65150000006/train/csharp
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int SumOfMultiples3Or5(int value)
    {
        var sum = 0;

        if (value < 0)
        {
            return sum;
        }

        for (var i = value - 1; i > 2; i--)
        {
            if (i % 3 == 0 || i % 5 == 0)
            {
                sum += i;
            }
        }

        return sum;
    }

    /// <summary>
    /// https://www.codewars.com/kata/52685f7382004e774f0001f7/train/csharp
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    public static string GetReadableTime(int seconds)
    {
        var hours = seconds / 3600;
        var minutes = seconds % 3600 / 60;
        var secondsCount = seconds % 60;

        return $"{hours:D2}:{minutes:D2}:{secondsCount:D2}";
    }

    public static string DuplicateEncode(string word)
    {
        word = word.ToLower();
        var charactersCount = new Dictionary<char, int>();
        foreach (var c in word)
        {
            if (!charactersCount.ContainsKey(c))
            {
                charactersCount.Add(c, 1);
            }
            else
            {
                charactersCount[c] += 1;
            }
        }

        var builder = new StringBuilder(word.Length);
        foreach (var character in word)
        {
            if (charactersCount[character] > 1)
            {
                builder.Append(')');
            }
            else
            {
                builder.Append('(');
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// https://www.codewars.com/kata/5592e3bd57b64d00f3000047/train/csharp
    /// </summary>
    /// <param name="m"></param>
    /// <returns></returns>
    public static long findNb(long m)
    {
        // your code
        var sum = 0L;

        for (var i = 1;; i++)
        {
            sum += (long)Math.Pow(i, 3);
            if (sum == m)
            {
                return i;
            }

            if (sum > m)
            {
                return -1;
            }

            // Console.WriteLine($"Current number is {i}");
            // Console.WriteLine($"Current sum is {sum}");
        }
    }

    /// <summary>
    /// https://www.codewars.com/kata/5839edaa6754d6fec10000a2/train/csharp
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static char FindMissingLetter(char[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            if (array[i] - array[i-1] > 1)
            {
                return (char)(array[i] - 1);
            }
        }
        return ' ';
    }

    public static int[] MoveZeroes(int[] arr)
    {
        var numbers = arr.Where(number => number != 0).ToList();

        numbers.AddRange(Enumerable.Repeat(0, arr.Length - numbers.Count));

        return numbers.ToArray();
    }

    /// <summary>
    /// https://www.codewars.com/kata/5839edaa6754d6fec10000a2/train/csharp
    /// In place solution without extra memory allocation, its fast and efficient than the previous solution, also involves algorithm design
    /// </summary>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static int[] MoveZeroesInPlace(int[] arr)
    {
        int nonZeroIndex = 0; // Index to place the next non-zero element.

        // Move all non-zero elements to the front of the array.
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != 0)
            {
                arr[nonZeroIndex] = arr[i];
                nonZeroIndex++;
            }
        }

        // Fill the rest of the array with zeroes.
        for (int i = nonZeroIndex; i < arr.Length; i++)
        {
            arr[i] = 0;
        }

        return arr;
    }
    
    /// <summary>
    /// https://www.codewars.com/kata/5266876b8f4bf2da9b000362/train/csharp
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public static string Likes(string[] name)
    {
        var phrase = name switch
        {
            null or { Length: 0 } => "no one likes this",
            { Length: 1 } => $"{name[0]} likes this",
            { Length: 2 } => $"{name[0]} and {name[1]} like this",
            { Length: 3 } => $"{name[0]}, {name[1]} and {name[2]} like this",
            _ => $"{name[0]}, {name[1]} and {name.Length - 2} others like this"
        };

        return phrase;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string Rot13(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return string.Empty;
        }

        return string.Concat(message.Select(c =>
        {
            if (char.IsLetter(c))
            {
                if (char.IsUpper(c))
                {
                    return (char)((c - 'A' + 13) % 26 + 'A');
                }
                else
                {
                    return (char)((c - 'a' + 13) % 26 + 'a');
                }
            }
            return c;
        }));
    }

    /// <summary>
    /// https://www.codewars.com/kata/534d2f5b5371ecf8d2000a08/train/csharp
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public static int[,] MultiplicationTable(int size)
    {
        var table = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                table[i, j] = (i + 1) * (j + 1);
            }
        }

        return table;
    }
    
    /// <summary>
    /// https://www.codewars.com/kata/51c8e37cee245da6b40000bd/train/csharp
    /// Got help from ChatGPT when solving this task, but thanks to it learned new things regarding regex
    /// </summary>
    /// <param name="text"></param>
    /// <param name="commentSymbols"></param>
    /// <returns></returns>
    public static string StripComments(string text, string[] commentSymbols)
    {
        // Create a regex pattern by escaping comment symbols and joining them with "|"
        var pattern = string.Join("|", commentSymbols.Select(Regex.Escape));

        // Process each line separately
        return string.Join("\n", text
            .Split('\n') // Split input into lines
            .Select(line => Regex.Replace(line, $@"\s*({pattern}).*", string.Empty).TrimEnd())); // Remove comment & trailing spaces
    }
    

    //TODO: try to implement without regex
    public static string StripCommentsAlternative(string text, string[] commentSymbols)
    {
        return "";
    }
    
    /// <summary>
    /// https://www.codewars.com/kata/51ba717bb08c1cd60f00002f/train/csharp
    ///
    /// TODO: Check top solutions here: https://www.codewars.com/kata/51ba717bb08c1cd60f00002f/solutions/csharp
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static string Extract(int[] args)
    {
        if (args == null || args.Length == 0)
            return "";

        var result = new List<string>(); // Store the formatted numbers and ranges
        var start = args[0];  // Start of a potential range
        var end = args[0];    // End of the range

        for (var i = 1; i < args.Length; i++)
        {
            if (args[i] != end + 1)
            {
                // We reached a break in the sequence, so process the previous range
                result.Add(FormatSegment(start, end));
                
                // Start a new range with the current number
                start = args[i];
            }

            end = args[i];
        }

        // Add the final range after the loop ends
        result.Add(FormatSegment(start, end));

        // Join everything with commas and return
        return string.Join(",", result);
    }
    
    private static string FormatSegment(int start, int end)
    {
        if (end - start >= 2)  
            return $"{start}-{end}";  // Store as a range
        else if (start == end)
            return start.ToString();  // Store as a single number
        else
            return $"{start},{end}";  // Store as two separate numbers
    }
    
    
    
    
}