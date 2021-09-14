namespace HomeAssignment
{
    using System.Collections.Generic;

    static public class Solution
    {
        public static string Combinations(string input)
        {
            List<string> tmp = new List<string>();
            if (input.Length > 4 || input.Length == 0 || input.Contains("0") || input.Contains("1") || !int.TryParse(input, out int numbers))
            {
                return Generator(tmp);
            }
            tmp.Add("asd");

            return Generator(tmp);
        }

        public static string Generator(List<string> list)
        {
            string result = "[";
            foreach (string item in list)
            {
                result +=@""" + item + @"",";
            }
            if (list.Count> 0)
            {
                result = result.Remove(result.Length - 1);
            }
            result += "]";
            return result;
        }
    }
}
