using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VillagerManager : MonoBehaviour {

	public List<Villagers> villagers = new List<Villagers>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Villager findVillagerByVillagerType (VillagerType vType)
	{
		Villagers v = new Villagers ();
		foreach (Villagers vv in villagers) 
		{
			if (vv.vType == vType)
				v = vv;
		}
		if (v != null) {
			return v.villager.GetComponent<Villager>();
		} else
			return null;
	}
	public GameObject findVillagerGameObjectByVillagerType (VillagerType vType)
	{
		Villagers v = new Villagers ();
		foreach (Villagers vv in villagers) 
		{
			if (vv.vType == vType)
				v = vv;
		}
		if (v != null) {
			return v.villager;
		} else
			return null;
	}



}
[System.Serializable]

public class Villagers 
{
	public GameObject villager;
	public VillagerType vType;
}


public enum VillagerType
{
	Basic,
	Worker,
	Blacksmith,
	Trader,
	Shopkeeper
}
