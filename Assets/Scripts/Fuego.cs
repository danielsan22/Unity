using UnityEngine;
using System.Collections;

public class Fuego : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Trigger FUEGO");
		if (other.gameObject.tag == "Player") {
			GameObject player = GameObject.Find ("Player");
			player.GetComponent<Player> ().curHealth = player.GetComponent<Player> ().curHealth - 30;
		}
	}
}