using Engine.Utils;
using NUnit.Framework;

namespace MiniRPGTests
{
    [TestFixture]
    public class GeneratorTests
    {
        [Test]
        public void Generator_ShouleGenerate_Correct()
        {
            int N = 100;

            bool minValue = false;
            bool maxValue = false;

            for (int i = 0; i < 100000; i++)
            {
                int result = Generator.Next(1, N);

                if (result == 1)
                    minValue = true;

                if (result == N)
                    maxValue = true;

                Assert.IsTrue(result > 0 && result <= N);
            }

            Assert.IsTrue(minValue);
            Assert.IsTrue(maxValue);
        }
    }
}
