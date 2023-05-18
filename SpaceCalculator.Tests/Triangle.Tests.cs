using System;
using Xunit;

namespace SpaceCalculator.Tests
{
	public class TriangleTests
	{
		[Theory]
		[InlineData(3, 4, 0)]
		[InlineData(4, 5, -1)]
		[InlineData(-4, -3, 5)]
		public void TestNegativeOrZeroEdgeConstruction(double firstEdge, double secondEdge, double thirdEdge)
		{
			Assert.Throws<ArgumentException>(() => new Triangle(firstEdge, secondEdge, thirdEdge));
		}

		[Theory]
		[InlineData(3, 4, 9)]
		[InlineData(4, 5, 1)]
		public void TestInappropriateEdgesConstruction(double firstEdge, double secondEdge, double thirdEdge)
		{
			Assert.Throws<ArgumentException>(() => new Triangle(firstEdge, secondEdge, thirdEdge));
		}

		[Theory]
		[InlineData(3, 4, 5, 6, 0)]
		[InlineData(7, 4, 4.06, 7, 0)]
		[InlineData(15, 20, 11.04, 81.7, 1)]
		[InlineData(0.2, 0.7, 0.65, 0.06, 2)]
		public void TestGetSpace(double firstEdge, double secondEdge, double thirdEdge, double expectedResult, int precision)
		{
			var triangle = new Triangle(firstEdge, secondEdge, thirdEdge);
			var space = triangle.GetSpace();
			Assert.Equal(expectedResult, space, precision);
		}

		[Theory]
		[InlineData(3, 4, 5, true)]
		[InlineData(6, 8, 10, true)]
		[InlineData(7, 4, 4.06, false)]
		[InlineData(15, 20, 11.04, false)]
		public void TestIsRectangular(double firstEdge, double secondEdge, double thirdEdge, bool expectedResult)
		{
			var triangle = new Triangle(firstEdge, secondEdge, thirdEdge);
			var isRectangular = triangle.IsRectangular(1e-10);
			Assert.Equal(expectedResult, isRectangular);
		}

		[Theory]
		[InlineData(-1e-10)]
		[InlineData(-1e-5)]
		public void TestBadInputIsRectangular(double epsilon)
		{
			var triangle = new Triangle(3, 4, 5);
			Assert.Throws<ArgumentException>(() => triangle.IsRectangular(epsilon));
		}
	}
}
