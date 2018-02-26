using NUnit.Framework;
using System.Linq;
using Task4Logic;

namespace Task4Tests
{
    [TestFixture]
    public class MathHelperTests
    {
        [TestCase(arg: 20, Result = 0)]
        public long GetFibonacciNumber_Test(int count)
        {
            var math = new MathHelper();

            long i = 0;
            foreach (var item in math.GetFibonacciNumber().Take(20))
                i = item;

            return i;
        }
    }
}
