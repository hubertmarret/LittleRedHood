using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour {

    [SerializeField]
    private AudioSource playerAudio;
    [SerializeField]
    private AudioClip walkingSound;
    [SerializeField]
    private AudioSource[] audioSources;
    [SerializeField]
    private AudioClip[] randomNightSounds;
    [SerializeField]
    private float nightSoundProbability = 0.08f;

    private Player player;

	// Use this for initialization
	void Start () {
        if (playerAudio == null)
        {
            Debug.Log("Please add the PlayerAudio object (with an audio source component) to the player and reference it here.");
        }
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (player.walking == true && playerAudio.isPlaying == false)
        {
            playerAudio.clip = walkingSound;
            playerAudio.Play();
        } 
        if (player.walking == false && playerAudio.isPlaying == true)
        {
            playerAudio.Pause();
        }

        foreach(AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying == false)
            {
                if (Random.Range(0f, 1f) < nightSoundProbability * Time.deltaTime)
                {
                    audioSource.PlayOneShot(randomNightSounds[Random.Range(0, randomNightSounds.Length)], Random.Range(0.3f, 0.8f));
                }
            }
        }
	}
    
}
