using UnityEngine;
using System.Collections;

[RequireComponent (typeof (BoxCollider))]

public class Spawner : MonoBehaviour {
	
	public GameObject thingToSpawn;
	public float timeBetweenSpawns = 5;
	float scheduledSpawnTime;
	

	
	// Use this for initialization
	void Start () 
	{
		this.GetComponent<Collider>().enabled = false;
		scheduledSpawnTime = Time.time + timeBetweenSpawns;
		

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Time.time > scheduledSpawnTime)
		{
			GameObject spawnedThing = (GameObject) GameObject.Instantiate(thingToSpawn);
			
			
			this.GetComponent<Collider>().enabled = true;
			Vector3 spawnPosition =  new Vector3();
			spawnPosition.z = Random.Range(this.GetComponent<Collider>().bounds.min.z, this.GetComponent<Collider>().bounds.max.z);
			spawnPosition.x = Random.Range(this.GetComponent<Collider>().bounds.max.x, this.GetComponent<Collider>().bounds.min.x);
			spawnPosition.y = Random.Range(this.GetComponent<Collider>().bounds.min.y, this.GetComponent<Collider>().bounds.max.y);
			this.GetComponent<Collider>().enabled = false;
			
			spawnedThing.transform.position = spawnPosition;
			scheduledSpawnTime = scheduledSpawnTime + timeBetweenSpawns;
		}
	}
}
