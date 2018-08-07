using System.IO;

namespace Elegance._Common
{
    public sealed class FileText : IText
    {
        private readonly string _fileName;

        public FileText(string fileName) => _fileName = fileName;

        public string Read() => File.ReadAllText(_fileName);
    }
}
