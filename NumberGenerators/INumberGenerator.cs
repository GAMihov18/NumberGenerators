using System.Numerics;

namespace NumberGenerators;

public interface INumberGenerator<out T> where T : INumber<T>
{
    public T NextNumber { get; }
}