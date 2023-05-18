using System;
using Xunit;

namespace SpaceCalculator.Tests
{
	public class CircleTests
	{
		[Theory]
		[InlineData(-1)]
		[InlineData(-3.5)]
		public void TestInvalidConstruction(double radius)
		{
			Assert.Throws<ArgumentException>(() => new Circle(radius));
		}

		[Theory]
		[InlineData(0, 0, 0)]
		[InlineData(0.3, 0.2826, 3)]
		[InlineData(1, 3.14, 2)]
		[InlineData(3.5, 38.485, 2)]
		[InlineData(533, 892492, 0)]
		public void TestGetSpace(double radius, double expectedResult, int precision)
		{
			var circle = new Circle(radius);
			var space = circle.GetSpace();
			Assert.Equal(expectedResult, space, precision);
		}
	}
}
