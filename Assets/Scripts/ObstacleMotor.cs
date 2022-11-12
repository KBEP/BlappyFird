using UnityEngine;

public sealed class ObstacleMotor : MonoBehaviour
{
	// реверсированная горизонтальная скорость шарика, который технически горизонтально не двигается
	// вместо этого препятствие двигается в сторону шарика
	static float reversedSpeed = -3.0f;

	void Update ()
	{
		Vector3 motion = new Vector3(reversedSpeed * Time.deltaTime, 0.0f, 0.0f);
		transform.Translate(motion, Space.Self);
	}
}
