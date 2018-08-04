using Elegance._Common;

namespace Elegance
{
    public interface IAnalysisCounter : ICounter
    {
        IAnalysisCounter Apply(string srcLine);
    }
}
