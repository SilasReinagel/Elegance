using System.Collections.Generic;

namespace Elegance
{
    public struct CountAvgSourceFileLines : IAnalysisRule
    {
        private readonly int _totalLines;
        private readonly int _numFiles;
        
        public string Description => "Avg Lines Per File";
        public int Count => _totalLines / _numFiles;
        public IEnumerable<string> Violators => new List<string>();

        private CountAvgSourceFileLines(int totalLines, int numFiles)
        {
            _totalLines = totalLines;
            _numFiles = numFiles;
        }

        public IAnalysisRule Apply(FileAnalysisResult file)
            => new CountAvgSourceFileLines(_totalLines + file.Value[CountType.SourceLines.ToString()], _numFiles + 1);
    }
}
