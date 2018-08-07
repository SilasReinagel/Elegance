using Elegance.Analysis;
using Elegance.Engine;
using Elegance._Common;
using Microsoft.CodeAnalysis.CSharp;

namespace Elegance
{
    public sealed class RoslynAnalyzedFile : IFileAnalyzer
    {
        private readonly string _fileName;
        private readonly IText _text;
        private readonly ISyntaxNodeCounter[] _counters;

        public RoslynAnalyzedFile(string fileName, params ISyntaxNodeCounter[] counters)
            : this(fileName, new FileText(fileName), counters) {}
        
        public RoslynAnalyzedFile(string fileName, IText text, params ISyntaxNodeCounter[] counters)
        {
            _fileName = fileName;
            _text = text;
            _counters = counters;
        }

        public FileAnalysisResult Get()
        {
            var compiled = CSharpSyntaxTree.ParseText(_text.Read());
            var counts = new RoslynTreeWalker(_counters).Count(compiled);
            return new FileAnalysisResult(_fileName, counts.Values);
        }
    }
}
