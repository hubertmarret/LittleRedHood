using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public GameObject target;
    public float rotateSpeed = 5;

    public float MAXHEIGHT = 10.0f;
    public float MINHEIGHT = 0.0f;

    void LateUpdate()
    {
        transform.RotateAround(target.transform.position, transform.up, -Input.GetAxis("Mouse X") * rotateSpeed);

        float verticalRotation = -Input.GetAxis("Mouse Y") * rotateSpeed;

        transform.RotateAround(target.transform.position, transform.right, verticalRotation);

        transform.LookAt(target.transform);
    }
}
