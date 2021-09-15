namespace HomeAssignment
{
    using System.Collections.Generic;

    static public class Solution
    {
        private static List<char> Two = new List<char>() { 'a', 'b', 'c' };
        private static List<char> Three = new List<char>() { 'd', 'e', 'f' };
        private static List<char> Four = new List<char>() { 'g', 'h', 'i' };
        private static List<char> Five = new List<char>() { 'j', 'k', 'l' };
        private static List<char> Six = new List<char>() { 'm', 'n', 'o' };
        private static List<char> Seven = new List<char>() { 'p', 'q', 'r', 's' };
        private static List<char> Eight = new List<char>() { 't', 'u', 'v' };
        private static List<char> Nine = new List<char>() { 'w', 'x', 'y', 'z' };

        /// <summary>
        /// Given a string containing digits from 2-9 inclusive, return all
        /// possible letter combinations that the number(s) could represent.
        /// Return the answer in any order. A mapping of digit to letters
        /// just like on the telephone buttons.
        /// </summary>
        /// <param name="input"> A string containing digits from 2-9 inclusive. </param>
        /// <returns></returns>
        public static string Combinations(string input)
        {
            List<string> tmp = new List<string>();

            if (!InputChecker(input))
            {
                return OutputGenerator(tmp);
            }
            int n = input.Length;
            int[] indexers = new int[n];

            List<char>[] lists = ListGenerator(input);

            tmp = ResultGenerator(n, indexers, lists);

            
            // result sort
            string[] unsorted = tmp.ToArray();
            MergeSort(ref unsorted, 0, n - 1);
            return OutputGenerator(unsorted);

            //return OutputGenerator(tmp);
        }

        
        /// <summary>
        /// Generates the list of strings that will be formatted as the output.
        /// </summary>
        /// <param name="n"> The number of digits that were given. </param>
        /// <param name="indexers"> The array that stores the indexers. </param>
        /// <param name="lists"> The array that stores the character lists. </param>
        /// <returns></returns>
        public static List<string> ResultGenerator(int n, int[] indexers, List<char>[] lists)
        {
            List<string> tmp = new List<string>();
            do
            {
                tmp.Add(OneWordGenerator(n, indexers, lists));
                StepIndexers(n, indexers, lists);
            } while (indexers[0] != lists[0].Count);

            return tmp;
        }

        /// <summary>
        /// Generates one word for the output list.
        /// </summary>
        /// <param name="n"> The number of digits that were given. </param>
        /// <param name="indexers"> The array that stores the indexers. </param>
        /// <param name="lists"> The array that stores the character lists. </param>
        /// <returns></returns>
        public static string OneWordGenerator(int n, int[] indexers, List<char>[] lists)
        {
            string one = "";
            for (int i = 0; i < n; i++)
            {
                one += lists[i][indexers[i]];
            }
            return one;
        }

        /// <summary>
        /// Increases the indexers.
        /// </summary>
        /// <param name="n"> The number of digits that were given. </param>
        /// <param name="indexers"> The array that stores the indexers. </param>
        /// <param name="lists"> The array that stores the character lists. </param>
        public static void StepIndexers(int n, int[] indexers, List<char>[] lists)
        {
            int m = n - 1;
            indexers[m]++;
            do
            {
                if (indexers[m] >= lists[m].Count)
                {
                    if (m >= 1)
                    {
                        indexers[m] = 0;
                        indexers[m - 1]++;
                    }
                }
                m--;
            } while (m > 0);
        }

        /// <summary>
        /// Generates the char list array.
        /// </summary>
        /// <param name="input"> The digits that were given. </param>
        /// <returns></returns>
        public static List<char>[] ListGenerator(string input)
        {
            List<char>[] lists = new List<char>[input.Length];
            for (int i = 0; i < lists.Length; i++)
            {
                switch (int.Parse(input[i].ToString()))
                {
                    case 2:
                        lists[i] = Two;
                        break;
                    case 3:
                        lists[i] = Three;
                        break;
                    case 4:
                        lists[i] = Four;
                        break;
                    case 5:
                        lists[i] = Five;
                        break;
                    case 6:
                        lists[i] = Six;
                        break;
                    case 7:
                        lists[i] = Seven;
                        break;
                    case 8:
                        lists[i] = Eight;
                        break;
                    case 9:
                        lists[i] = Nine;
                        break;
                }
            }
            return lists;
        }

        /// <summary>
        /// Checks the input wheather it is correct.
        /// </summary>
        /// <param name="input"> The digits that were given. </param>
        /// <returns></returns>
        public static bool InputChecker(string input)
        {
            if (input.Length > 4 ||
                input.Length == 0 ||
                input.Contains("0") ||
                input.Contains("1") ||
                input.Contains(" ") ||
                input.Contains(",") ||
                input.Contains(".") ||
                !int.TryParse(input, out int numbers))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Converts the list of string to the appropriate output.
        /// </summary>
        /// <param name="lists"> The array that stores the character lists. </param>
        /// <returns></returns>
        public static string OutputGenerator(IEnumerable<string> list)
        {
            string result = "[";
            
            foreach (string item in list)
            {
                result += "\"" + item + "\",";
            }

            if (result[result.Length-1] == ',')
            {
                result = result.Remove(result.Length - 1);
            }
            
            return result + "]";
        }

        private static void Merge(ref string[] result, int start, int mid, int end)
        {
            string[] temp = new string[end - start + 1];

            int i = start, j = mid + 1, k = 0;
 
            while (i <= mid && j <= end)
            {
                if (result[i].CompareTo(result[j]) <= 0)
                {
                    temp[k] = result[i];
                    k += 1; i += 1;
                }
                else
                {
                    temp[k] = result[j];
                    k += 1; j += 1;
                }
            }

            while (i <= mid)
            {
                temp[k] = result[i];
                k += 1; i += 1;
            }

            while (j <= end)
            {
                temp[k] = result[j];
                k += 1; j += 1;
            }

            for (i = start; i <= end; i += 1)
            {
                result[i] = temp[i - start];
        
            }
        }

        /// <summary>
        /// Merge sort algorithm.
        /// </summary>
        /// <param name="result"> The array that contains the unsorted collection. </param>
        /// <param name="start"> Starting index of the array. </param>
        /// <param name="end"> Endig index of the array. </param>
        public static void MergeSort(ref string[] result, int start, int end)
        {
            if (start < end)
            {
                int mid = (start + end) / 2;
                MergeSort(ref result, start, mid);
                MergeSort(ref result, mid + 1, end);
                Merge(ref result, start, mid, end);
            }
        }
    }
}
