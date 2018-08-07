using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Elegance.Analysis
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct RoslynClassCount : ISyntaxNodeCounter
    {
        public string Description => CountType.ClassCount.ToString();
        public int Count { get; }

        private RoslynClassCount(int count) => Count = count;

        public ISyntaxNodeCounter Apply(SyntaxNode node)
            => new RoslynClassCount(Count + (node.Kind().Equals(SyntaxKind.ClassDeclaration) ? 1 : 0));
    }
}
