using System;
using System.IO;
using System.Linq;
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
                            .Select(x => new SourceFile(x))
                            .Select(x => x.Get(
                                new NullCount(), 
                                new SrcLinesCount(), 
                                new ClassCount(), 
                                new StaticNonExtensionClassesCount(),
                                new ThisCount())),
                        new CountTotalSourceFiles(),
                        new CountAvgSourceFileLines(),
                        new NoFilesWithNull(),
                        new NoFilesWithThis(),
                        new NoStaticClasses(),
                        new MaxSourceFileLines(100))
                    .OutputTo(new ConsoleOutput());
            }).OutputTo(new ConsoleOutput());
        }
    }
}