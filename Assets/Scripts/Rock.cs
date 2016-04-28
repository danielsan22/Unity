using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	public GameObject rockParticles;
	public GameObject[] items;
	private float life;

	// Use this for initialization
	void Start () {
		
		life = 100;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (life <= 0) {
			InstantiateParticle (transform.position);
			if (Random.Range (1, 100) % 3 == 0) {
				InstantiateItem (transform.position);
			}

			Destroy (gameObject);
		}
	}

	private void InstantiateParticle(Vector3 pos){
		GameObject tmpParticles = (GameObject)Instantiate (rockParticles, pos, Quaternion.identity); //look up how to use Instantiate, you'll need it a lot
		Destroy (tmpParticles, 3f);
	}
	private void InstantiateItem(Vector3 pos){
		int randomItem = Random.Range (0, items.Length);
		GameObject tmpParticles = (GameObject)Instantiate (items[randomItem], pos, Quaternion.identity); //look up how to use Instantiate, you'll need it a lot
	}

	void OnCollisionEnter2D (Collision2D collision)
	{
		Debug.Log ("Collision roca");
		if (collision.transform.CompareTag ("Shoot")) {
			life = life - GameObject.Find ("Player").GetComponent<Player> ().damage;

		}
	}

	//EnemyShot


}
