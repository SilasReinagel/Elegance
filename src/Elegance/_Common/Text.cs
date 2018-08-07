namespace Elegance._Common
{
    public struct Text : IText
    {
        private readonly string _text;
        public Text(string text) => _text = text;
        public string Read() => _text;
    }
}
