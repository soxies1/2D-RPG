using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public bool outsideDoor;
	public House house;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		Entity e = c.GetComponent<Entity> ();
		if (e != null) 
		{
			if (outsideDoor)
			{
				house.GotoRoom(e);
			}
			else{
				house.LeaveRoom(e);
			}
		}

	}

}
