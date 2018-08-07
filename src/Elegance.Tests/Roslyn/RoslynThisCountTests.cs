using Elegance.Analysis;
using Elegance.Engine;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests.Roslyn
{
    [TestClass]
    public class RoslynThisCheckTests
    {
        [TestMethod]
        public void RoslynThisCheck_ZeroThis_CountIsZero()
        {
            var w = new RoslynTreeWalker(new RoslynThisCount()).Count(CSharpSyntaxTree.ParseText(@"
                public void Go()
                {
                    string s = ""Hi"";
                }"));
            
            Assert.AreEqual(0, w["ThisCount"].Count);
        }
        
        [TestMethod]
        public void RoslynThisCheck_OneThis_CountIsOne()
        {
            var w = new RoslynTreeWalker(new RoslynThisCount()).Count(CSharpSyntaxTree.ParseText(@"
                public class Number
                {
                    private readonly int _value;
    
                    public Number(int value)
                    {
                        this._value = value;
                    }
                }"));
            
            Assert.AreEqual(1, w["ThisCount"].Count);
        }
        
        [TestMethod]
        public void RoslynThisCheck_OneThisInLambdaCtor_CountIsOne()
        {
            var w = new RoslynTreeWalker(new RoslynThisCount()).Count(CSharpSyntaxTree.ParseText(@"
                public class Number
                {
                    private readonly int _value;
    
                    public Number(int value) => this._value = value;
                }"));
            
            Assert.AreEqual(1, w["ThisCount"].Count);
        }
        
        [TestMethod]
        public void RoslynThisCheck_TwoThis_CountIsTwo()
        {
            var w = new RoslynTreeWalker(new RoslynThisCount()).Count(CSharpSyntaxTree.ParseText(@"
                public class Number
                {
                    private readonly int _value;
    
                    public Number(int value)
                    {
                        this._value = value;
                    }
                    
                    public int Value => this._value;
                }"));
            
            Assert.AreEqual(2, w["ThisCount"].Count);
        }
    }
}
