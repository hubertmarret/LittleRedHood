using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMove : MonoBehaviour {

    public float wanderingSpeed = 4f;
    public float runningSpeed = 7f;
    private Vector3 targetPosition;

    public bool seePlayer = false;
    public GameObject player;

    public float blindMoveTime = 10.0f;
    private float curBlindMoveTime;

    public Animator animator;
    public WolfCam wolfCam;
    private Rigidbody rb;
    public AudioSource wolfAudio;

    public float rangeOfDetection = 60.0f;
    public float rangeForHowlTrigger = 130.0f;
    public float rangeEndOfAmbientSound = 90.0f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        wolfAudio = GetComponent<WolfAudio>().wolfFarAudio;
    }
	
	// Update is called once per frame
	void Update () {
        float _playerDistance = Vector3.Distance(transform.position, player.transform.position);
        if (wolfCam.visibility > 0 && _playerDistance < rangeOfDetection)
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
            animator.SetBool("Run", true);
        } else
        {
            animator.SetBool("Run", false);
        }

        player.GetComponent<PlayerAudio>().fadeAmbientSoundWithDistance(_playerDistance, rangeEndOfAmbientSound, rangeForHowlTrigger);
	}

    public void MoveRandom()
    {

    }

    public void MoveStraightLine()
    {
        transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            transform.position = targetPosition;
            curBlindMoveTime = 0;
        } else
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * runningSpeed);
        }
        
    }
}
