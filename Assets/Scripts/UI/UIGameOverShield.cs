using System;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public sealed class UIGameOverShield : UIShield
{
	TextMeshProUGUI time_Value;
	TextMeshProUGUI tryCount_Value;
	UIDifficultyDropdown difficultyDropdown;
	Button tryAgain;

	protected override void Awake ()
	{
		base.Awake();
		time_Value = transform.GetChildComponent<TextMeshProUGUI>("Time/Value");
		tryCount_Value = transform.GetChildComponent<TextMeshProUGUI>("TryCount/Value");
		difficultyDropdown = transform.GetChildComponent<UIDifficultyDropdown>("Difficulty/Dropdown");
		tryAgain = transform.GetChildComponent<Button>("TryAgain");
	}

	public void Open (int tryCount, float lastRunDuration)
	{
		time_Value.text = TimeSpan.FromSeconds(lastRunDuration).ToString(@"hh\:mm\:ss");
		tryCount_Value.text = tryCount.ToString();
		difficultyDropdown.Refresh();
		base.Open();
	}

	public void Setup (Action<DIFFICULTY> onValueChanged,
	  UnityAction onStartClicked)
	{
		difficultyDropdown.Setup(onValueChanged);
		tryAgain.onClick.AddListener(onStartClicked);
	}
}
