using System.Diagnostics;
using Microsoft.CodeAnalysis;

namespace Elegance.Analysis
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct SourceLinesCount : ISyntaxNodeCounter
    {
        private readonly bool _isCalculated;
        public string Description => CountType.SourceLines.ToString();
        public int Count { get; }

        private SourceLinesCount(int count)
        {
            _isCalculated = true;
            Count = count;
        }

        public ISyntaxNodeCounter Apply(SyntaxNode node) 
            => _isCalculated ? this : new SourceLinesCount(node.GetText().Lines.Count);
    }
}
