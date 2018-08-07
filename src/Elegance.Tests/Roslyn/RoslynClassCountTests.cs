using Elegance.Analysis;
using Elegance.Engine;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests.Roslyn
{
    [TestClass]
    public class RoslynClassCountTests
    {
        [TestMethod]
        public void RoslynClassCount_NoClasses_CountIsZero()
        {
            var w = new RoslynTreeWalker(new RoslynClassCount()).Count(CSharpSyntaxTree.ParseText(@"
                public void Go()
                {
                    string s = ""Hi"";
                }"));
            
            Assert.AreEqual(0, w[CountType.ClassCount.ToString()].Count);
        }
        
        [TestMethod]
        public void RoslynClassCount_OneClass_CountIsOne()
        {
            var w = new RoslynTreeWalker(new RoslynClassCount()).Count(CSharpSyntaxTree.ParseText(@"
                public class First { }"));
            
            Assert.AreEqual(1, w[CountType.ClassCount.ToString()].Count);
        }
        
        [TestMethod]
        public void RoslynClassCount_OneClass_CountIsTwo()
        {
            var w = new RoslynTreeWalker(new RoslynClassCount()).Count(CSharpSyntaxTree.ParseText(@"
                public class First { }
                public class Second { }"));
            
            Assert.AreEqual(2, w[CountType.ClassCount.ToString()].Count);
        }
    }
}
