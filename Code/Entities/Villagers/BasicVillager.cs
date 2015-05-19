using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicVillager : Villager {
	
	public Transform target;
	public List<ListOfShops> listOfShops = new List<ListOfShops>();
	public Transform shop;
	public bool goTotarget = false;
	public bool goHome = false;
	public bool generateTarget = false;

	public int distance;

	// Use this for initialization
	void Start () {
		//setupColours ();
		//changeSpritescolour ();
		shop = GameObject.FindGameObjectWithTag ("Shop").transform;
		StartCoroutine (GenerateTarget ());
	}
	
	// Update is called once per frame
	void Update () {

		if (goTotarget) {
			GoToTarget ();
		} 
		else if (goHome) 
		{
			GoHome ();
		}
		else// if(generateTarget)
		{
			StartCoroutine(GenerateTarget());
		}

	}

	IEnumerator GenerateTarget ()
	{
		generateTarget = false;
		yield return new WaitForSeconds (1);
		int r = Random.Range (0, 100);
		if (r > 50) {
			newShopTarget();
		}
		//generateTarget = true;
	}


	public void newShopTarget () {
		//int j  = Random.Range (0, listOfShops.Count);
		target = shop;
		goTotarget = true;
		goHome = false;

	}
	public void GoToTarget () {

		if (target.transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (target.transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if (target.transform.position.x > (GetComponent<Rigidbody2D>().transform.position.x + distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (target.transform.position.x < (GetComponent<Rigidbody2D>().transform.position.x - distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Vector2.Distance (transform.position, target.position) <= 3) 
		{
			goTotarget = false;
			target = null;
			goHome = true;
		}
	}

	public void GoHome()
	{
		if (home.transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (home.transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
		}
		if (home.transform.position.x > (GetComponent<Rigidbody2D>().transform.position.x + distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (home.transform.position.x < (GetComponent<Rigidbody2D>().transform.position.x - distance)) 
		{
			GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Vector2.Distance (home.position, transform.position) <= 3) 
		{
			generateTarget = true;
			goHome = false;

		}

	}
}

[System.Serializable]

public class ListOfShops 
{
	public string shopName;
	public Transform shopT;
}
