// // See https://aka.ms/new-console-template for more information
// // Console.WriteLine("Hello, mykati!");
// // int age=32;
// // Console.WriteLine("My age is "+age);
// // C# program to illustrate
// // the use of Console.ReadLine()
// using System;
// using System.Text; // For StringBuilder

// class StringCompression
// {
//     // Function to compress the string
//     public static string Compress(string input)
//     {
//         if (string.IsNullOrEmpty(input)) return ""; // Handle empty strings

//         StringBuilder compressed = new StringBuilder();
//         int count = 1; // Initialize count of characters

//         for (int i = 1; i < input.Length; i++)
//         {
//             if (input[i] == input[i - 1])
//             {
//                 count++;
//             }
//             else
//             {
//                 // Append the character (escape if special) and its count if greater than 1
//                 AppendEscaped(compressed, input[i - 1]);
//                 if (count > 1)
//                 {
//                     compressed.Append(count);
//                 }
//                 count = 1; // Reset count
//             }
//         }

//         // Handle the last character
//         AppendEscaped(compressed, input[input.Length - 1]);
//         if (count > 1)
//         {
//             compressed.Append(count);
//         }
//         // string result = compressed.ToString();
//         // byte[] bytes = Encoding.Default.GetBytes(result);
//         // result = Encoding.UTF8.GetString(bytes);
//         // return result;
//         return compressed.ToString();
//     }

//     // Helper function to append escaped characters
//     private static void AppendEscaped(StringBuilder sb, char c)
//     {
//         if (char.IsDigit(c)) // Escape backslash and digits
//         {
//             sb.Append('\\');
//         }
//         sb.Append(c);
//     }

//     // Function to decompress the string
//     public static string Decompress(string compressed)
//     {
//         if (string.IsNullOrEmpty(compressed)) return ""; // Handle empty strings

//         StringBuilder decompressed = new StringBuilder();

//         for (int i = 0; i < compressed.Length; i++)
//         {
//             char current = compressed[i];

//             if (current == '\\') // Handle escaped characters
//             {
//                 i++; // Move to the next character
//                 decompressed.Append(compressed[i]);
//                 continue;
//             }

//             int count = 0;

//             // Check if the next characters are digits (indicating a count)
//             while (i + 1 < compressed.Length && char.IsDigit(compressed[i + 1]))
//             {
//                 count = count * 10 + (compressed[i + 1] - '0'); // Convert char to int
//                 i++;
//             }

//             // If no count, default to 1
//             if (count == 0) count = 1;

//             // Append the character "count" times
//             decompressed.Append(new string(current, count));
//         }

//         // string result = decompressed.ToString();
//         // byte[] bytes = Encoding.Default.GetBytes(result);
//         // result = Encoding.UTF8.GetString(bytes);
//         // return result;
//         return decompressed.ToString();
//     }

//     // Test cases
//     public static void Main(string[] args)
//     {
//         string input = "cS66666666666666666666666666666666666666666666666sCCCCCCCCCCCCCCCCCCCCCCRF5sMdMhuhWWWWWWWWWWWWWwwwwwwwwwwwwwwwwwwwwk#qg%rsNgdt&MuM0YaQ!EdHqFuUDDDDDDVVVVVQQQQQccccccZZZZZZZZxcjjjjjjjjjjjJJJJ";    
//         // string input = Console.ReadLine();  
//         // byte[] bytes = Encoding.Default.GetBytes(input); 
//         // input = Encoding.UTF8.GetString(bytes);
//         Console.WriteLine("Initial:  > > "+ input); 
 
//         string compressed = Compress(input);    
//         Console.WriteLine("Compressed: >> ");
//         Console.WriteLine();
//         Console.WriteLine(compressed);

//         string decompressed = Decompress(compressed);
//         Console.WriteLine("Decompressed: >>");
//         Console.WriteLine();
//         Console.WriteLine(decompressed);
        

//         // Verify correctness
//         Console.WriteLine("Is Correct: " + (input == decompressed));
//     }
// }

using System;
using System.Text; // For StringBuilder

class StringCompression
{
    // Function to compress the string
    public static string Compress(string input)
    {
        if (string.IsNullOrEmpty(input)) return ""; // Handle empty strings

        StringBuilder compressed = new StringBuilder();
        int count = 1; // Initialize count of characters

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                count++;
            }
            else
            {
                // Append the character (escape if it's a digit) and its count if greater than 1
                if (char.IsDigit(input[i - 1]))
                {
                    compressed.Append('\\'); // Escape digit
                }
                compressed.Append(input[i - 1]);
                if (count > 1)
                {
                    compressed.Append(count);
                }
                count = 1; // Reset count
            }
        }

        // Handle the last character
        if (char.IsDigit(input[input.Length - 1]))
        {
            compressed.Append('\\'); // Escape digit
        }
        compressed.Append(input[input.Length - 1]);
        if (count > 1)
        {
            compressed.Append(count);
        }

        return compressed.ToString();
    }

    // Function to decompress the string
    public static string Decompress(string compressed)
    {
        if (string.IsNullOrEmpty(compressed)) return ""; // Handle empty strings

        StringBuilder decompressed = new StringBuilder();

        for (int i = 0; i < compressed.Length; i++)
        {
            char current = compressed[i];

            if (current == '\\') // Handle escaped characters
            {
                i++; // Move to the next character
                //decompressed.Append(compressed[i]);
                current = compressed[i];
                //continue;
            }

            int count = 0;

            // Check if the next characters are digits (indicating a count)
            while (i + 1 < compressed.Length && char.IsDigit(compressed[i + 1]))
            {
                count = count * 10 + (compressed[i + 1] - '0'); // Convert char to int
                i++;
            }

            // If no count, default to 1
            if (count == 0) count = 1;

            // Append the character "count" times
            decompressed.Append(new string(current, count));
        }

        return decompressed.ToString();
    }

    // Test cases
    public static void Main(string[] args)
    {
        string input = "S666666666666666666666666666666cccczzzzzzzzzzzzzz//////////////////////////zzzzzVVVVVVVVVVVVVVV164SsCCCCCCCCCCCCCCCCCCCCCCRF5sMdMhuhWWWWWWWWWWWWWwwwwwwwwwwwwwwwwwwwwk#qg%rsNgdt&MuM0YaQ!EdHqFuUDDDDDDVVVVVQQQQQccccccZZZZZZZZxcjjjjjjjjjjjJJJJ";
        // string input = Console.ReadLine();  
        // byte[] bytes = Encoding.Default.GetBytes(input); 
        // input = Encoding.UTF8.GetString(bytes);
        Console.WriteLine("Compressed: " + input);
        string compressed = Compress(input);
        Console.WriteLine("Compressed: " + compressed);

        string decompressed = Decompress(compressed);
        Console.WriteLine("Decompressed: " + decompressed);

        // Verify correctness
        Console.WriteLine("Is Correct: " + (input == decompressed));
    }
}
