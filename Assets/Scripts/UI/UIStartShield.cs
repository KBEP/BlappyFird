using System;
using UnityEngine.Events;
using UnityEngine.UI;

public sealed class UIStartShield : UIShield
{
	UIDifficultyDropdown difficultyDropdown;
	Button start;

	protected override void Awake ()
	{
		base.Awake();
		difficultyDropdown = transform.GetChildComponent<UIDifficultyDropdown>("Difficulty/Dropdown");
		start = transform.GetChildComponent<Button>("Start");
	}

	public override void Open ()
	{
		difficultyDropdown.Refresh();
		base.Open();
	}

	public void Setup (Action<DIFFICULTY> onValueChanged, UnityAction onStartClicked)
	{
		difficultyDropdown.Setup(onValueChanged);
		start.onClick.AddUniqueListener(onStartClicked);
	}
}
