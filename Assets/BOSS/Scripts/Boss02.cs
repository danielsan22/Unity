using UnityEngine;
using System.Collections;

public class Boss02 : MonoBehaviour {

    enum direction {
        right,
        left
    }

    enum bossState {
        Walk,
        NextDirection,
        Teletransport
    }

    direction actualDirection = direction.right;
    bossState actualState = bossState.Walk;
    public AudioClip clip;
    float speed = 10f;
    int randomDirection;
    bool changeDirection = false;
    float waitTime = 100;
    float waitTransport = 100;
    float health = 500;
    public GameObject smoke;
    Animator animator;
    Health2 _Health_;
    Quaternion startRotation;
    Quaternion desiredAngle;
    float goal;

    // Use this for initialization
    void Start() {

        animator = GetComponent<Animator>();
        _Health_ = GameObject.FindObjectOfType<Health2>();
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
            case bossState.Teletransport:
                Teletransport();
                break;
            default:
                break;
        }
        if (changeDirection) {

            actualState = bossState.NextDirection;
        } else {

        }
        if (!(waitTime > 0)) {

            AudioSource.PlayClipAtPoint(clip, transform.position, 5000f);
            PuffSmoke();
            actualState = bossState.Teletransport;
            waitTime = 300;
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
            if (transform.position.x <= 5.8) {
                transform.position += Vector3.right * speed * Time.deltaTime;
            } else {
                actualState = bossState.NextDirection;
            }
            actualDirection = direction.right;
        } else if (moveInDirection == direction.left) {

            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", true);
            if (transform.position.x >= -3.4) {
                transform.position += Vector3.left * speed * Time.deltaTime;
            } else {
                actualState = bossState.NextDirection;
            }
            actualDirection = direction.left;
        } else {


        }
    }

    void Teletransport() {

        if (!(waitTransport > 0)) {


            float posX = Random.Range(-3.4f, 5.8f);
            float posY = Random.Range(-2.1f, 1.9f);
            transform.position = new Vector2(posX, posY);
			PuffSmoke();
            actualState = bossState.Walk;
            waitTransport = 100;
        } else {
            transform.position = new Vector2(-50f, -50f);
        }
        waitTransport--;
    }

    public float getHealth() {

        return health;
    }

    public void setHealth(float Health) {

        health = Health;
    }

    void PuffSmoke() {
        GameObject smokepuff = Instantiate(smoke, new Vector3(transform.position.x,transform.position.y, -3f), Quaternion.identity) as GameObject;
    }
}
