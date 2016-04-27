using UnityEngine;
using System.Collections;

public class Player : Entity {

	// Use this for initialization
	void Start ()
    {
        curHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			//GetComponent<Rigidbody2D> ().velocity = transform.up * speed * Time.deltaTime;
			GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
		} 
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			//GetComponent<Rigidbody2D> ().velocity = transform.up * speed * Time.deltaTime * -1;
			GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
		} 
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			//GetComponent<Rigidbody2D> ().velocity = transform.right * speed * Time.deltaTime*-1;
			GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
		} 
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			//GetComponent<Rigidbody2D> ().velocity = transform.right * speed * Time.deltaTime;
			GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
		}  

		//GetComponent<Rigidbody2D> ().velocity = Vector3.zero;



        

    }
	/*
	 * I started using rigidbody.velocity, like this rigidbody.velocity = transform.forward Forward Time.deltaTime;
	 * */

    



}
