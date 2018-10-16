using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RessourcePickup : MonoBehaviour {

    public LanternLightManager lanternLightManager;
    public float ressourceValue = 5f;

    public Camera mainCamera;

	// Use this for initialization
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
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] _results = Physics.RaycastAll(_ray);

            foreach(RaycastHit _result in _results)
            {
                if (_result.transform.gameObject.CompareTag("LanternRessource"))
                {
                    PickupRessource(_result.transform.gameObject);
                    return;
                }
            }
        }
    }

    public void PickupRessource(GameObject _ressource)
    {
        Destroy(_ressource);
        lanternLightManager.currentLight = Mathf.Max(lanternLightManager.lightMax, lanternLightManager.currentLight + ressourceValue);
    }
}
