namespace Test;

using Xunit;
// using EmarsysBinding;

public class Test
{

	[Fact]
	public void PassingTest()
	{
		Assert.Equal(4, 2+2);
	}

	[Theory]
	[InlineData(3)]
	[InlineData(5)]
	public void MyTheoryTest(int value)
	{
		Assert.True(value % 2 == 1);
	}

}
