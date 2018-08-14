using Elegance.Analysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Elegance.Tests
{
    public abstract class RoslynCounts
    {
        protected abstract ISyntaxNodeCounter Counter { get; }

        public void AssertCountIs(int expectedCount, string src)
        {
            var counts = new RoslynTreeWalker(Counter).Count(CSharpSyntaxTree.ParseText(src));

            Assert.AreEqual(expectedCount, counts[Counter.Description].Count);
        }
    }
}
