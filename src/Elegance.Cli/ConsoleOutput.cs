using System;

namespace Elegance._Common
{
    public sealed class ConsoleOutput : IConsumer<string>
    {
        public void Put(string value) => Console.WriteLine(value);
    }
}
