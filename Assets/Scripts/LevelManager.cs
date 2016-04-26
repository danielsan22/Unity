using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float loadNextLevelAfter = 3;
	void Start(){
		if (loadNextLevelAfter > 0) {
			Invoke ("LoadNextLevel", loadNextLevelAfter);
		}

	}

	public void LoadLevel(string lvl){
		Debug.Log ("Loading level " + lvl);

		SceneManager.LoadScene (lvl);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested!");		
	}
	public void LoadNextLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
		
}
