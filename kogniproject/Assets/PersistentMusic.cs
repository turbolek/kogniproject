using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentMusic : MonoBehaviour {

    private AudioSource audioSource;

    public AudioClip[] audioClips;

    public static PersistentMusic instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        AudioClip clip = SceneManager.GetActiveScene().name == "Main" ? audioClips[1] : audioClips[0];
        if (!audioSource.isPlaying || audioSource.clip != clip)
        {         
            audioSource.clip = clip;
            audioSource.Play();
        }
	}
}
