using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour {

	public List<Weapons> weapons;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

[System.Serializable]
public class Weapons
{
	public string name;
	public WeaponType weaponType;
	public bool isHolding;
	public Sprite weaponSprite;


}

public enum WeaponType
{
	Sword,
	Bow

}