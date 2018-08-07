using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Elegance
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct NullCount : IAnalysisCounter
    {
        public string Description => CountType.NullCount.ToString();
        public int Count { get; }

        private NullCount(int count) => Count = count;
        
        public IAnalysisCounter Apply(string srcLine) 
            => new NullCount(Count + Regex.Matches(srcLine, "[^\"']null[^\"']").Count);
    }
}
