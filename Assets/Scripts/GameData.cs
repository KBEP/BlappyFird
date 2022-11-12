// хранит данные об игре (как процесса, а не приложения), фактически это данные для сэйва
public sealed class GameData
{
	public const int CUR_VERSION = 0;

	int version;
	int tryCount;

	public int Version
	{
		get => version;
		set => version = value > 0 ? value : 0;
	}

	public int TryCount
	{
		get => tryCount;
		set => tryCount = value > 0 ? value : 0;
	}

	public GameData (int version, int tryCount)
	{
		Version = version;
		TryCount = tryCount;
	}
}
