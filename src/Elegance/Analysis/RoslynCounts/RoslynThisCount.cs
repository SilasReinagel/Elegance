using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Elegance.Analysis
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct RoslynThisCount : ISyntaxNodeCounter
    {
        public string Description => CountType.ThisCount.ToString();
        public int Count { get; }

        private RoslynThisCount(int count) => Count = count;

        public ISyntaxNodeCounter Apply(SyntaxNode node)
            => new RoslynThisCount(Count 
                                   + (node.Kind().Equals(SyntaxKind.ThisExpression) 
                                      || node.Kind().Equals(SyntaxKind.ThisKeyword)
                                      || node.Kind().Equals(SyntaxKind.ThisConstructorInitializer) ? 1 : 0));
    }
}
