using System;
using NUnit.Framework;

namespace kataTry
{
    [TestFixture]
    public class Class1
    {
    
        private static StringCalculator GetStringCalc()
        {
            return new StringCalculator();
        }
        [Test]
        public void add_Empty_string()
        {
            StringCalculator stringCalculator = GetStringCalc();

            int result = stringCalculator.add("");

            Assert.AreEqual(0, result);
        }

        [TestCase("0",0)]
        [TestCase("1",1)]
        public void Add_SingleNumber_ReturnsNumber(string numbers, int expected)
        {
            StringCalculator stringCalculator = GetStringCalc();
            int result = stringCalculator.add(numbers);

            Assert.AreEqual(expected , result);
            //5:02
        }
        [TestCase("0,0", 0)]
        [TestCase("1,1", 2)]
        public void Add_DelimNumber_ReturnsSum(string numbers, int expected )
        {
            StringCalculator stringCalculator = GetStringCalc();

            int result = stringCalculator.add(numbers);

            Assert.AreEqual(expected , result);
        }

        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3", 6)]
        public void Add_Multiple_Delim_ReturnsSum(string numbers, int expected)
        {
            StringCalculator stringCalculator = GetStringCalc();

            int result = stringCalculator.add(numbers);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Add_NewLineDelim_ReturenSum()
        {
            StringCalculator stringCalculator = GetStringCalc();

            int result = stringCalculator.add("1\n2,3" );

            Assert.AreEqual(6 ,result);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//!\n1!2", 3)]
        public void Add_User_Specified_DelimNumbers_ReturnsSum (string numbers, int expected)
        {
            StringCalculator stringCalculator = GetStringCalc();

            int result = stringCalculator.add(numbers);

            Assert.AreEqual(expected, result);
        }
        [TestCase("0, -1", "negative numbers not allowed: -1")]
        [TestCase("0, -2", "negative numbers not allowed: -2")]
        public void Add_SingleNegativeNumber_ThrowsExceptionWithMessage(String numbers, String negativeMessage)
        {
            StringCalculator stringCalculator = GetStringCalc();

            TestDelegate testDelegate = () => stringCalculator.add(numbers);

            var ex = Assert.Throws<ArgumentException>(testDelegate);
            Assert.AreEqual(negativeMessage, ex.Message);
        }
        [Test]
        public void Add_MultipleNegativeNumbers_ThrowsExceptionMessage()
        {
            StringCalculator stringCalculator = GetStringCalc();

            TestDelegate testDelegate = () => stringCalculator.add("-1 ,-2");

            var ex = Assert.Throws<ArgumentException>(testDelegate);

            Assert.AreEqual("negative numbers not allowed: -1,-2", ex.Message);
        }

    }
}
