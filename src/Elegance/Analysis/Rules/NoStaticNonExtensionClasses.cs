using System.Collections.Generic;
using Elegance._Common;

namespace Elegance
{
    public sealed class NoStaticNonExtensionClasses : IAnalysisRule
    {
        public string Description => "Files with 'static class'";
        public int Count { get; }
        public IEnumerable<string> Violators { get; }

        public NoStaticNonExtensionClasses()
            : this(0, new List<string>()) { }
        
        private NoStaticNonExtensionClasses(int count, IEnumerable<string> violators)
        {
            Count = count;
            Violators = violators;
        }

        public IAnalysisRule Apply(FileAnalysisResult file)
            => file.Value[CountType.StaticNonExtensionClass.ToString()] > 0
                ? new NoStaticNonExtensionClasses(Count + 1, Violators.Concat(file.FileName))
                : this;
    }
}
