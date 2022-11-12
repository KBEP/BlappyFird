using System;
using UnityEngine;
using UnityEngine.Events;

// управляет всем UI, выполняет первоначальную настройку всех зависимых компонентов
public sealed class UIController : MonoBehaviour
{
	UIStartShield startShield;
	UIGameOverShield gameOverShield;

	void Awake ()
	{
		startShield = transform.GetChildComponent<UIStartShield>("StartShield");
		gameOverShield = transform.GetChildComponent<UIGameOverShield>("GameOverShield");
	}

	public void Setup (Action<DIFFICULTY> onDifficultyValueChanged, UnityAction onStartButtonClicked)
	{
		startShield.Setup(onDifficultyValueChanged, onStartButtonClicked);
		gameOverShield.Setup(onDifficultyValueChanged, onStartButtonClicked);
	}

	public void OpenStartShield ()
	{
		CloseAll();
		startShield.Open();
	}

	public void OpenGameOverShieled (int tryCount, float lastRunDuration)
	{
		CloseAll();
		gameOverShield.Open(tryCount, lastRunDuration);
	}

	public void CloseAll ()
	{
		startShield.Close();
		gameOverShield.Close();
	}
}
