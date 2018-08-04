using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Elegance
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct ThisCount : IAnalysisCounter
    {
        public string Description => GetType().Name;
        public int Count { get; }

        private ThisCount(int count) => Count = count;
        
        public IAnalysisCounter Apply(string srcLine) 
            => new ThisCount(Count + Regex.Matches(srcLine, @"this\.").Count);
    }
}
