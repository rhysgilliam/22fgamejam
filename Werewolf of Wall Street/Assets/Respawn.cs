using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
	public float respawnTime = 10f;
	public GameObject guy;
	float timeElapsed = 0f;
	Transform trans;
	GameObject gameObj;
	bool spawnedOneGuy = false;

	void Start()
	{
		gameObj = GetComponent<GameObject>();
		trans = GetComponent<Transform>();
	}

	void FixedUpdate()
	{
		if (timeElapsed < respawnTime)
		{
			timeElapsed += Time.deltaTime;
		}
		else if (!spawnedOneGuy)
		{
			Object.Instantiate(guy, trans.position, Quaternion.identity);
			spawnedOneGuy = true;
			Object.Destroy(gameObj);
		}
	}
}
