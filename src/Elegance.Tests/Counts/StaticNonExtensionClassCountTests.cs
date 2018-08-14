using Elegance.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests
{
    [TestClass]
    public sealed class StaticClassCountTests : RoslynCounts
    {
        protected override ISyntaxNodeCounter Counter => new StaticNonExtensionClassCount();

        [TestMethod]
        public void StaticClassCount_NonStaticClass_CountIsZero() =>
            AssertCountIs(0, @"
                public class One { }");

        [TestMethod]
        public void StaticClassCount_StaticClass_CountIsOne() =>
            AssertCountIs(1, @"
                public static class One { }");

        [TestMethod]
        public void StaticClassCount_StaticExtensionsClass_CountIsZero() =>
            AssertCountIs(0, @"
                public static class NumberExtensions { }");
    }
}
