using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Elegance.Analysis
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct NullCount : ISyntaxNodeCounter
    {
        public string Description => CountType.Null.ToString();
        public int Count { get; }

        private NullCount(int count) => Count = count;

        public ISyntaxNodeCounter Apply(SyntaxNode node)
            => new NullCount(Count 
                + (node.Kind().Equals(SyntaxKind.NullLiteralExpression) || node.Kind().Equals(SyntaxKind.NullKeyword) ? 1 : 0));
    }
}
