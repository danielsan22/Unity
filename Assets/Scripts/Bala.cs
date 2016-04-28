using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	public float dmg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		Debug.Log ("BALA CHOCA");
		Destroy (gameObject);
		
	}

}
