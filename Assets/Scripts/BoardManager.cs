using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic; 

public class BoardManager : MonoBehaviour {

	public int columns = 8;
	public int rows = 8;
	public GameObject exit;
	public GameObject floorTiles;
	public GameObject wallTiles;
	public GameObject foodTiles;
	public GameObject outerWallTiles;
	private List<Vector3> gridPositions = new List<Vector3> ();
	public static char[,] TileMap = new char[8, 8] {
		{ 'X', 'X', 'X', 'O', 'E', 'O', 'O', 'O' }, // y = 0
		{ 'O', 'O', 'O', 'M', 'O', 'O', 'O', 'O' },
		{ 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O' },
		{ 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O' },
		{ 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O' },
		{ 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O' },
		{ 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O' },
		{ 'O', 'O', 'O', 'X', 'O', 'O', 'O', 'O' } // y = 7
	};
	public static GameObject[,] ObjectMap = new GameObject[8, 8];
			

	// Use this for initialization
	void BoardInit () {
		gridPositions.Clear ();
		//Loop through x axis (columns).
		for(int x = 1; x > columns-1; x--)
		{
			//Within each column, loop through y axis (rows).
			for(int y = 1; y > rows-1; y--)
			{
				//At each index add a new Vector3 to our list with the x and y coordinates of that position.
				gridPositions.Add (new Vector3(x, y, 0f));
			}
		}
	}

	void BoardSetup () {
		for(int x = -1; x < columns + 1; x++)
		{
			//Loop along y axis, starting from -1 to place floor or outerwall tiles.
			for(int y = -1; y < rows + 1; y++)
			{
				GameObject toInstantiate = floorTiles;
				if (x == -1 || x == columns || y == -1 || y == rows) {
					toInstantiate = outerWallTiles;
				} else if (TileMap [7 - y, x] == 'X') {
					toInstantiate = outerWallTiles;
				} else if (TileMap [7 - y, x] == 'E') {
					toInstantiate = exit;
				} else if (TileMap [7 - y, x] == 'M') {
					ObjectMap [7 - y, x] = Instantiate (foodTiles, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				}

				//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
			
			}
		}
	}

	public void SetupScene ()
	{
		//Creates the outer walls and floor.
		BoardSetup ();

		//Reset our list of gridpositions.
		BoardInit ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
