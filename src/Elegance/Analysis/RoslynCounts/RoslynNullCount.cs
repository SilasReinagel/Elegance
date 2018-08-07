using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Elegance.Analysis
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct RoslynNullCount : ISyntaxNodeCounter
    {
        public string Description => CountType.NullCount.ToString();
        public int Count { get; }

        private RoslynNullCount(int count) => Count = count;

        public ISyntaxNodeCounter Apply(SyntaxNode node)
            => new RoslynNullCount(Count 
                + (node.Kind().Equals(SyntaxKind.NullLiteralExpression) || node.Kind().Equals(SyntaxKind.NullKeyword) ? 1 : 0));
    }
}
