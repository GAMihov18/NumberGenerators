using NumberGenerators;

namespace Tests;

public class ConstantGeneratorTests
{
	[Fact]
	public void ConstantGenerator_ShouldAlwaysReturnSameValue()
	{
		var gen1 = new ConstantGenerator<int>(1);
		Assert.Equal(gen1.NextNumber, gen1.NextNumber);
	}
	
	[Fact]
	public void ConstantGenerator_ShouldAlwaysReturnInitialisedValue()
	{
		var gen1 = new ConstantGenerator<int>(1);
		Assert.Equal(1, gen1.NextNumber);
	}
}