using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Elegance
{
    [DebuggerDisplay("{Description}: {Count}")]
    public struct StaticNonExtensionClassesCount : IAnalysisCounter
    {
        public string Description => GetType().Name;
        public int Count { get; }

        private StaticNonExtensionClassesCount(int count) => Count = count;
        
        public IAnalysisCounter Apply(string srcLine) 
            => new StaticNonExtensionClassesCount(Count + 
                                    Math.Max(0, Regex.Matches(srcLine, " static class ").Count 
                                        - Regex.Matches(srcLine, "extensions", RegexOptions.IgnoreCase).Count));
    }
}
