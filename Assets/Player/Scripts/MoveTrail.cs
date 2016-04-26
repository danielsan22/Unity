using UnityEngine;
using System.Collections;

public class MoveTrail : MonoBehaviour {

    public float moveSpeed = 0.5f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        Destroy(gameObject, 1);
	}
}
