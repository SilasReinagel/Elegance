using System.Collections.Generic;
using Elegance._Common;

namespace Elegance
{
    public sealed class NoFilesWithNull : IAnalysisRule
    {
        public string Description => "Files with 'null'";
        public int Count { get; }
        public IEnumerable<string> Violators { get; }
        
        public NoFilesWithNull()
            : this(0, new List<string>()) { }
        
        private NoFilesWithNull(int count, IEnumerable<string> violators)
        {
            Count = count;
            Violators = violators;
        }

        public IAnalysisRule Apply(FileAnalysisResult file)
            => file.Value[nameof(NullCount)] > 0
                ? new NoFilesWithNull(Count + 1, Violators.Concat(file.FileName))
                : this;
    }
}
