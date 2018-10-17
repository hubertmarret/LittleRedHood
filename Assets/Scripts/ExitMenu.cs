using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour {

    public GameObject exitMenuPanel;

	// Use this for initialization
	void Start () {
        if (exitMenuPanel == null)
        {
            Debug.Log("No exitMenuPanel ! Please add it in the appropriate field in the inspector, otherwise the game will lack an exit menu.");
        }
        exitMenuPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitMenuPanel.SetActive(!exitMenuPanel.activeInHierarchy);
        }
	}

    //This function should be put as the action of the "exitMenuButton"
    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
