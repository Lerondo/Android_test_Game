using UnityEngine;
using System.Collections;

public class ObstacleSpawner : MonoBehaviour {

	private float spawnTime = 2;
	private float curSpawnTime;
	public GameObject[] obstaclePrefabs;
	private GameObject[] obstsOnField;

	private int index;

	void Start()
	{
		obstsOnField = GameObject.FindGameObjectsWithTag("Obstacle");

		curSpawnTime = spawnTime;
		StartCoroutine("Spawn", spawnTime);
	}

	void Update()
	{
//		foreach(GameObject prefab in obstsOnField)
//		{
//			spawnTime = 1000 / prefab.GetComponent<ObstacleController>().speed;
//		}

		index = Random.Range(0, obstaclePrefabs.Length);

		curSpawnTime -= Time.deltaTime;

		if(curSpawnTime <= 0)
		{
			curSpawnTime = spawnTime;
			SpawnFunction();
		}
	}

	void SpawnFunction()
	{
		StartCoroutine("Spawn", spawnTime);
	}

	IEnumerator Spawn(float _spawnTime)
	{
		Instantiate(obstaclePrefabs[index], this.transform.position, this.transform.rotation);
		yield return new WaitForSeconds(_spawnTime);
	}
}