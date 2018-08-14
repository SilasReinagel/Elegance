using Elegance.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests
{
    [TestClass]
    public sealed class ThisCheckTests : RoslynCounts
    {
        protected override ISyntaxNodeCounter Counter => new ThisCount();

        [TestMethod]
        public void ThisCheck_ZeroThis_CountIsZero() =>
            AssertCountIs(0, @"
                public void Go()
                {
                    string s = ""Hi"";
                }");
        
        [TestMethod]
        public void ThisCheck_OneThis_CountIsOne() => 
            AssertCountIs(1, @"
                public class Number
                {
                    private readonly int _value;
    
                    public Number(int value)
                    {
                        this._value = value;
                    }
                }");
        
        [TestMethod]
        public void ThisCheck_OneThisInLambdaCtor_CountIsOne() =>
            AssertCountIs(1, @"
                public class Number
                {
                    private readonly int _value;
    
                    public Number(int value) => this._value = value;
                }");

        [TestMethod]
        public void ThisCheck_OneThisInSecondaryCtor_CountIsZero() =>
            AssertCountIs(0, @"
                public class Number
                {
                    private readonly int _value;
    
                    public Number()
                        : this(0) {}

                    public Number(int value)
                    {
                        _value = value;
                    }
                }");

        [TestMethod]
        public void ThisCheck_TwoThis_CountIsTwo() =>
            AssertCountIs(2, @"
                public class Number
                {
                    private readonly int _value;
    
                    public Number(int value)
                    {
                        this._value = value;
                    }
                    
                    public int Value => this._value;
                }");
    }
}
