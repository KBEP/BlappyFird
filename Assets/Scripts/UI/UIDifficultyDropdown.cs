using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public sealed class UIDifficultyDropdown : MonoBehaviour
{
	static List<string> cachedOptions;
	
	static List<string> CachedOptions
	{
		get
		{
			if (cachedOptions == null) cachedOptions = App.Localizer.GenDifficultiesNames();
			return cachedOptions;
		}
	}
	
	TMP_Dropdown dropdown;
	Action<DIFFICULTY> onValueChanged;

	void Awake ()
	{
		dropdown = GetComponent<TMP_Dropdown>();
		dropdown.onValueChanged.AddListener(OnValueChanged);
		dropdown.ClearOptions();
		dropdown.AddOptions(CachedOptions);
		dropdown.SetValueWithoutNotify((int)App.Settings.Difficulty.difficulty);
	}

	public void Setup (Action<DIFFICULTY> onValueChanged)
	{
		this.onValueChanged = onValueChanged;
	}

	public void Refresh ()
	{
		dropdown.SetValueWithoutNotify((int)App.Settings.Difficulty.difficulty);
		dropdown.RefreshShownValue();
	}

	void OnValueChanged (int value)
	{
		if (onValueChanged != null) onValueChanged((DIFFICULTY)value);
	}
}
