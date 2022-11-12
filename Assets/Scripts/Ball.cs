using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public sealed class Ball : MonoBehaviour
{
	const float BASE_FLAP_FORCE = 10.0f;

	float speed;
	bool firstFlap;
	float speedUpIncrease = 0.1f;
	WaitForSeconds speedUpDelay = new WaitForSeconds(15.0f);
	Rigidbody rigidBody;

	public event Action OnCollide;

	public float Speed
	{
		get => speed;
		set => speed = value > 0.0f ? value : 0.0f;
	}

	void Awake ()
	{
		rigidBody = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.CompareTag("Obstacle") && OnCollide != null) OnCollide();
	}

	public void Setup (float startSpeed, float speedUpIncrease, float speedUpDelay, Action onCollided)
	{
		this.speed = startSpeed > 0.0f ? startSpeed : 0.0f;
		this.speedUpIncrease = speedUpIncrease > 0.0f ? speedUpIncrease : 0.0f;
		this.speedUpDelay = new WaitForSeconds(speedUpDelay > 0.0f ? speedUpDelay : 0.0f);
		OnCollide += onCollided;
		rigidBody.useGravity = false;
		firstFlap = true;
	}

	public void Flap ()
	{
		if (firstFlap)
		{
			rigidBody.useGravity = true;
			StartCoroutine(CrtSpeedUp());
			firstFlap = false;
		}
		rigidBody.AddForce(new Vector3(0.0f, BASE_FLAP_FORCE * speed, 0.0f), ForceMode.VelocityChange);
	}

	// увеличивает скорость шарика через каждые speedUpDelay секунд
	IEnumerator CrtSpeedUp ()
	{
		for (;;)
		{
			yield return speedUpDelay;
			speed += speedUpIncrease;
		}
	}
}
