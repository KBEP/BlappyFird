using System;
using UnityEngine;

public static class Spawner
{
	// спавнит префаб в заданной позиции
	public static GameObject Spawn (string prefabPath, Vector3 position = default, Transform parent = default)
	{
		GameObject prefab = Resources.Load<GameObject>(prefabPath);
		if (prefab == null) throw new Exception($"Prefab '{prefabPath}' not found.");
		return GameObject.Instantiate<GameObject>(prefab, position, Quaternion.identity, parent);
	}

	// спавнит префаб в заданной позиции, ищет в нём компонент T и возвращает его
	public static T Spawn<T> (string prefabPath, Vector3 position = default,
	  Transform parent = default) where T : Component
	{
		GameObject instance = Spawn(prefabPath);
		return instance ? instance.GetComponent<T>() : default;
	}
}
