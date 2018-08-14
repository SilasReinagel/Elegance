using System.IO;
using System.Linq;
using Elegance.Analysis;
using Elegance._Common;

namespace Elegance.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            new Timed("Executed Program", () =>
            {
                var targetDir = args.Length > 0 ? args[0] : ".";
                new AnalysisSummary(
                        Directory.GetFiles(targetDir, "*.cs", SearchOption.AllDirectories)
                            .Select(x => new AnalyzedFile(x, 
                                new NullCount(), 
                                new SourceLinesCount(),
                                new StaticNonExtensionClassCount(),
                                new ClassCount(), 
                                new ThisCount()))
                            .Select(x => x.Get()),
                        new CountTotalSourceFiles(),
                        new CountAvgSourceFileLines(),
                        new NoFilesWithNull(),
                        new NoFilesWithThis(),
                        new NoStaticNonExtensionClasses(),
                        new MaxSourceFileLines(80))
                    .OutputTo(new ConsoleOutput());
            }).OutputTo(new ConsoleOutput());
        }
    }
}
