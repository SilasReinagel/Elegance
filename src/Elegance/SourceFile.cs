using System.IO;
using System.Linq;

namespace Elegance
{
    public struct SourceFile
    {
        private readonly string _fileName;

        public SourceFile(string fileName) => _fileName = fileName;

        public FileAnalysisResult Get(params IAnalysisCounter[] counters)
        {
            var cNames = counters.Select(x => x.Description).ToList();
            var counts = counters.ToDictionary(x => x.Description, x => x);
            foreach (var line in File.ReadLines(_fileName))
                foreach (var c in cNames)
                    counts[c] = counts[c].Apply(line);
            
            return new FileAnalysisResult(_fileName, counts.Values);
        }
    }
}
