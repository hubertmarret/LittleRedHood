using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 0.5f;

 

    void Move()
    {
        if(Input.GetKey("z"))
        {
            transform.Translate(Vector3.forward * speed);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * speed);
        }
        if (Input.GetKey("q"))
        {
            transform.Translate(Vector3.left * speed);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * speed);
        }
    }


	void Update () {

        Move();
    }
}
