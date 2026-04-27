using NumberGenerators;


namespace Tests;
public class RandomNumberGeneratorTests
{
	[Fact]
	public void DifferentRandomGenerators_ShouldReturnSameValues_WhenSameSeed()
	{
		var gen1 = new RandomGenerator<int>(10, 20, seed: 42);
		var gen2 = new RandomGenerator<int>(10, 20, seed: 42);

		for (int i = 0; i < 100; i++)
		{
			Assert.Equal(gen1.NextNumber, gen2.NextNumber);
		}
	}
	[Fact]
	public void DifferentRandomGenerator_WithDifferentSeeds_ReturnsDifferentSequence()
	{
		var gen1 = new RandomGenerator<int>(10, 20, seed: 1);
		var gen2 = new RandomGenerator<int>(10, 20, seed: 2);

		var seq1 = Enumerable.Range(0, 20).Select(_ => gen1.NextNumber).ToArray();
		var seq2 = Enumerable.Range(0, 20).Select(_ => gen2.NextNumber).ToArray();

		Assert.NotEqual(seq1, seq2);
	}
}