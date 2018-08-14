using Elegance.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests
{
    [TestClass]
    public sealed class ClassCountTests : RoslynCounts
    {
        protected override ISyntaxNodeCounter Counter => new ClassCount();

        [TestMethod]
        public void ClassCount_NoClasses_CountIsZero() =>
            AssertCountIs(0, @"
                public void Go()
                {
                    string s = ""Hi"";
                }");
        
        [TestMethod]
        public void ClassCount_OneClass_CountIsOne() =>
            AssertCountIs(1, 
                "public class First { }");
        
        [TestMethod]
        public void ClassCount_TwoClasses_CountIsTwo() =>
            AssertCountIs(2, @"
                public class First { }
                public class Second { }");
    }
}
