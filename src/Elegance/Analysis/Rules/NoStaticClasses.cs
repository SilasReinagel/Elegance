using System.Collections.Generic;
using Elegance._Common;

namespace Elegance
{
    public sealed class NoStaticClasses : IAnalysisRule
    {
        public string Description => "Files with 'static class'";
        public int Count { get; }
        public IEnumerable<string> Violators { get; }

        public NoStaticClasses()
            : this(0, new List<string>()) { }
        
        private NoStaticClasses(int count, IEnumerable<string> violators)
        {
            Count = count;
            Violators = violators;
        }

        public IAnalysisRule Apply(FileAnalysisResult file)
            => file.Value[nameof(StaticNonExtensionClassesCount)] > 0
                ? new NoStaticClasses(Count + 1, Violators.Concat(file.FileName))
                : this;
    }
}
