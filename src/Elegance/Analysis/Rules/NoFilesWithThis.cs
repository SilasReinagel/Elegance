using System.Collections.Generic;
using Elegance._Common;

namespace Elegance
{
    public sealed class NoFilesWithThis : IAnalysisRule
    {
        public string Description => "Files with 'this'";
        public int Count { get; }
        public IEnumerable<string> Violators { get; }
        
        public NoFilesWithThis()
            : this(0, new List<string>()) { }
        
        private NoFilesWithThis(int count, IEnumerable<string> violators)
        {
            Count = count;
            Violators = violators;
        }

        public IAnalysisRule Apply(FileAnalysisResult file)
            => file.Value[CountType.This.ToString()] > 0
                ? new NoFilesWithThis(Count + 1, Violators.Concat(file.FileName))
                : this;
    }
}
