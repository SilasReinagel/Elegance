using System.Diagnostics;

namespace Elegance
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct SrcLinesCount : IAnalysisCounter
    {
        public string Description => GetType().Name;
        public int Count { get; }

        private SrcLinesCount(int count) => Count = count;
        
        public IAnalysisCounter Apply(string srcLine) 
            => new SrcLinesCount(Count + 1);
    }
}
