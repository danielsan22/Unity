using UnityEngine;
using System.Collections;

public class Player : Entity {


	public GameObject shot;
	public GameObject part;

	private int direction; // 0 up 1 down 2 right 3 left
	private int timeForDie = 100;
	// Use this for initialization
	void Start ()
    {
        curHealth = maxHealth;

    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
			direction = 0;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
			direction = 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
			direction = 3;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
			direction = 2;
        }

		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("SPACE");

			if (direction == 0) {
				GameObject shotClone = (GameObject)Instantiate (shot, transform.position, Quaternion.identity);
				shotClone.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0,1,0)*shotspeed;
			}else if (direction == 1) {
				GameObject shotClone = (GameObject)Instantiate (shot, transform.position, Quaternion.identity);
				shotClone.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0,-1,0)*shotspeed;
			}else if (direction == 2) {
				GameObject shotClone = (GameObject)Instantiate (shot, transform.position, Quaternion.identity);
				shotClone.GetComponent<Rigidbody2D> ().velocity = new Vector3 (1,0,0)*shotspeed;
			}else if (direction == 3) {
				GameObject shotClone = (GameObject)Instantiate (shot, transform.position, Quaternion.identity);
				shotClone.GetComponent<Rigidbody2D> ().velocity = new Vector3 (-1,0,0)*shotspeed;
				shotClone.GetComponent<Bala> ().dmg = damage;
			} 
		}

		if (curHealth <= 0) {
			GameObject partClone = (GameObject)Instantiate (part, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
			GameObject partClone2 = (GameObject)Instantiate (part, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
			GameObject partClone3 = (GameObject)Instantiate (part, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);



			if(timeForDie <=0){
				LevelManager lv = new LevelManager ();
				lv.LoadLevel ("Loose");
				Destroy (gameObject,1.5f);
			}
			timeForDie--;

		}

    }
	private Vector2 GetBShootDirection (Vector3 mouse)
	{
		return new Vector2 (mouse.x-transform.position.x  ,mouse.y -transform.position.y);
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "EnemyShot") {
			
			int dmg = (int)coll.gameObject.GetComponent<FireballController> ().damage;
			curHealth = curHealth - dmg;
			Debug.Log ("EnemyShootPlayer"+curHealth);
			Destroy (coll.gameObject);


		}

	}

    



}
