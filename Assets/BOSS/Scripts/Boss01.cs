using UnityEngine;
using System.Collections;

public class Boss01 : MonoBehaviour {

    enum direction {
        right,
        left,
        up,
        down
    }

    enum bossState {
        Walk,
        NextDirection
    }

    direction actualDirection = direction.right;
    bossState actualState = bossState.Walk;
    float speed = 10f;
    int randomDirection;
    bool changeDirection = false;
    float waitTime = 100;
    float health = 500;
    Animator animator;
    Health _Health_;
    Quaternion startRotation;
    Quaternion desiredAngle;
    float goal;

    // Use this for initialization
    void Start() {

        animator = GetComponent<Animator>();
        _Health_ = GameObject.FindObjectOfType<Health>();
        startRotation = transform.rotation;
        desiredAngle = Quaternion.AngleAxis(90f, Vector3.up);
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
            default:
                break;
        }
        if (changeDirection) {

            actualState = bossState.NextDirection;
        } else {

        }
        if (!(waitTime > 0)) {
            changeDirection = true;
            waitTime = 100;
        }
        waitTime--;
        if(health <= 0) {
			GameObject.Find ("Door").GetComponent<Door>().isOpen = true;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        

        if (collision.gameObject.tag == "Player") {

            //Destroy(collision.gameObject);
        }else if (collision.gameObject.tag == "Border") {

            changeDirection = true;
            Debug.Log(collision.gameObject.name);
        } else if (collision.gameObject.tag == "Shoot") {
			float x = collision.gameObject.GetComponent<Bala> ().dmg;
			_Health_.Damage(x);
        }
    }

    void NextDirection() {

        randomDirection = Random.Range(0, 3);
        if (randomDirection == (int)actualDirection) {

            if (randomDirection >= 3) {

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
            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", false);
            if(transform.position.x <= 5.8) {
                transform.position += Vector3.right * speed * Time.deltaTime;
            } else {
                actualState = bossState.NextDirection;
            }
            actualDirection = direction.right;
        } else if (moveInDirection == direction.left) {

            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", true);
            animator.SetBool("walkUp", false);
            animator.SetBool("walkDown", false);
            if (transform.position.x >= -3.4) {
                transform.position += Vector3.left * speed * Time.deltaTime;
            } else {
                actualState = bossState.NextDirection;
            }
            actualDirection = direction.left;
        } else if (moveInDirection == direction.up) {

            animator.SetBool("walkUp", true);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkDown", false);
            if (transform.position.y <= 1.9) {
                transform.position += Vector3.up * speed * Time.deltaTime;
            } else {
                actualState = bossState.NextDirection;
            }
            actualDirection = direction.up;
        } else if (moveInDirection == direction.down) {

            //transform.rotation = Quaternion.Slerp(startRotation, desiredAngle, .5f);
            animator.SetBool("walkDown", true);
            animator.SetBool("walkRight", false);
            animator.SetBool("walkLeft", false);
            animator.SetBool("walkUp", false);
            if (transform.position.y >= -2.1) {
                transform.position += Vector3.down * speed * Time.deltaTime;
            } else {
                actualState = bossState.NextDirection;
            }
            actualDirection = direction.down;
        } else {


        }
    }

    public float getHealth() {

        return health;
    }

    public void setHealth(float Health) {

        health = Health;
    }
}
