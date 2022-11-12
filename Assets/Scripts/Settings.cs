// хранит настройки приложения (только для текущей сессии, не сохраняет данные между сессиями)
public sealed class Settings
{
	public static readonly Settings Default = new Settings(DifficultySettings.GetInstance(default)); 

	DifficultySettings difficulty;

	public DifficultySettings Difficulty
	{
		get => difficulty;
		set => difficulty = value ?? DifficultySettings.GetInstance(default);
	}

	public Settings (DifficultySettings difficulty)
	{
		Difficulty = difficulty;
	}
}
