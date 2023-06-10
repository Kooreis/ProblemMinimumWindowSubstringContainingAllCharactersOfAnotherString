Here is a C# console application that solves the problem:

```csharp
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string str = Console.ReadLine();
        string pat = Console.ReadLine();

        Console.Write("Smallest window is :\n " + FindSubString(str, pat));
    }

    static String FindSubString(string str, string pat)
    {
        int len1 = str.Length;
        int len2 = pat.Length;

        if (len1 < len2)
        {
            Console.WriteLine("No such window exists");
            return "";
        }

        int[] hash_pat = new int[256];
        int[] hash_str = new int[256];

        for (int i = 0; i < len2; i++)
            hash_pat[pat[i]]++;

        int start = 0, start_index = -1, min_len = Int32.MaxValue;

        int count = 0;
        for (int j = 0; j < len1; j++)
        {
            hash_str[str[j]]++;

            if (hash_pat[str[j]] != 0 && hash_str[str[j]] <= hash_pat[str[j]])
                count++;

            if (count == len2)
            {
                while (hash_str[str[start]] > hash_pat[str[start]] || hash_pat[str[start]] == 0)
                {

                    if (hash_str[str[start]] > hash_pat[str[start]])
                        hash_str[str[start]]--;
                    start++;
                }

                int len_window = j - start + 1;
                if (min_len > len_window)
                {
                    min_len = len_window;
                    start_index = start;
                }
            }
        }

        if (start_index == -1)
        {
            Console.WriteLine("No such window exists");
            return "";
        }

        return str.Substring(start_index, min_len);
    }
}
```

This console application reads two strings from the input, the first one is the main string and the second one is the pattern. It then finds the smallest substring in the main string that contains all characters of the pattern. If no such substring exists, it prints "No such window exists" and returns an empty string.