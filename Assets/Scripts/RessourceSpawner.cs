using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceSpawner : MonoBehaviour {

    public GameObject orbPrefab;

    public float lightPowerToSpawn = 7;
    public int nbOrbsToSpawn = 1;
    public float distanceFromPlayer = 20;

    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerPos = player.transform.position;

        //if(player.GetComponent<LanternLightManager>().currentLight == 7)
		if(Input.GetKeyUp("space"))
        {
            for (int i = 0; i < nbOrbsToSpawn; ++i)
            {
                int multiplier = (Random.Range(1, 2) * 2) - 3;
                float randX = Random.Range(distanceFromPlayer - 10, distanceFromPlayer + 10) * multiplier;
                float randZ = Random.Range(distanceFromPlayer - 10, distanceFromPlayer + 10) * multiplier;
                
                GameObject orb = Instantiate(orbPrefab);
                orb.transform.position = new Vector3(orb.transform.position.x + randX, orb.transform.position.y, orb.transform.position.z + randZ);
            }
        }
	}
}
