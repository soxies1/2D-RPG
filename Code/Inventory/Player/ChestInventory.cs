using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestInventory : MonoBehaviour {

	public List<Inventory> chestInv = new List<Inventory>();
	public ItemManager iManager;
	public ChestGUI chestGui;
	public Entity checkingEntity;
	public bool isOpen;

	public bool canOpen;

	void Start () {
	
	}
	

	void Update () {

		if (Vector2.Distance (transform.position, checkingEntity.transform.position) < 3) {
			canOpen = true;
		} else {
			canOpen = false;
		}

		if (canOpen) 
		{
			if (Input.GetKeyDown(KeyCode.E)) 
			{
				toggleChest ();
			}	
		}

	}

	public void addToItemInventory(int itemId, int amount)
	{
		for (int i = 0; i < iManager.items.Count; i++) 
		{
			if(iManager.items[i].itemTransform.GetComponent<Item>().id == itemId)
			{
				//items.Add();
				Inventory inv = new Inventory(iManager.items[i].itemTransform.GetComponent<Item>(), amount);
				chestInv.Add(inv);
			}
		}
	}

	public void toggleChest () 
	{
		if (!isOpen) 
		{
			chestGui.drawInventory = true;
			chestGui.giveInventory (chestInv);
			//chestGui.onGUI();
		}
		else
			chestGui.drawInventory = false;
		isOpen = !isOpen;
	}


}
