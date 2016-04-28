using UnityEngine;
using System.Collections;

public class EnemyController2 : MonoBehaviour
{
	private Animator animator;
	private Vector3 Enemy;
	private Vector2 EnemyDirection;

	public float xDir;
	public float yDir;
	private float speed = 7;
	private Quaternion rotation;
	public GameObject fireball;
	private float shotSpeed;
	private bool isShooting;
	private AudioSource audio;
	private float life;
	public GameObject part;
	public float damage;

	void Awake ()
	{

		rotation = transform.rotation;
	}

	void Start ()
	{
		animator = this.GetComponent<Animator> ();
		audio = this.GetComponent<AudioSource> ();
		shotSpeed = 1f;
		isShooting = false;
		SetIsMovingRight ();
		life = 300;
		damage = 10;
	}

	// Update is called once per frame
	void Update ()
	{
		transform.rotation = rotation;
		Enemy = GameObject.Find ("Player").transform.position;
		xDir = Enemy.x - transform.position.x;
		yDir = Enemy.y - transform.position.y;

		if (isShooting == false) {
			// directional control
			if (!((yDir < 5) && (yDir > -5) && (xDir < 5) && (xDir > -5))) {
				this.GetComponent<Rigidbody2D> ().mass = 5;
				Debug.Log ("Lejos");
				EnemyDirection = new Vector2 (xDir, yDir);

				//line of sight

				this.GetComponent<Rigidbody2D> ().AddForce (EnemyDirection.normalized * speed);

				if (xDir < 0) {
					SetIsMovingLeft ();
				} else if (xDir > 0) {
					SetIsMovingRight ();
				} 
			} else {
				this.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
				if (xDir < 0) {
					SetIsShootingLeft ();
				} else if (xDir > 0) {
					SetIsShootingRight ();
				} 

			}
		} else {

			for (int i = 0; i < 5; i++) {
				Enemy = GameObject.Find ("Player").transform.position;
				xDir = Enemy.x - transform.position.x;
				yDir = Enemy.y - transform.position.y;
				if (xDir < 0) {
					SetIsShootingLeft ();
					this.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
					GameObject fireballClone = (GameObject)Instantiate (fireball, new Vector3 (transform.position.x - 2f, transform.position.y + .2f, 0f), Quaternion.identity);
					fireballClone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xDir * shotSpeed, yDir * shotSpeed);
					fireballClone.GetComponent<FireballController> ().damage = damage;
				} else if (xDir > 0) {
					
					SetIsShootingRight ();
					this.GetComponent<Rigidbody2D> ().velocity = Vector3.zero;
					GameObject fireballClone = (GameObject)Instantiate (fireball, new Vector3 (transform.position.x + 2f, transform.position.y + .2f, 0f), Quaternion.identity);
					fireballClone.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xDir * shotSpeed, yDir * shotSpeed);
					fireballClone.GetComponent<FireballController> ().damage = damage;

				} 

			}
			isShooting = false;
		}

		if (life <= 0) {
			Destroy (gameObject);
			GameObject partClone = (GameObject)Instantiate (part, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
		}
	}

	void SetIsMovingRight ()
	{
		animator.SetBool ("isMovingRight", true);
		animator.SetBool ("isMovingLeft", false);
		animator.SetBool ("isShootingRight", false);
		animator.SetBool ("isShootingLeft", false);
	}

	void SetIsMovingLeft ()
	{
		animator.SetBool ("isMovingRight", false);
		animator.SetBool ("isMovingLeft", true);
		animator.SetBool ("isShootingRight", false);
		animator.SetBool ("isShootingLeft", false);
	}

	void SetIsShootingRight ()
	{
		animator.SetBool ("isMovingRight", false);
		animator.SetBool ("isMovingLeft", false);
		animator.SetBool ("isShootingRight", true);
		animator.SetBool ("isShootingLeft", false);
	}

	void SetIsShootingLeft ()
	{
		animator.SetBool ("isMovingRight", false);
		animator.SetBool ("isMovingLeft", false);
		animator.SetBool ("isShootingRight", false);
		animator.SetBool ("isShootingLeft", true);
	}

	void IsShooting ()
	{
		isShooting = true;
		audio.Play ();
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "Shoot") {
			float dmg = GameObject.Find ("Player").GetComponent<Player> ().damage;
			life = life - dmg;
		}

	}
}
