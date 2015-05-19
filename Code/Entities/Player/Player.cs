using UnityEngine;
using System.Collections;

public class Player : Entity {

	public ItemPlayerManager ipManager;
	private bool sprinting;
	private float speedBoost;



	public SpriteRenderer weaponSpriteParent;
	public Vector2 forwardPos, backPos, sidePos;
	

	public WeaponManager weaponManager;

	void Start () {
		ipManager.addToItemInventory (0, 5);

		foreach (Weapons w in weaponManager.weapons) 
		{
			if (w.isHolding)
			{
				weaponSpriteParent.sprite = w.weaponSprite;
				if (w.weaponType == WeaponType.Sword)
				{
					Sword sword = weaponSpriteParent.gameObject.AddComponent<Sword>() as Sword;
					sword.minDamage = 15;
					sword.maxDamage = 35;
				}
			}
		}
		//textWidth = 24;
		//textHeight = 32;
		//setupColors ();
		//changeSpritescolour ();

	}
	

	void Update () {
		speedBoost = 0.0f;
		sprinting = false;
		if (Input.GetKey (KeyCode.LeftShift)) 
		{
			speedBoost = 2.0f;
			sprinting = true;
		}
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			if (sprinting) transform.position += Vector3.up * Time.deltaTime * speed * speedBoost;
			else transform.position += Vector3.up * Time.deltaTime * speed;
			direction = 1;
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			if (sprinting) transform.position += Vector3.down * Time.deltaTime * speed * speedBoost;
			else transform.position += Vector3.down * Time.deltaTime * speed;
			direction = 0;
		}
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			if (sprinting) transform.position += Vector3.left * Time.deltaTime * speed * speedBoost;
			else transform.position += Vector3.left * Time.deltaTime * speed;
			direction = 2;
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			if (sprinting) transform.position += Vector3.right * Time.deltaTime * speed * speedBoost;
			else transform.position += Vector3.right * Time.deltaTime * speed;
			direction = 3;
		}

		if (direction == 0)
		{
			spriteParent.sprite = forward;
			weaponSpriteParent.sortingOrder = 21;
			Quaternion newRot = Quaternion.Euler (0,0,90);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = forwardPos;
			//changeSpritescolour ();
		}
		if (direction == 1)
		{
			spriteParent.sprite = backwards;
			weaponSpriteParent.sortingOrder = 19;
			Quaternion newRot = Quaternion.Euler (0,0,90);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = backPos;
			//changeSpritescolour ();

		}
		if (direction == 2)
		{
			spriteParent.sprite = left;
			weaponSpriteParent.sortingOrder = 19;
			Quaternion newRot = Quaternion.Euler (0,0,90);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = sidePos;
			//changeSpritescolour ();
		}
		if (direction == 3)
		{
			spriteParent.sprite = right;
			weaponSpriteParent.sortingOrder = 21;
			Quaternion newRot = Quaternion.Euler (0,0,0);
			weaponSpriteParent.transform.localRotation = newRot;
			weaponSpriteParent.transform.localPosition = sidePos;
			//changeSpritescolour ();
		}



		if (health <= 0) 
		{
			Die();
		}
	}

	public void Die()
	{
		print ("Ive been KILLED!");
	}




	public void TPToPos(Vector2 pos)
	{
		GetComponent<Rigidbody2D>().transform.position = pos;
	}


}
