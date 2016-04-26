using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public Sprite openDoor;
	public Sprite closedDoor;
	private int x = 1000;
	private SpriteRenderer sr;
	public bool isOpen;


	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();	
		isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.F)) {			
			GameObject.Find ("Door").GetComponent<Door>().isOpen = true;
		}
		if (isOpen) {
			sr.sprite = openDoor;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Trigger Door");
		if (other.gameObject.tag == "Player" & !isOpen) {
			Debug.Log ("Puerta Cerrada");	
		} else if (other.gameObject.tag == "Player" & isOpen){
			Debug.Log ("Puerta Abierta");	
			GameObject.Find ("Master").GetComponent<MasterCreator>().ChangeLevel();


		}
	}


}
