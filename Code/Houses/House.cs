using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class House : MonoBehaviour {

	private Vector2 roomPos;
	private Vector2 leavePos;
	public Transform roomSpawnT;
	public VillagerManager villagerManager;

	public List<HouseFamily> houseFamily = new List<HouseFamily>();

	// Use this for initialization
	void Start () {
		Vector2 tpos = new Vector2 (0, 0);
		tpos.x = transform.position.x;
		tpos.y = transform.position.y - 3;
		leavePos = tpos;
		roomPos = roomSpawnT.transform.position;
		SpawnFamily ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnFamily () 
	{
		foreach (HouseFamily hf in houseFamily)
		{
			GameObject vil = Instantiate(villagerManager.findVillagerGameObjectByVillagerType(hf.vType), new Vector2(transform.position.x, transform.position.y -3), Quaternion.identity) as GameObject;
			vil.GetComponent<Villager>().home = transform;
		}
	}


	public void GotoRoom (Entity e)
	{
		e.TPToPos (roomPos);
	}

	public void LeaveRoom (Entity e) 
	{
		e.TPToPos (leavePos);
	}

}

[System.Serializable]

public class HouseFamily
{
	public string firstName;
	public string lastName;
	public VillagerType vType;
}
