using NumberGenerators;

namespace Tests;

public class NormalGeneratorTests
{
	[Fact]
	public void NormalGenerator_WithSameSeed_ReturnsSameSequence()
	{
		var gen1 = new NormalGenerator<int>(100, 15, 42);
		var gen2 = new NormalGenerator<int>(100, 15, 42);

		for (int i = 0; i < 100; i++)
		{
			Assert.Equal(gen1.NextNumber, gen2.NextNumber);
		}
	}
	[Fact]
	public void NormalGenerator_WithDifferentSeeds_ReturnsDifferentSequence()
	{
		var gen1 = new NormalGenerator<int>(100, 15, 1);
		var gen2 = new NormalGenerator<int>(100, 15, 2);

		var seq1 = Enumerable.Range(0, 20).Select(_ => gen1.NextNumber).ToArray();
		var seq2 = Enumerable.Range(0, 20).Select(_ => gen2.NextNumber).ToArray();

		Assert.NotEqual(seq1, seq2);
	}
	[Fact]
	public void NormalGenerator_ManySamples_HasApproximateStandardDeviation()
	{
		var generator = new NormalGenerator<int>(100, 15, 42);

		var samples = Enumerable.Range(0, 100_000)
			.Select(_ => generator.NextNumber)
			.ToArray();

		double mean = samples.Average();

		double variance = samples
			.Select(x => Math.Pow(x - mean, 2))
			.Average();

		double stdDev = Math.Sqrt(variance);

		Assert.InRange(stdDev, 14.8, 15.2);
	}
	[Fact]
	public void NormalGenerator_ManySamples_HasApproximateMean()
	{
		var generator = new NormalGenerator<int>(100, 15, 42);

		var samples = Enumerable.Range(0, 100_000)
			.Select(_ => generator.NextNumber)
			.ToArray();

		double sampleMean = samples.Average();

		Assert.InRange(sampleMean, 99.5, 100.5);
	}
}