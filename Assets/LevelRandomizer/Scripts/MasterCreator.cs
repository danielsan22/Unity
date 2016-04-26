using UnityEngine;
using System.Collections;

public class MasterCreator : MonoBehaviour {


	public static string[] levels;
	public static int levelCounter = 0;


	void Awake(){
		DontDestroyOnLoad (gameObject);
	}
	// Use this for initialization
	void Start () {
		RandomizeLevels ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.T)) {
			if (CanChangeScene ()) {
				LevelManager lv = new LevelManager ();
				lv.LoadLevel (levels [levelCounter]);		
				levelCounter++;
				Debug.Log ("Counter" + levelCounter);
			}


		}

	
	}
	public void ChangeLevel(){
		if (CanChangeScene ()) {
			LevelManager lv = new LevelManager ();
			lv.LoadLevel (levels [levelCounter]);		
			levelCounter++;
			Debug.Log ("Counter" + levelCounter);
		}
	}


	private void RandomizeLevels(){
		levels = new string[7];
		for (int i = 0; i < 7; i++) {
			int x = Random.Range (1, 10);
			levels [i] = "Level0" + x;
			//Debug.Log ("pos"+i+":"+levels [i]);
		}



		
	
	}

	private bool CanChangeScene(){
		if (levelCounter < levels.Length) {
			return true;
		}else{
			return false;
		}


	 
	}


}
