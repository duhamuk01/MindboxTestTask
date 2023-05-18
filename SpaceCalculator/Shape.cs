using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceCalculator
{
	//Если-бы мир ограничивался нашей задачей то тогда конечно лучше использовать интерфейс, т.к. меньше связанность
	//Но если представить что мир задачи дальше будет как-то развиваться то абстрактный класс мне кажется
	//более логичным, т.к. у фигур может быть какаято общая логика/данные
	public abstract class Shape
	{
		public abstract double GetSpace();
	}
}
