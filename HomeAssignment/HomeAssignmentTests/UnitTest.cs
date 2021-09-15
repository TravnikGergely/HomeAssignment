namespace HomeAssignmentTests
{
    using NUnit.Framework;
    using HomeAssignment;
    using System.Collections.Generic;

    public class Tests
    {
        /// <summary>
        /// Tests whether the program works correctly with wrong inputs.
        /// </summary>
        [TestCase("")]
        [TestCase("201")]
        [TestCase("24234")]
        [TestCase("asd")]
        [TestCase("35484")]
        [TestCase("350")]
        [TestCase("310")]
        public void WrongInputTest(string input)
        {
            Assert.That(!Solution.InputChecker(input));
        }


        /// <summary>
        /// Tests the sorter whether it works or not.
        /// </summary>
        /// <param name="sorted"> An array of sorted strings </param>
        /// <param name="unsorted"> An array of unsorted strings</param>
        [TestCase(  new string[] { "abc", "acb", "bac", "bca" },
                    new string[] { "bca", "bac", "acb", "abc" })]
        [TestCase(  new string[] { "As", "Asd", "Asd", "Asd", "Asdfw", "Ased", "D", "Er", "Erqw", "Erqw", "Oew", "Qw", "Qwer", "Sdad" },
                    new string[] { "Asd", "Ased", "Asd", "As", "D", "Asd", "Asdfw", "Er", "Oew", "Sdad", "Qwer", "Qw", "Erqw", "Erqw" })]
        [TestCase(  new string[] { "atde", "bkmf", "bsec", "btrx", "cexi", "dgem", "dink", "dpsw", "dskd", "duem", "dxhn", "edds", "elpx", "fdyo", "gkbw", "hyvo", "iyqx", "juuk", "kczl", "kftb", "kgwh", "knxk", "kzei", "lbdw", "lfxj", "llbn", "majr", "mbfm", "mmdz", "mnbc", "mqwn", "mroa", "mvxn", "naeg", "nrap", "ozgu", "pcmx", "psrj", "qlsn", "qsat", "rpkx", "rvla", "sfcn", "sgfj", "soif", "tbke", "txrb", "vaay", "vlrb", "vwhy", "wiyz", "wten", "xcbx", "xcoz", "xzif", "xzkq", "xzxy", "ybbq", "yxcy", "zkcw"},
                    new string[] { "xzif", "yxcy", "bsec", "xzxy", "qsat", "xcoz", "dgem", "ozgu", "kczl", "vlrb", "rvla", "xzkq", "dxhn", "wten", "dink", "mnbc", "xcbx", "fdyo", "bkmf", "mbfm", "knxk", "hyvo", "vwhy", "atde", "naeg", "psrj", "llbn", "duem", "mqwn", "majr", "qlsn", "elpx", "nrap", "btrx", "sfcn", "wiyz", "mroa", "sgfj", "zkcw", "lbdw", "cexi", "lfxj", "soif", "dpsw", "kftb", "ybbq", "edds", "juuk", "vaay", "txrb", "tbke", "gkbw", "dskd", "mmdz", "pcmx", "rpkx", "kzei", "kgwh", "mvxn", "iyqx" })]
        public void SortAlgorithmTester(string[] sorted, string[] unsorted)
        {

            Solution.MergeSort(ref unsorted, 0, unsorted.Length - 1);

            for (int i = 0; i < sorted.Length; i++)
            {
                Assert.That(sorted[i] == unsorted[i]);
            }
        }

        /// <summary>
        /// Tests wheather the ResultGenerator method generates the right amount of words.
        /// </summary>
        [Test]
        public void GeneratedWordsCountMatch()
        {
            int[] indexers = new int[3];
            int n = indexers.Length;
            List<char>[] lists = new List<char>[] { new List<char>() { 'a', 'b' },
                                     new List<char>() { 'c', 'd' },
                                     new List<char>() { 'e', 'f', 'g' } };
            List<string> result = Solution.ResultGenerator(n, indexers, lists);
            int x = 1;
            foreach (var item in lists)
            {
                x *= item.Count;
            }
            Assert.That(result.Count == x);
        }

        [TestCase("23", "[\"ad\",\"ae\",\"af\",\"bd\",\"be\",\"bf\",\"cd\",\"ce\",\"cf\"]")]
        [TestCase("", "[]")]
        [TestCase("2", "[\"a\",\"b\",\"c\"]")]
        public void ExampleTests(string input, string output)
        {
            string result = Solution.Combinations(input);
            Assert.That(output == result);
        }
    }
}