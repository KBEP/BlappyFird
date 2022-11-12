using System;
using UnityEngine;

// контролирует весь пользовательский ввод от устройств ввода,
// в текущей реализации это только физические клавиатура и мышь
public sealed class UserInputController : MonoBehaviour
{
	public event Action UpButtonClick;

	void Update ()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)
		  || Input.GetKeyDown(KeyCode.UpArrow))
		{
			UpButtonClick?.Invoke();
		}
		else if (Input.GetKeyDown(KeyCode.Escape))
		{
			#if UNITY_EDITOR
				Debug.Break();
			#else
				Application.Quit();
			#endif
		}
	}
}
