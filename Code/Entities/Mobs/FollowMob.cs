using UnityEngine;
using System.Collections;

public class FollowMob : Entity {

	public Entity following;
	public float distance;
	void Start () {
		//changeSpritescolour ();
		setupColours ();
		//changeSpritescolour ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (following.GetComponent<Rigidbody2D>().transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (following.GetComponent<Rigidbody2D>().transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if (following.GetComponent<Rigidbody2D>().transform.position.x > (GetComponent<Rigidbody2D>().transform.position.x + distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (following.GetComponent<Rigidbody2D>().transform.position.x < (GetComponent<Rigidbody2D>().transform.position.x - distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (health <= 0) 
		{
			Die();
		}

		if (direction == 0)
		{
			spriteParent.sprite = forward;
		}
		if (direction == 1)
		{
			spriteParent.sprite = backwards;

			
		}
		if (direction == 2)
		{
			spriteParent.sprite = left;

		}
		if (direction == 3)
		{
			spriteParent.sprite = right;

		}

		//textWidth = 24;
		//textHeight = 32;

	}

	public void Die()
	{
		
	}


}
