using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

	private int levelHeight;
	private int levelWidth;

	public Entity enemy;


	public Color spawnPointColor;
	public Color enemyPointColor;

	private Color[] tilecolors;
	private Color[] topTilecolors;

	public Texture2D levelTexture;
	public Texture2D topTileTexture;

	public Entity player;
	public Entity[] friendlyEntities;

	public List<Tile> tiles = new List<Tile>();

	// Use this for initialization
	void Start () 
	{
		levelWidth = levelTexture.width;
		levelHeight = levelTexture.height;
		loadLevel ();
		loadTopTiles ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void loadLevel () 
	{
		tilecolors = new Color[levelWidth * levelHeight];
		tilecolors = levelTexture.GetPixels ();
		for(int y = 0; y < levelHeight; y++) 
		{
			for(int x = 0; x < levelWidth; x++)
			{
				foreach (Tile t in tiles)
				{
					if (tilecolors[x + y * levelWidth] == t.tileColor)
					{
						Instantiate(t.tileTransform, new Vector3(x,y), Quaternion.identity );
					}

				}

				if(tilecolors[x + y * levelWidth] == spawnPointColor)
				{
					Instantiate(tiles[0].tileTransform, new Vector3(x,y), Quaternion.identity );
					Vector2 pos = new Vector2(x,y);
					player.transform.position = pos;
					for(int i = 0; i < friendlyEntities.Length; i++)
					{
						Vector2 npos = pos;
						npos.x += i +1;
						friendlyEntities[i].transform.position = npos;
					}
				}
				if(tilecolors[x + y * levelWidth] == enemyPointColor)
				{
					Instantiate(tiles[0].tileTransform, new Vector3(x,y), Quaternion.identity );
					Instantiate(enemy, new Vector3(x,y), Quaternion.identity);
				}
			}
		}
	}

	void loadTopTiles ()
	{
		topTilecolors = new Color[topTileTexture.width * topTileTexture.height];
		topTilecolors = topTileTexture.GetPixels ();
		for(int y = 0; y < levelHeight; y++) 
		{
			for(int x = 0; x < levelWidth; x++)
			{
				foreach (Tile t in tiles)
				{
					if (topTilecolors[x + y * levelWidth] == t.tileColor)
					{
						Instantiate(t.tileTransform, new Vector3(x,y), Quaternion.identity );
					}
					
				}
			}
		}

	}

}

[System.Serializable]

public class Tile
{
	public string tileName;
	public Color tileColor;
	public Transform tileTransform;

}

