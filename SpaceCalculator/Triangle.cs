using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceCalculator
{
	public class Triangle : Shape
	{
		public double[] Edges { get; }
		public double Perimeter { get; }
		public double HalfPerimeter { get; }

		public Triangle(double firstEdge, double secondEdge, double thirdEdge)
		{
			if (firstEdge <= 0 || secondEdge <= 0 || thirdEdge <= 0)
				throw new ArgumentException("Some edges are less or equal to 0");
			if (!(firstEdge + secondEdge > thirdEdge && firstEdge + thirdEdge > secondEdge &&
					secondEdge + thirdEdge > firstEdge))
				throw new ArgumentException("Provided edges dont form a triangle");
			Edges = new double[3] { firstEdge, secondEdge, thirdEdge };
			Array.Sort(Edges);
			Perimeter = Edges.Sum();
			HalfPerimeter = Perimeter / 2;
		}
		public override double GetSpace()
		{
			//допустим что переполнение невозможно
			return Math.Sqrt(HalfPerimeter * (HalfPerimeter - Edges[0]) * (HalfPerimeter - Edges[1]) * (HalfPerimeter - Edges[2]));
		}
		public bool IsRectangular(double epsilon)
		{
			if (epsilon < 0)
				throw new ArgumentException("The epsilon is less than 0");
			var hypotenuse = Edges[2];
			var firstLeg = Edges[0];
			var secondLeg = Edges[1];
			//допустим что переполнение невозможно
			return Math.Abs(hypotenuse * hypotenuse - firstLeg * firstLeg - secondLeg * secondLeg) < epsilon;
		}
	}
}
