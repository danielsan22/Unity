using UnityEngine;
using System.Collections;

public class Boss03 : MonoBehaviour {

    enum direction {
        right,
        left,
        idle
    }

    enum bossState {
        Walk,
        NextDirection,
        Fire
    }

    direction actualDirection = direction.right;
    bossState actualState = bossState.Walk;
    public AudioClip clip;
    float speed = 10f;
    int randomDirection;
    int randomFire;
    int numFire;
    bool changeDirection = false;
    float waitTime = 100;
    float waitFire = 50;
    int upOrDown;
    float waitTransport = 100;
    float health = 500;
    public GameObject smoke;
    public GameObject fire;
    Animator animator;
    Health3 _Health_;
    Quaternion startRotation;
    Quaternion desiredAngle;
    float goal;

    // Use this for initialization
    void Start() {

        animator = GetComponent<Animator>();
        _Health_ = GameObject.FindObjectOfType<Health3>();
        randomFire = Random.Range(1, 3);
        numFire = 0;
        upOrDown = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update() {

        switch (actualState) {

            case bossState.NextDirection:

                NextDirection();
                break;
            case bossState.Walk:

                Walk((direction)actualDirection);
                break;
            case bossState.Fire:
                Fire();
                break;
            default:
                break;
        }
        if (changeDirection) {

            actualState = bossState.NextDirection;
        } else {

        }
        if (!(waitTime > 0)) {

            actualDirection = direction.idle;
            actualState = bossState.Walk;
            waitTime = Random.Range(150, 300);
            AudioSource.PlayClipAtPoint(clip, transform.position, 1f);
        }
        waitTime--;
        if (health <= 0) {
			GameObject.Find ("Door").GetComponent<Door>().isOpen = true;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {


        if (collision.gameObject.tag == "Player") {

            //Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Border") {

            changeDirection = true;
            Debug.Log(collision.gameObject.name);
        } else if (collision.gameObject.tag == "Shoot") {

			float x = collision.gameObject.GetComponent<Bala> ().dmg;
			_Health_.Damage(x);
        }
    }

    void NextDirection() {

        randomDirection = Random.Range(0, 1);
        if (randomDirection == (int)actualDirection) {

            if (randomDirection >= 1) {

                randomDirection--;
            } else if (randomDirection <= 0) {

                randomDirection++;
            } else {

                randomDirection++;
            }
        }
        actualState = bossState.Walk;
        actualDirection = (direction)randomDirection;
        changeDirection = false;
    }

    void Walk(direction moveInDirection) {

        if (moveInDirection == direction.right) {

            animator.SetBool("walkRight", true);
            animator.SetBool("walkLeft", false);
            animator.SetBool("attackLeft", false);
            animator.SetBool("attackRight", false);
            animator.SetBool("idle", false);
            if (transform.position.x <= 6.4) {
                transform.position += Vector3.right * speed * Time.deltaTime;
            } else {
                actualState = bossState.NextDirection;
            }
            actualDirection = direction.right;
        } else if (moveInDirection == direction.left) {

            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", true);
            animator.SetBool("attackLeft", false);
            animator.SetBool("attackRight", false);
            animator.SetBool("idle", false);
            if (transform.position.x >= -4.2) {
                transform.position += Vector3.left * speed * Time.deltaTime;
            } else {
                actualState = bossState.NextDirection;
            }
            actualDirection = direction.left;
        } else if (moveInDirection == direction.idle) {

            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("attackLeft", false);
            animator.SetBool("attackRight", false);
            animator.SetBool("idle", true);
            actualDirection = direction.idle;
            Fire();
        } else {


        }
    }

    void Fire() {

        if( numFire <= randomFire ) { 

            GameObject fireEnemy = Instantiate(fire, new Vector3(transform.position.x, transform.position.y+1, -13f), Quaternion.identity) as GameObject;
            numFire++;
        } else {

            if (!(waitFire > 0)) {

                actualState = bossState.Walk;
                waitFire = 50;
                RandomFire();
                actualDirection = direction.left;
            }
            waitFire--;
        }

    }

    void RandomFire() {
        randomFire = Random.Range(1, 3);
        numFire = 0;
        upOrDown = Random.Range(0, 2);
    }

    public float getHealth() {

        return health;
    }

    public void setHealth(float Health) {

        health = Health;
    }

    void PuffSmoke() {

        GameObject smokepuff = Instantiate(smoke, new Vector3(transform.position.x,transform.position.y, -13f), Quaternion.identity) as GameObject;
    }

    public int getUpOrDown() {

        return upOrDown;
    }
}
