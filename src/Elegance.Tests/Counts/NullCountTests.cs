using Elegance.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests
{
    [TestClass]
    public sealed class NullCheckTests : RoslynCounts
    {
        protected override ISyntaxNodeCounter Counter => new NullCount();

        [TestMethod]
        public void NullCheck_ZeroNulls_CountIsZero() =>
            AssertCountIs(0, @"
                public void Go()
                {
                    string s = ""Hi"";
                }");
        
        [TestMethod]
        public void NullCheck_OneNull_CountIsOne() =>
            AssertCountIs(1, @"
                public void Go()
                {
                    string s = null;
                }");
        
        [TestMethod]
        public void NullCheck_TwoNulls_CountIsTwo() =>
            AssertCountIs(2, @"
                public void Go()
                {
                    string s1 = null;
                    string s2 = null;
                }");
    }
}
