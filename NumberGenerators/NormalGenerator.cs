using System.Numerics;

namespace NumberGenerators;

public class NormalGenerator<T>(T mean, T stdDev, int seed) : INumberGenerator<T> where T : INumber<T>
{
	
	private readonly Random _random = new(seed);
	private bool _hasSpare = false;
	private T? _spare;
	private IEnumerable<T> GenerateNumber()
	{
		if (_hasSpare)
		{
			_hasSpare = false;
			if (_spare != null) yield return mean + stdDev * _spare;
		}

		double u1 = 1.0 - _random.NextDouble();
		double u2 = 1.0 - _random.NextDouble();

		double r = Math.Sqrt(-2.0 * Math.Log(u1));
		double theta = 2.0 * Math.PI * u2;

		T z0 = T.CreateChecked(r * Math.Cos(theta));
		T z1 = T.CreateChecked(r * Math.Sin(theta));

		_spare = z1;
		_hasSpare = true;

		yield return mean + stdDev * z0;
	}

	public T NextNumber => GenerateNumber().First();
}