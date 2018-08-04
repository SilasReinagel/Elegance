using System.Collections.Generic;

namespace Elegance
{
    public struct CountTotalSourceFiles : IAnalysisRule
    {
        public string Description => "Total Source Files";
        public int Count { get; }
        public IEnumerable<string> Violators => new List<string>();
        
        private CountTotalSourceFiles(int count)
        {
            Count = count;
        }
        
        public IAnalysisRule Apply(FileAnalysisResult file)
        {
            return new CountTotalSourceFiles(Count + 1);
        }
    }
}
