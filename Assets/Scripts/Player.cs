using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float mouvementSpeed = 20;
    public float rotationSpeed = 10;
    public GameObject playerCamera;

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
        }
    }


	void Update () {    

        Move();
    }
}
