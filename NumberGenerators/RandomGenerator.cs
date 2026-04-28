using System.Numerics; 
namespace NumberGenerators;

public class RandomGenerator<T>(T min, T max, int seed) : INumberGenerator<T> where T : INumber<T>
{
	private readonly Random _random = new(seed);

	private IEnumerable<T> GenerateNumbers()
	{
		double minD = double.CreateChecked(min);
		double maxD = double.CreateChecked(max);
		while (true)
		{
			double value = minD + _random.NextDouble() * (maxD - minD);
			yield return T.CreateTruncating(value);
		}
	}
	
	public T NextNumber => GenerateNumbers().First();
}