using System.Collections.Generic;
using System.Linq;
using Elegance._Common;

namespace Elegance
{
    public sealed class FileAnalysisResult
    {
        private readonly IEnumerable<ICounter> _counts;

        public string FileName { get; }

        public FileAnalysisResult(string fileName, IEnumerable<ICounter> counts)
        {
            FileName = fileName;
            _counts = counts;
        }

        public IReadOnlyDictionary<string, int> Value => _counts.ToDictionary(x => x.Description, x => x.Count);
    }
}
