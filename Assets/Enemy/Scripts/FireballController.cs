using UnityEngine;
using System.Collections;

public class FireballController : MonoBehaviour
{

	public float damage;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		Destroy (gameObject);
	}
}
