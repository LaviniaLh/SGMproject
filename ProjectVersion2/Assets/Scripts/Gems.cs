using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour {

	public float gemSpeed;
	private Rigidbody2D theRB;

	public GameObject gemEffect;

	// Use this for initialization
	void Start () {
		theRB = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		theRB.velocity = new Vector2(gemSpeed * transform.localScale.x, 0);


	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Cat")
		{
			FindObjectOfType<GameManagerr>().CatHurt();
		} 
		
		if(other.tag == "Dog")
		{
			FindObjectOfType<GameManagerr>().DogHurt();
		}

		Instantiate(gemEffect, transform.position, transform.rotation);
		Destroy(gameObject);	
	}
}
