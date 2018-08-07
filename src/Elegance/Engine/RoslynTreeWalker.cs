using System.Collections.Generic;
using System.Linq;
using Elegance.Analysis;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Elegance.Engine
{
    public sealed class RoslynTreeWalker : CSharpSyntaxWalker
    {
        private readonly Dictionary<string, ISyntaxNodeCounter> _counters;
        private readonly List<string> _cNames;

        public RoslynTreeWalker(params ISyntaxNodeCounter[] counters)
        {
            _cNames = counters.Select(x => x.Description).ToList();
            _counters = counters.ToDictionary(x => x.Description, x => x);
        }

        public Dictionary<string, ISyntaxNodeCounter> Count(SyntaxTree tree)
        {
            Visit(tree.GetRoot());
            return _counters;
        }
            
        public override void Visit(SyntaxNode node)
        {
            foreach (var name in _cNames)
                _counters[name] = _counters[name].Apply(node);
            base.Visit(node);
        }
    }
}
