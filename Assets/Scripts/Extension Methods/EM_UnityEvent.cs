using UnityEngine.Events;

public static class EM_UnityEvent
{
	public static void AddUniqueListener (this UnityEvent unityEvent, UnityAction call)
	{
		unityEvent.RemoveListener(call);
		unityEvent.AddListener(call);
	}
}
