using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMove : MonoBehaviour {

    public float wanderingSpeed = 5f;
    public float runningSpeed = 10f;
    private Vector3 targetPosition;

    public bool seePlayer = false;
    public GameObject player;

    public float blindMoveTime = 10.0f;
    private float curBlindMoveTime;

    public WolfCam wolfCam;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        wolfCam = GetComponent<WolfCam>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		if (wolfCam.visibility > 0)
        {
            seePlayer = true;
            curBlindMoveTime = blindMoveTime;
            targetPosition = player.transform.position;
        } else
        {
            seePlayer = false;
            curBlindMoveTime -= Time.deltaTime;
        }

        if (curBlindMoveTime > 0)
        {
            MoveStraightLine();
        }
        
	}

    public void MoveRandom()
    {

    }

    public void MoveStraightLine()
    {
        transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
    }
}
