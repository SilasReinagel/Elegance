using Elegance.Analysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests
{
    [TestClass]
    public sealed class SourceLinesCountTests : RoslynCounts
    {
        protected override ISyntaxNodeCounter Counter => new SourceLinesCount();

        [TestMethod]
        public void SourceLinesCount_SimpleCountLines_CountIsCorrect() =>
            AssertCountIs(5, @"
                public void Go()
                {
                    string s = ""Anything"";
                }");
        
        [TestMethod]
        public void SourceLinesCount_WithLeadingAndTrailingLines_CountIsCorrect() =>
            AssertCountIs(8, @"

                public void Go()
                {
                    string s = ""Anything"";
                }

                ");
    }
}
