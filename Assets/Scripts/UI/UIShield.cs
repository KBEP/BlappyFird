using System;
using UnityEngine;

public class UIShield : MonoBehaviour
{
	Canvas canvas;

	//make sure to call this method in an inherited method--------------------------------------------------------------!!!
	protected virtual void Awake ()
	{
		if (!TryGetComponent<Canvas>(out canvas))
		  throw new Exception($"Required component '{nameof(Canvas)}' does not exist.");
	}

	public virtual void Open ()
	{
		canvas.enabled = true;
	}

	public virtual void Close ()
	{
		canvas.enabled = false;
	}
}
