using System.Numerics;

namespace NumberGenerators;

public class ConstantGenerator<T>(T number) : INumberGenerator<T> where T : INumber<T>
{
	public T NextNumber
	{
		get { return number; }
	}
}