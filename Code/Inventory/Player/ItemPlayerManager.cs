﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemPlayerManager : MonoBehaviour {

	public ItemManager iManager;

	public List<Inventory> items = new List<Inventory>();


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addToItemInventory(int itemId, int amount)
	{
		for (int i = 0; i < iManager.items.Count; i++) 
		{
			if(iManager.items[i].itemTransform.GetComponent<Item>().id == itemId)
			{
				//items.Add();
				Inventory inv = new Inventory(iManager.items[i].itemTransform.GetComponent<Item>(), amount);
				items.Add(inv);
			}
		}
	}
}

[System.Serializable]
public class Inventory
{
	public Item item;
	public int amountOfItem;

	public Inventory (Item item, int amountOfItem)
	{
		this.item = item;
		this.amountOfItem = amountOfItem;
	}

}

