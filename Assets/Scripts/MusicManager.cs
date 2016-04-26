using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {


	public AudioClip[] musicArray;
	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad (gameObject);

	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnLevelWasLoaded(int level){
		AudioClip music = musicArray[level];

		if (music) {
			Debug.Log ("Playing clip:"+music);
			audioSource.clip = music;
			audioSource.loop = true;
			audioSource.Play ();
		}
	
	}
	public void ChangeVolume(float volume){
		audioSource.volume = volume;		
	}

}
