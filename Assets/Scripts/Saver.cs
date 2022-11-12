using UnityEngine;

// простейший сэйвер, по компонентам хранит GameData в PlayerPrefs
public sealed class Saver
{
	public void Save (GameData gameData)
	{
		if (gameData == null) return;
		PlayerPrefs.SetInt("app_version", gameData.Version);
		PlayerPrefs.SetInt("app_try_count", gameData.TryCount);
		PlayerPrefs.Save();
	}

	// если сохранённой игры нет - верёт null
	public GameData Load ()
	{
		if (!PlayerPrefs.HasKey("app_version") || !PlayerPrefs.HasKey("app_try_count")) return null;
		return new GameData(PlayerPrefs.GetInt("app_version"), PlayerPrefs.GetInt("app_try_count"));
	}
}
