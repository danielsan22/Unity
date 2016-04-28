using UnityEngine;
using System.Collections;

public class BossSpawner : MonoBehaviour {


	public GameObject[] enemy;
	public GameObject[] health;
	private int spawnZonesCount;
	public float width 		= 12;
	public float height 	= 7;

	private float speed = 5;
	//private float selfWidth;

	int maxLeftPos = -10;
	int maxRigthPos = 6;

	float leftLimit;
	float rightLimit;
	public int enemyCount;



	// Use this for initialization
	void Start () {
		GetChildObjects ();
		//		int enemyIndex = Random.Range (0, spawnZonesCount);
		//selfWidth = this.width/2;
		//Debug.Log (transform.childCount);
		int x = Random.Range(0,2);
		for (int i = 0; i < spawnZonesCount; i++) {							
			GameObject enemyClone = (GameObject )Instantiate (enemy[x], transform.GetChild(i).position,Quaternion.identity);
			GameObject ht = (GameObject )Instantiate (health[x], transform.GetChild(i).position,Quaternion.identity);
			enemyClone.transform.parent = this.transform;
			ht.transform.parent = this.transform;
		}
		enemyCount = spawnZonesCount;
		float distance = this.transform.position.z - Camera.main.transform.position.z;
		Vector3 leftfMost = Camera.main.ViewportToWorldPoint (new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3(1,0,distance));
		maxLeftPos = (int)leftfMost.x;
		maxRigthPos = (int)rightMost.x;
	}

	// Update is called once per frame
	void Update () {

		if (enemyCount <= 0) {
			GameObject.Find ("Door").GetComponent<Door>().isOpen = true;
		}


	}

	void GetChildObjects(){
		foreach (Transform child in transform) {
			if (child.tag == "SpawnZone") {
				spawnZonesCount++;
			}
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (this.transform.position,new Vector3(width, height, 0));
	}
}
