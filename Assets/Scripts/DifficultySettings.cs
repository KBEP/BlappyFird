using System;

public sealed class DifficultySettings
{	
	// количество элементов д. б. равно количеству значений DIFFICULTY
	static readonly DifficultySettings[] all =
	{
		new DifficultySettings(DIFFICULTY.EASY  , 0.50f),
		new DifficultySettings(DIFFICULTY.NORMAL, 0.75f),
		new DifficultySettings(DIFFICULTY.HARD  , 1.00f)
	};

	public readonly DIFFICULTY difficulty;
	public readonly float speed;

	static DifficultySettings ()
	{
		//защита, если в перечисление DIFFICULTY была добавлена новая сложность,
		// но не было добавлено соответствующее значение в массив all
		if (all.Length < Enum.GetNames(typeof(DIFFICULTY)).Length)
		  throw new Exception("Not all difficulty settings are defined.");
	}

	DifficultySettings (DIFFICULTY difficulty, float speed)
	{
		this.difficulty = difficulty;
		this.speed = speed > 0.0f ? speed : 0.0f;
	}

	public static DifficultySettings GetInstance (DIFFICULTY difficulty) => all[(int)difficulty];
}
