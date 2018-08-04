using System.Collections.Generic;
using Elegance._Common;

namespace Elegance
{
    public struct MaxSourceFileLines : IAnalysisRule
    {
        private readonly int _maxLines;
        
        public string Description => $"Files Longer Than {_maxLines} Lines";
        public int Count { get; }
        public IEnumerable<string> Violators { get; }
        
        public MaxSourceFileLines(int maxLines)
            : this(maxLines, 0, new List<string>(0)) {}
        
        private MaxSourceFileLines(int maxLines, int count, IEnumerable<string> violators)
        {
            _maxLines = maxLines;
            Count = count;
            Violators = violators;
        }
        
        public IAnalysisRule Apply(FileAnalysisResult file)
        {
            return file.Value[nameof(SrcLinesCount)] > _maxLines 
                ? new MaxSourceFileLines(_maxLines, Count + 1, Violators.Concat(file.FileName))
                : this;
        }
    }
}
