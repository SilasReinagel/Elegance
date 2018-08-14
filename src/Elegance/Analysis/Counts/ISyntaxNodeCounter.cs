using Elegance._Common;
using Microsoft.CodeAnalysis;

namespace Elegance.Analysis
{
    public interface ISyntaxNodeCounter : ICounter
    {
        ISyntaxNodeCounter Apply(SyntaxNode node);
    }
}
