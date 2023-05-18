using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceCalculator
{
	public class Circle : Shape
	{
		public double Radius { get; }
		public Circle(double radius)
		{
			if (radius < 0)
				throw new ArgumentException("The radius is less than 0");
			Radius = radius;
		}
		public override double GetSpace()
		{
			return Math.PI * Radius * Radius;
		}
	}
}
