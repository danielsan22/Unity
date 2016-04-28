using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

    private Rigidbody2D rigi;
    Boss03 boss03;
    // Use this for initialization
    void Start () {

        boss03 = FindObjectOfType<Boss03>();
	}
	
	// Update is called once per frame
	void Update () {

        FireFire();
	}

    void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Border") {

            Destroy(gameObject);
        }
    }

    void FireFire() {

        rigi = GetComponent<Rigidbody2D>();
        int posX = Random.Range(1, 7);
        if (boss03.getUpOrDown() == 0) 
            rigi.velocity = new Vector2(posX, -14);
        else
            rigi.velocity = new Vector2(posX, 14);
    }
}
