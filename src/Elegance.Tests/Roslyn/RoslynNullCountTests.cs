using Elegance.Analysis;
using Elegance.Engine;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests.Roslyn
{
    [TestClass]
    public class RoslynNullCheckTests
    {
        [TestMethod]
        public void RoslynNullCheck_ZeroNulls_CountIsZero()
        {
            var w = new RoslynTreeWalker(new RoslynNullCount()).Count(CSharpSyntaxTree.ParseText(@"
                public void Go()
                {
                    string s = ""Hi"";
                }"));
            
            Assert.AreEqual(0, w[CountType.NullCount.ToString()].Count);
        }
        
        [TestMethod]
        public void RoslynNullCheck_OneNull_CountIsOne()
        {
            var w = new RoslynTreeWalker(new RoslynNullCount()).Count(CSharpSyntaxTree.ParseText(@"
                public void Go()
                {
                    string s = null;
                }"));
            
            Assert.AreEqual(1, w[CountType.NullCount.ToString()].Count);
        }
        
        [TestMethod]
        public void RoslynNullCheck_TwoNulls_CountIsTwo()
        {
            var w = new RoslynTreeWalker(new RoslynNullCount()).Count(CSharpSyntaxTree.ParseText(@"
                public void Go()
                {
                    string s1 = null;
                    string s2 = null;
                }"));
            
            Assert.AreEqual(2, w[CountType.NullCount.ToString()].Count);
        }
    }
}
