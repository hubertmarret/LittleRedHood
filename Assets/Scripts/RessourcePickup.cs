using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RessourcePickup : MonoBehaviour {

    public LanternLightManager lanternLightManager;
    public float ressourceValue = 10f;

    public Camera mainCamera;

	void Start () {
		if (lanternLightManager == null)
        {
            Debug.Log("Please reference the lantern light manager script");
        }
        if (Camera.main == null && mainCamera == null)
        {
            Debug.Log("No camera found. Please tag your camera as mainCamera or set a camera for this script in the editor");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LanternRessource"))
        {
            PickupRessource(other.gameObject);
        }
    }

    public void PickupRessource(GameObject _ressource)
    {
        Destroy(_ressource);
        lanternLightManager.targetedLight = Mathf.Min(lanternLightManager.lightMax, lanternLightManager.targetedLight + ressourceValue);
    }
}
