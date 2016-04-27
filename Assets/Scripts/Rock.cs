using UnityEngine;
using System.Collections;

public class Rock : MonoBehaviour {

	public GameObject rockParticles;

	// Use this for initialization
	void Start () {
		InstantiateParticle (transform.position);
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void InstantiateParticle(Vector3 pos){
		GameObject tmpParticles = (GameObject)Instantiate (rockParticles, pos, Quaternion.identity); //look up how to use Instantiate, you'll need it a lot
		Destroy (tmpParticles, 3f);
	}


}
