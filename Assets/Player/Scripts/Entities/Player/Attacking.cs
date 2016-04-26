using UnityEngine;
using System.Collections;

public class Attacking : Entity {

    public Entity attacking;
    public int distance;

    private bool canAttack;

	// Use this for initialization
	void Start ()
    {
        canAttack = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(attacking.GetComponent<Rigidbody2D>().transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.x > (GetComponent<Rigidbody2D>().transform.position.y + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (attacking.GetComponent<Rigidbody2D>().transform.position.x < (GetComponent<Rigidbody2D>().transform.position.y - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Vector2.Distance(GetComponent<Rigidbody2D>().transform.position, attacking.transform.position) <= distance && canAttack)
        {
            attackEntity();
            StartCoroutine(waitForAttack());
            
        }
    }

    public void Die()
    {

    }

    public void attackEntity()
    {
        int take = Random.Range(1, 20);
        //attacking.takeHealth(take);
    }

    IEnumerator waitForAttack()
    {
        canAttack = false;
        yield return new WaitForSeconds(2);
        canAttack = true;
    }
}
