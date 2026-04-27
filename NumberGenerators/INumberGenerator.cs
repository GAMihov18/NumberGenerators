using System.Numerics;

namespace NumberGenerators;

public interface INumberGenerator<out T> where T : INumber<T>
{
    public void Initialize();
    public IEnumerable<T> GenerateNumbers();
    public T NextNumber { get; }
}