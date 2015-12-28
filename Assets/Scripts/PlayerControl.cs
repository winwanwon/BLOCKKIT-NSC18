using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float curSpeed = 5.0f;
	public GameObject wallTiles;
	private static char[,] TempTileMap = new char[8,8];
	private Rigidbody2D rb2D;
	public static bool stageCleared = false;
	public static bool exitActivated = false;
	private int x;
	private int y;

	// Use this for initialization
	void Start () {
		TempTileMap = BoardManager.TileMap;
		x = 0;
		y = 0;
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (TempTileMap [7 - y, x] != 'E') {
			if (Input.GetKeyDown (KeyCode.LeftArrow) && x != 0) {
				// if Wall
				if (TempTileMap [7 - y, x - 1] != 'X') { 
					transform.position = new Vector3 (x - 1, y, 0f);
					// if stand on special path
					if (TempTileMap [7 - y, x] == 'M') {	
						TempTileMap [7 - y, x] = 'O';
						Destroy (BoardManager.ObjectMap [7 - y, x]);
						Debug.Log ("Destroy: " + BoardManager.ObjectMap [7 - y, x]);
					} else if (TempTileMap [7 - y, x] == 'W') {
					
					} else {
						Instantiate (wallTiles, new Vector3 (x, y, 0f), Quaternion.identity);
						TempTileMap [7 - y, x] = 'X';
					}
					x -= 1;
				}
				//if stand on Exit
				if (TempTileMap [7 - y, x] == 'E') {
					Debug.Log ("Exit!");
					if (isMapAllClear ()) {
						Debug.Log ("Clear!");
					} else {
						Debug.Log ("Fail");
					}
				}
				//Debug.Log ("X: " + x + ", Y: " + y);
			}
			if (Input.GetKeyDown (KeyCode.RightArrow) && x != 7) {
				if (TempTileMap [7 - y, x + 1] != 'X') {
					transform.position = new Vector3 (x + 1, y, 0f);
					// if stand on special path
					if (TempTileMap [7 - y, x] == 'M') {	
						TempTileMap [7 - y, x] = 'O';
						Destroy (BoardManager.ObjectMap [7 - y, x]);
						Debug.Log ("Destroy: " + BoardManager.ObjectMap [7 - y, x]);
					} else if (TempTileMap [7 - y, x] == 'W') {

					} else {
						Instantiate (wallTiles, new Vector3 (x, y, 0f), Quaternion.identity);
						TempTileMap [7 - y, x] = 'X';
					}
					x += 1;
				}
				if (TempTileMap [7 - y, x] == 'E') {
					Debug.Log ("Exit!");
					if (isMapAllClear ()) {
						Debug.Log ("Clear!");
					} else {
						Debug.Log ("Fail");
					}
				}
				//Debug.Log ("X: " + x + ", Y: " + y);
			}
			if (Input.GetKeyDown (KeyCode.UpArrow) && y != 7) {
				if (TempTileMap [(7 - y) - 1, x] != 'X') {
					transform.position = new Vector3 (x, y + 1, 0f);
					// if stand on special path
					if (TempTileMap [7 - y, x] == 'M') {	
						TempTileMap [7 - y, x] = 'O';
						Destroy (BoardManager.ObjectMap [7 - y, x]);
						Debug.Log ("Destroy: " + BoardManager.ObjectMap [7 - y, x]);
					} else if (TempTileMap [7 - y, x] == 'W') {

					} else {
						Instantiate (wallTiles, new Vector3 (x, y, 0f), Quaternion.identity);
						TempTileMap [7 - y, x] = 'X';
					}
					y += 1;
				}
				if (TempTileMap [7 - y, x] == 'E') {
					Debug.Log ("Exit!");
					if (isMapAllClear ()) {
						Debug.Log ("Clear!");
					} else {
						Debug.Log ("Fail");
					}
				}
				//Debug.Log ("X: " + x + ", Y: " + y);
			}
			if (Input.GetKeyDown (KeyCode.DownArrow) && y != 0) {
				if (TempTileMap [(7 - y) + 1, x] != 'X') {
					transform.position = new Vector3 (x, y - 1, 0f);
					// if stand on special path
					if (TempTileMap [7 - y, x] == 'M') {	
						TempTileMap [7 - y, x] = 'O';
						Destroy (BoardManager.ObjectMap [7 - y, x]);
						Debug.Log ("Destroy: " + BoardManager.ObjectMap [7 - y, x]);
					} else if (TempTileMap [7 - y, x] == 'W') {

					} else {
						Instantiate (wallTiles, new Vector3 (x, y, 0f), Quaternion.identity);
						TempTileMap [7 - y, x] = 'X';
					}
					y -= 1;
				}
				if (TempTileMap [7 - y, x] == 'E') {
					Debug.Log ("Exit!");
					if (isMapAllClear ()) {
						Debug.Log ("Clear!");
					} else {
						Debug.Log ("Fail");
					}
				}
				//Debug.Log ("X: " + x + ", Y: " + y);
			}
		}

		//if stuck in wall
		if ((x == 0 || TempTileMap [7 - y, x - 1] == 'X') && (x == 7 || TempTileMap [7 - y, x + 1] == 'X') && (y == 0 || TempTileMap [(7 - y) + 1, x] == 'X') && (y == 7 || TempTileMap [(7 - y) - 1, x] == 'X')) {
			stageCleared = false;
			exitActivated = true;
		}
	}
	

	bool isMapAllClear(){
		exitActivated = true;
		for (int x = 0; x <= 7; x++) {
			for (int y = 0; y <= 7; y++) {
				if (TempTileMap [7 - y, x] == 'O') {
					stageCleared = false;
					return false;
				}
			}
		}
		stageCleared = true;
		return true;
	}
}
