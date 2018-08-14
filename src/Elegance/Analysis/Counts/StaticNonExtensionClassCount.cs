using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Linq;

namespace Elegance.Analysis
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct StaticNonExtensionClassCount : ISyntaxNodeCounter
    {
        public string Description => CountType.StaticNonExtensionClass.ToString();
        public int Count { get; }

        private StaticNonExtensionClassCount(int count) => Count = count;

        public ISyntaxNodeCounter Apply(SyntaxNode node) => 
            new StaticNonExtensionClassCount(Count + (IsStaticClass(node) && IsNotNamedExtensions(node) ? 1 : 0));

        private bool IsNotNamedExtensions(SyntaxNode node) => 
            !((node.ChildTokens().Where(x => x.IsKind(SyntaxKind.IdentifierToken)).Select(x => x.Text).FirstOrDefault()) ?? "")
                        .ToLowerInvariant().Contains("extensions");

        private bool IsStaticClass(SyntaxNode node) => node.Kind().Equals(SyntaxKind.ClassDeclaration) 
                && ((ClassDeclarationSyntax)node).Modifiers.Any(x => x.IsKind(SyntaxKind.StaticKeyword));
    }
}
