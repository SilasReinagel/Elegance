using System;

namespace Elegance._Common
{
    public class Timed
    {
        private readonly string _name;
        private readonly Action _action;

        public Timed(string name, Action action)
        {
            _name = name;
            _action = action;
        }
        
        public void OutputTo(IConsumer<string> output)
        {            
            var start = DateTime.Now;
            _action();
            var duration = DateTime.Now - start;
            output.Put($"{_name} - {duration.TotalMilliseconds}ms");
        }
    }
}
