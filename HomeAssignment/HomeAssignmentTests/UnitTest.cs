namespace HomeAssignmentTests
{
    using NUnit.Framework;
    using HomeAssignment;

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests whether the program works correctly with wrong inputs.
        /// </summary>
        [TestCase("")]
        [TestCase("201")]
        [TestCase("24234")]
        [TestCase("asd")]
        public void WrongInputTest(string input)
        {
            string result = Solution.Combinations(input);
            Assert.That(result == "[]");
        }
    }
}