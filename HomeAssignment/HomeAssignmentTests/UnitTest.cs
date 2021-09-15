namespace HomeAssignmentTests
{
    using NUnit.Framework;
    using HomeAssignment;

    public class Tests
    {
        /// <summary>
        /// Tests whether the program works correctly with wrong inputs.
        /// </summary>
        [TestCase("")]
        [TestCase("201")]
        [TestCase("24234")]
        [TestCase("asd")]
        public void WrongInputTest(string input)
        {


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