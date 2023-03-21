using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace program_test
{

    using program;
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Test1()
        {
            int a = 1;
            int b = 2;
            int c = 3;

            int suma = Program.AddNumbers(a, b, c);

            Assert.AreEqual(6, suma);
        }

        [TestMethod]
        public void Test2()
        {
            int a = 0;
            int b = -2;
            int c = 0;

            int suma = Program.AddNumbers(a, b, c);

            Assert.AreEqual(-2, suma);
        }

        [TestMethod]
        public void Test3()
        {
            int a = -1;
            int b = -5;
            int c = -3;

            int suma = Program.AddNumbers(a, b, c);

            Assert.AreNotEqual(-7, suma);
        }


    }
}