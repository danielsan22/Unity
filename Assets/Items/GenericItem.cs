using UnityEngine;
using System.Collections;

public class GenericItem : MonoBehaviour {



	public int maxHealth;
	public int health;
	public int speed;
	public int damage;
	public int speedShot;
	public int range;
	public string descripcion;



	public GameObject letrero;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("Trigger Item");
		if (other.gameObject.tag == "Player") {
			Vector3 v3 = new Vector3 (-2.55f, 3f, -1f);
			GameObject shotClone = (GameObject)Instantiate (letrero, v3, Quaternion.identity);
			shotClone.GetComponent<ItemText> ().description = descripcion;

			//		shotClone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (playerPos.position.x * shotSpeed * shootDirection, playerPos.position.y * shotSpeed);
		} 
	}
}
