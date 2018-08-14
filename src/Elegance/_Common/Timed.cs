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
    
    public class Timed<T>
    {
        private readonly string _name;
        private readonly Func<T> _getResult;

        public Timed(string name, Func<T> getResult)
        {
            _name = name;
            _getResult = getResult;
        }
        
        public T OutputTo(IConsumer<string> output)
        {            
            var start = DateTime.Now;
            var result = _getResult();
            var duration = DateTime.Now - start;
            output.Put($"{_name} - {duration.TotalMilliseconds}ms");
            return result;
        }
    }
}
