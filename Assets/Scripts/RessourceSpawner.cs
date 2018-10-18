using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourceSpawner : MonoBehaviour {

    public GameObject orbPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("space"))
        {
            float x = Random.Range(-30.0f, 30.0f);
            float z = Random.Range(-15.0f, 30.0f);
            GameObject orb = Instantiate(orbPrefab);
            orb.transform.position = new Vector3(x, orb.transform.position.y, z);
        }
	}
}
