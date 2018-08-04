using System.Collections.Generic;
using System.Linq;
using Elegance._Common;

namespace Elegance
{
    public class AnalysisSummary
    {
        private readonly IEnumerable<FileAnalysisResult> _results;
        private readonly IAnalysisRule[] _analysisRules;

        public AnalysisSummary(IEnumerable<FileAnalysisResult> results, params IAnalysisRule[] analysisRules)
        {
            _results = results;
            _analysisRules = analysisRules;
        }

        public void OutputTo(IConsumer<string> output)
        {
            var ruleNames = _analysisRules.Select(x => x.Description).ToList();
            var ruleResults = _analysisRules.ToDictionary(x => x.Description, x => x);
            foreach (var result in _results)
                foreach (var rule in ruleNames)
                    ruleResults[rule] = ruleResults[rule].Apply(result);

            foreach (var r in ruleResults)
            {
                output.Put($"{r.Value.Description}: {r.Value.Count}");
                foreach(var v in r.Value.Violators)
                    output.Put($"    {v}");
                if (r.Value.Violators.Any())
                    output.Put("");
            }
        }
    }
}
