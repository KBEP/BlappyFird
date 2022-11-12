using System;
using System.Collections.Generic;

// обеспечивает трансляцию значения перчисления DIFFICULTY в читаемое представление
public sealed class Localizer
{
	// количество элементов д. б. равно количеству значений DIFFICULTY
	string[] difficulties =
	{
		"лёгкая",
		"нормальная",
		"сложная"
	};

	public Localizer ()
	{
		//защита, если в перечисление DIFFICULTY была добавлена новая сложность,
		// но не было добавлено соответствующее значение в массив difficulties
		if (difficulties.Length < Enum.GetNames(typeof(DIFFICULTY)).Length)
		  throw new Exception("Not all difficulty settings are defined.");
	}

	public string this [DIFFICULTY difficulty] => difficulties[(int)difficulty];

	public List<string> GenDifficultiesNames ()
	{
		return new List<string>(difficulties);
	}
}
