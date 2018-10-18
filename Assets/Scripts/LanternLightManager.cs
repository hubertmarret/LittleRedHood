using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternLightManager : MonoBehaviour {

    public float lightShrinkFactor = 5f;
    public float lightMax = 10f;
    public float currentLight = 10f;
    public float lightExpandFactor = 10f;
    public float lightPercentToSpawn = 50;
    public new Light light;

    public bool spawnOrbPossible;

    private float targetedLight;

    private bool lightFading;

    // Use this for initialization
    void Start () {
        if (light == null)
        {
            Debug.Log("Please reference the gameobject that holds the lantern light.");
        }
        currentLight = lightMax;

        spawnOrbPossible = true;
        lightFading = true;
    }

    // return the radius needed to reduce the sphere volume by a linear amount
    float LinearSphereVolumeShrink(float radius, float delta)
    {
        Debug.Log(radius);
        Debug.Log(delta);
        Debug.Log((4 / 3) * Mathf.PI * radius * radius * radius);
        Debug.Log(Mathf.Pow(radius * radius * radius + (3 / 4) * Mathf.PI * delta, -3f));
        return Mathf.Pow(radius * radius * radius + (3 / (4 * Mathf.PI)) * delta, 1.0f / 3.0f);
    }

    public float GetLightPowerPercent()
    {
        return 100 * (currentLight / lightMax);
    }

    public void RefillLight(float ressourceValue)
    {
        targetedLight = Mathf.Min(lightMax, targetedLight + ressourceValue);
    }

    private void ChangeLightPower()
    {
        if (targetedLight > currentLight)
        {
            currentLight = Mathf.Min(targetedLight, currentLight + lightExpandFactor * Time.deltaTime);
        }
        if (targetedLight <= currentLight)
        {
            currentLight = Mathf.Max(0f, currentLight - lightShrinkFactor * Time.deltaTime * currentLight / lightMax);
            targetedLight = currentLight;
        }

        light.range = currentLight;
    }

    // Update is called once per frame
    void Update () {
        if(lightFading)
        {
            ChangeLightPower();
        }
        
        if(!spawnOrbPossible && GetLightPowerPercent() > lightPercentToSpawn)
        {
            spawnOrbPossible = true;
        }

        if (lightFading && currentLight < 1)
        {
            UIManager.instance.gameOverPanel.SetActive(!UIManager.instance.gameOverPanel.activeInHierarchy);
            lightFading = false;
        }
    }
}
