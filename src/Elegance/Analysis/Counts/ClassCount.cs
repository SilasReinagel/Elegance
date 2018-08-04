using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Elegance
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct ClassCount : IAnalysisCounter
    {
        public string Description => GetType().Name;
        public int Count { get; }

        private ClassCount(int count) => Count = count;
        
        public IAnalysisCounter Apply(string srcLine) 
            => new ClassCount(Count + Regex.Matches(srcLine, " class ").Count);
    }
}
