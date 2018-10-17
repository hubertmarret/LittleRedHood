using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float mouvementSpeed = 5;
    public float rotationSpeed = 10;
    public GameObject playerCamera;

    private bool walking;
    private Animator animator;

    private int frameCount;

    void Start()
    {
        frameCount = 0;

        walking = false;
        animator = GetComponentInChildren<Animator>();
    }

    void Move()
    {
        if (Input.GetKey("z"))
        {
            Vector3 worldCamPosition = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z);
            Quaternion worldCamRotation = new Quaternion(playerCamera.transform.rotation.x, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z, playerCamera.transform.rotation.w);

            Vector3 vecCam = playerCamera.transform.forward;
            vecCam.y = 0;
            vecCam = vecCam.normalized;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vecCam), rotationSpeed * Time.deltaTime);

            playerCamera.transform.position = worldCamPosition;
            playerCamera.transform.rotation = worldCamRotation;

            transform.position += vecCam * mouvementSpeed * Time.deltaTime;

            walking = true;
        }

        if (Input.GetKey("s"))
        {
            Vector3 worldCamPosition = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z);
            Quaternion worldCamRotation = new Quaternion(playerCamera.transform.rotation.x, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z, playerCamera.transform.rotation.w);

            Vector3 vecCam = playerCamera.transform.forward;
            vecCam.y = 0;
            vecCam = vecCam.normalized * (-1);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vecCam), rotationSpeed * Time.deltaTime);

            playerCamera.transform.position = worldCamPosition;
            playerCamera.transform.rotation = worldCamRotation;

            transform.position += vecCam * mouvementSpeed * Time.deltaTime;

            walking = true;
        }

        if (Input.GetKey("d"))
        {
            Vector3 worldCamPosition = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z);
            Quaternion worldCamRotation = new Quaternion(playerCamera.transform.rotation.x, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z, playerCamera.transform.rotation.w);

            Vector3 vecCam = playerCamera.transform.right;
            vecCam.y = 0;
            vecCam = vecCam.normalized;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vecCam), rotationSpeed * Time.deltaTime);

            playerCamera.transform.position = worldCamPosition;
            playerCamera.transform.rotation = worldCamRotation;

            transform.position += vecCam * mouvementSpeed * Time.deltaTime;

            walking = true;
        }

        if (Input.GetKey("q"))
        {
            Vector3 worldCamPosition = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, playerCamera.transform.position.z);
            Quaternion worldCamRotation = new Quaternion(playerCamera.transform.rotation.x, playerCamera.transform.rotation.y, playerCamera.transform.rotation.z, playerCamera.transform.rotation.w);

            Vector3 vecCam = playerCamera.transform.right;
            vecCam.y = 0;
            vecCam = vecCam.normalized * (-1);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(vecCam), rotationSpeed * Time.deltaTime);

            playerCamera.transform.position = worldCamPosition;
            playerCamera.transform.rotation = worldCamRotation;

            transform.position += vecCam * mouvementSpeed * Time.deltaTime;

            walking = true;
        }

        if (Input.GetKeyUp("z") || Input.GetKeyUp("q") || Input.GetKeyUp("s") || Input.GetKeyUp("d"))
        {
            walking = false;
            animator.SetBool("Walk", false);
        }
    }

	void Update () {
        
        Move();

        if (walking) {
            animator.SetBool("Walk", true);
        }
        else
        {
            frameCount += 1;

            if (frameCount % 200 == 0)
            {
                int randAnim = Random.Range(0, 4);
                animator.SetInteger("IdleSelector", randAnim);
            }
        }
    }
}
