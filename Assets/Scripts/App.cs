public static class App
{
	static Settings settings = Settings.Default;
	static Localizer localizer = new Localizer();
	static Saver saver = new Saver();

	public static Settings Settings
	{
		get => settings;
		set => settings = value ?? Settings.Default;
	}

	public static Localizer Localizer => localizer;

	public static Saver Saver => saver;
}
