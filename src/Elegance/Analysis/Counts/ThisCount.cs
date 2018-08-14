using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Elegance.Analysis
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct ThisCount : ISyntaxNodeCounter
    {
        public string Description => CountType.This.ToString();
        public int Count { get; }

        private ThisCount(int count) => Count = count;

        public ISyntaxNodeCounter Apply(SyntaxNode node)
            => new ThisCount(Count + (node.Kind().Equals(SyntaxKind.ThisExpression) ? 1 : 0));
    }
}
