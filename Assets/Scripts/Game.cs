using UnityEngine;

[RequireComponent (typeof(ObstacleSwarm))]
[RequireComponent (typeof(UserInputController))]

public sealed class Game : MonoBehaviour
{
	//---настройки для теста---//

	// на сколько будет увеличиваться вертикальная скорость шарика через заданные промежутки времени
	[SerializeField] float speedUpIncrease = 0.1f;

	// задаёт промежуток времени через который вертикальная скорость шарика увеличится
	[SerializeField] float speedUpDelay = 15.0f;

	//---настройки для теста---//

	GameData gameData;
	RUN_STATE runState;
	float runStartTime;
	UIController ui;
	UserInputController inputCtr;
	ObstacleSwarm obstacleSwarm;
	Ball ball;

	void Awake ()
	{
		ui = transform.GetChildComponent<UIController>("UI");
		obstacleSwarm = GetComponent<ObstacleSwarm>();
		inputCtr = GetComponent<UserInputController>();
	}

	void Start ()
	{
		// загружаем сохраннёную игру или запускаем новую игру
		gameData = App.Saver.Load();
		if (gameData == null) gameData = new GameData(GameData.CUR_VERSION, 0);

		// события будет происходить в зависимых от ui объектах, но реагировать на них будем в этом классе
		ui.Setup(OnDifficultyChanged, PrepareRun);
		ui.OpenStartShield();
	}

	void PrepareRun ()
	{
		if (runState != RUN_STATE.STOPED) return;

		ui.CloseAll();
		inputCtr.UpButtonClick += OnUpButtonClicked;
		ball = Spawner.Spawn<Ball>("Prefabs/Ball");
		ball.Setup(App.Settings.Difficulty.speed, speedUpIncrease, speedUpDelay, EndRun);

		runState = RUN_STATE.READY;
	}

	void StartRun ()
	{
		if (runState != RUN_STATE.READY) return;

		obstacleSwarm.enabled = true;
		runStartTime = Time.time;// фиксируем начало забега
		gameData.TryCount++;

		runState = RUN_STATE.GOING;
	}

	void EndRun ()
	{
		if (runState != RUN_STATE.GOING) return;

		inputCtr.UpButtonClick -= OnUpButtonClicked;
		Destroy(ball?.gameObject);
		obstacleSwarm.CleanUp();
		obstacleSwarm.enabled = false;
		App.Saver.Save(gameData);
		ui.OpenGameOverShieled(gameData.TryCount, Time.time - runStartTime);

		runState = RUN_STATE.STOPED;
	}

	void OnDifficultyChanged (DIFFICULTY difficulty)
	{
		App.Settings.Difficulty = DifficultySettings.GetInstance(difficulty);
	}

	void OnUpButtonClicked ()
	{
		if (runState == RUN_STATE.READY)
		{
			StartRun();
			ball?.Flap();
		}
		else if (runState == RUN_STATE.GOING)
		{
			ball?.Flap();
		}
	}
}
