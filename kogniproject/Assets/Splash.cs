using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        float delay;
        audioSource = FindObjectOfType<AudioSource>();
        if (audioSource != null)
        {
            delay = audioSource.clip.length;
        } else
        {
            delay = 3f;
        }
        Invoke("LoadNextLevel", delay);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
