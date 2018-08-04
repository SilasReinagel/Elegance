using System.Collections.Generic;
using Elegance._Common;

namespace Elegance
{
    public interface IAnalysisRule : ICounter
    {
        IEnumerable<string> Violators { get; }
        IAnalysisRule Apply(FileAnalysisResult file);
    }
}
