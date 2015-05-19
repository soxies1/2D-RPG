using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChestGUI : MonoBehaviour {

	public GUISkin GUIskin;
	public List<Inventory> chestInv = new List<Inventory>();
	public bool drawInventory;
	public Texture2D chestGUI;
	public List<Slot> slots = new List<Slot>();

	// Use this for initialization
	void Start () {
		for (int i = 0; i < slots.Count; i++) 
		{
			slots[i].setupSlots();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI()
	{
		if (drawInventory) 
		{
			GUI.DrawTexture(new Rect((Screen.width / 2) - 128, (Screen.height / 2) - 128, 256, 256), chestGUI);
			for (int i = 0; i < slots.Count; i++)
			{
				if (chestInv[i] != null)
				{
					GUI.DrawTexture(new Rect(slots[i].x, slots[i].y, 32,32), chestInv[i].item.itemSprite.texture);
				}
			}
		}
	}
	public void giveInventory(List<Inventory> i)
	{
		this.chestInv = i;
	}

}

[System.Serializable]

public class Slot
{
	public int x, y;
	public bool right, bottom;
	public Slot (int x, int y)
	{
		if (right) {
			this.x = (Screen.width / 2) + x;
		} else
			this.x = (Screen.width / 2) - x;
		if (bottom) {
			this.y = (Screen.height / 2) + y;
		} else
			this.y = (Screen.height / 2) - y;
	}

	public void setupSlots ()
	{
		if (right) {
			x = (Screen.width / 2) + x;
		} else
			x = (Screen.width / 2) - x;
		if (bottom) {
			y = (Screen.height / 2) + y;
		} else
			y = (Screen.height / 2) - y;
	}

}
