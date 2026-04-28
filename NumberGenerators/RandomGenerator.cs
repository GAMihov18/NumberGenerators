using System.Numerics; 
namespace NumberGenerators;

public class RandomGenerator<T>(double min, double max, int seed) : INumberGenerator<T> where T : INumber<T>
{
	private readonly Random _random = new(seed);

	private IEnumerable<T> GenerateNumbers()
	{
		while (true)
		{
			double value = min + _random.NextDouble() * (max - min);
			yield return T.CreateTruncating(value);
		}
	}
	
	public T NextNumber => GenerateNumbers().First();
}