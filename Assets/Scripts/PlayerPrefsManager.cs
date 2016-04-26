using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";


	public static void SetMasterVolume(float volume){
	
		if (volume >= 0 && volume <= 1) {
			//SetVolume

			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Volume out of range");
		}

	}

	public static float GetMasterVolume(){

		return PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
	
	}

	public static void UnlockLevel(int level){
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(),1);
		} else {
			Debug.LogError ("Level out of range");
		}
	}

	public static bool IsLevelUnlocked(int level){
	
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString ());

		bool isLevelLoaded = (levelValue == 1);

		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			return isLevelLoaded;
		} else {
			Debug.LogError ("Level is not valid");
			return false;
		}
	}

	public static void SetDifficulty(int diff){
		if (diff >= 1 && diff <= 3) {
			PlayerPrefs.SetInt (DIFFICULTY_KEY, diff);
		} else {
			Debug.LogError ("Difficulty out of range");
		}
	}

	public static int GetDifficulty(){
		return PlayerPrefs.GetInt (DIFFICULTY_KEY);
	}

}


