using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Elegance.Analysis
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct ClassCount : ISyntaxNodeCounter
    {
        public string Description => CountType.Class.ToString();
        public int Count { get; }

        private ClassCount(int count) => Count = count;

        public ISyntaxNodeCounter Apply(SyntaxNode node)
            => new ClassCount(Count + (node.Kind().Equals(SyntaxKind.ClassDeclaration) ? 1 : 0));
    }
}
