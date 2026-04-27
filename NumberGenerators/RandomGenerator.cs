using System.Numerics; 
namespace NumberGenerators;

public class RandomGenerator<T>(T min, T max, int seed) : INumberGenerator<T>
	where T : INumber<T>
{
	private readonly Random _random = new(seed);

	private IEnumerable<T> GenerateNumbers()
	{
		T value;
		while (true)
		{
			value = min + max * T.CreateChecked(_random.NextDouble());
			yield return value;
		}
	}
	
	public T NextNumber => GenerateNumbers().First();
}