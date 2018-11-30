using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class SherlockandtheValidString
    {
        static string IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "NO";
            if (s.Length < 5)
                return "YES";
            var arr = new Dictionary<char, int>();

            foreach (var c in s)
            {
                if (arr.ContainsKey(c))
                    arr[c]++;
                else
                    arr.Add(c, 1);
            }

            var smallest = int.MaxValue;
            var largest = 0;

            foreach (var c in arr)
            {
                var value = c.Value;
                if (value < smallest)
                    smallest = value;
                if (value > largest)
                    largest = value;
            }

            if (largest == smallest)
                return "YES";

            if (largest - smallest > 1 && smallest > 1)
                return "NO";
            var smallCount = 0;
            var largeCount = 0;
            var hashSet = new HashSet<int>();

            foreach (var c in arr)
            {
                var value = c.Value;
                if (value != smallest && value != largest)
                    return "NO";

                if (value == largest)
                    largeCount++;
                if (value == smallest)
                    smallCount++;
                if (hashSet.Contains(value))
                    continue;
                hashSet.Add(value);
            }

            if (hashSet.Count > 2)
                return "NO";
            if (hashSet.Count == 1)
                return "YES";
            if (largest - smallest > 1 && smallCount == 1 && smallest == 1)
                return "YES";

            if (largest - smallest == 1 && (largeCount == 1 || smallCount == 1))
                return "YES";

            if (largest - smallest >= 1)
                return "NO";
            if (largeCount > 1 && smallCount > 1)
                return "NO";
            if (largeCount > 1 && smallest > 1)
                return "NO";
            return "YES";

        }
    }
}
