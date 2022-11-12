using UnityEngine;

public sealed class ObstacleLiveControl : MonoBehaviour
{
	bool destroy;// флаг, что препятствие должно быть уничтожено

	void OnBecameVisible ()
	{
		destroy = true;
	}

	void OnBecameInvisible ()
	{
		if (destroy) Destroy(gameObject);
	}
}
