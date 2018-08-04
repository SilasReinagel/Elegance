namespace Elegance._Common
{
    public interface IConsumer<in T>
    {
        void Put(T value);
    }
}
