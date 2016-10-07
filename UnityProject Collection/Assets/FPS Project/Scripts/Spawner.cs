using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


	public Nucleon [] Nucleons;

	public float spawnDistance;

	public float timeBetweenSpawns;

	public float timeSinceLastSpawn;
	void Start () {
		
	}

	void FixedUpdate(){
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn > timeBetweenSpawns) {
			timeSinceLastSpawn -= timeBetweenSpawns;
			SpawnNucleon ();
		}
	}

	void SpawnNucleon(){
		Nucleon prefab = Nucleons[Random.Range(0, Nucleons.Length)];
		Nucleon spawn = Instantiate<Nucleon> (prefab);
		spawn.transform.localPosition = Random.onUnitSphere * spawnDistance * 3;
	}
}
