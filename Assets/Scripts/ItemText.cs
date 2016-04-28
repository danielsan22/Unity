using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemText : MonoBehaviour {

	public string description;
	private int time;
	Text descriptionGO;

	// Use this for initialization
	void Start () {		
		time = 50;
		GetComponentInChildren<TextMesh>().text = description;
	}
	
	// Update is called once per frame
	void Update () {
		if (time <= 0) {
			Destroy (gameObject, .2f);
		}
		time--;
	}
}
