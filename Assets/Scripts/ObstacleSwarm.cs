using UnityEngine;

// создаёт и контролирует препятствия
public sealed class ObstacleSwarm : MonoBehaviour
{
	// визуально задаёт "расстояние" между припятствиями
	float spawnDelay = 2.0f;

	// время когда нужно создать следующее препятствие
	float timeToSpawn;

	// генератор случайных позиций для препятствий,
	// числа подобраны вручную с учётом необходимого визуального представления
	PositionGenerator posGen = new PositionGenerator(16.0f, 5.0f, 10.0f);

	// все созданные препятствия добавляем сюда, чтобы можно было разом их удалить
	Transform obstacleCollector;

	void Awake ()
	{
		enabled = false;
		obstacleCollector = new GameObject("ObstacleCollector").transform;
	}

	void OnEnable ()
	{
		timeToSpawn = Time.time;
	}

	// с заданным интервалом создаёт очередное препятствие в случайной позиции
	void Update ()
	{
		if (Time.time >= timeToSpawn)
		{
			Spawner.Spawn("Prefabs/Obstacle", posGen.GenRandom(), obstacleCollector);
			timeToSpawn = Time.time + spawnDelay;
		}
	}

	public void CleanUp ()
	{
		obstacleCollector?.DestroyChildren();
	}

	// вспомогательный класс для генерации случайных позиций для препятствий
	class PositionGenerator
	{
		float startX;
		FloatRange startY;

		public PositionGenerator (float startX, float startYmin, float startYmax)
		{
			this.startX = float.IsFinite(startX) ? startX : 0.0f;
			this.startY = new FloatRange(startYmin, startYmax);
		}

		public Vector3 GenRandom ()
		{
			float y = startY.GenRandom();
			// случайным образом препятствие будет либо снизу, либо сверху
			if (UnityEngine.Random.Range(0.0f, 1.0f) >  0.5f) y = -y;
			return new Vector3(startX, y, 0.0f);
		}
	}
}
