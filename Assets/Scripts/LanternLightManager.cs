using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternLightManager : MonoBehaviour {

    public float lightSpeedFactor = 1f;
    public float lightMax = 20f;
    public float currentLight = 20f;
    public new Light light;

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        currentLight = currentLight - lightSpeedFactor * Time.deltaTime;
        light.range = currentLight;
	}
}
