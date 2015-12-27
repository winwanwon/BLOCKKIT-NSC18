using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float curSpeed = 5.0f;
	public GameObject wallTiles;
	private Rigidbody2D rb2D;
	private int x;
	private int y;

	// Use this for initialization
	void Start () {
		x = 0;
		y = 0;
		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow) && x != 0) {
			// if Wall
			if (BoardManager.TileMap [7 - y, x - 1] != 'X') { 
				transform.position = new Vector3 (x - 1, y, 0f);
				// if not stand on Double-Pass Path
				if (BoardManager.TileMap [7 - y, x] != 'M') {	
					Instantiate (wallTiles, new Vector3 (x, y, 0f), Quaternion.identity);
					BoardManager.TileMap [7 - y, x] = 'X';
				} else {
					BoardManager.TileMap [7 - y, x] = 'O';
					Destroy (BoardManager.ObjectMap [7 - y, x]);
					Debug.Log ("Destroy: " + BoardManager.ObjectMap [7 - y, x]);
				}
				x -= 1;
			}
			//if stand on Exit
			if (BoardManager.TileMap [7 - y, x] == 'E') {
				Debug.Log ("Exit!");
				if (isMapAllClear ()) {
					Debug.Log ("Clear!");
				} else {
					Debug.Log ("Fail");
				}
			}
			//Debug.Log ("X: " + x + ", Y: " + y);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)&&x!=7)
		{
			if (BoardManager.TileMap [7 - y, x + 1] != 'X') {
				transform.position = new Vector3 (x + 1, y, 0f);
				// if not stand on Double-Pass Path
				if (BoardManager.TileMap [7 - y, x] != 'M') {	
					Instantiate (wallTiles, new Vector3 (x, y, 0f), Quaternion.identity);
					BoardManager.TileMap [7 - y, x] = 'X';
				} else {
					BoardManager.TileMap [7 - y, x] = 'O';
					Destroy (BoardManager.ObjectMap [7 - y, x]);
					Debug.Log ("Destroy: " + BoardManager.ObjectMap [7 - y, x]);
				}
				x += 1;
			}
			if (BoardManager.TileMap [7 - y, x] == 'E') {
				Debug.Log ("Exit!");
				if (isMapAllClear ()) {
					Debug.Log ("Clear!");
				} else {
					Debug.Log ("Fail");
				}
			}
			//Debug.Log ("X: " + x + ", Y: " + y);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow)&&y!=7)
		{
			if (BoardManager.TileMap [(7 - y) - 1, x] != 'X') {
				transform.position = new Vector3 (x, y + 1, 0f);
				// if not stand on Double-Pass Path
				if (BoardManager.TileMap [7 - y, x] != 'M') {	
					Instantiate (wallTiles, new Vector3 (x, y, 0f), Quaternion.identity);
					BoardManager.TileMap [7 - y, x] = 'X';
				} else {
					BoardManager.TileMap [7 - y, x] = 'O';
					Destroy (BoardManager.ObjectMap [7 - y, x], 0f);
					Debug.Log ("Destroy: " + BoardManager.ObjectMap [7 - y, x]);
				}
				y += 1;
			}
			if (BoardManager.TileMap [7 - y, x] == 'E') {
				Debug.Log ("Exit!");
				if (isMapAllClear ()) {
					Debug.Log ("Clear!");
				} else {
					Debug.Log ("Fail");
				}
			}
			//Debug.Log ("X: " + x + ", Y: " + y);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow)&&y!=0)
		{
			if (BoardManager.TileMap [(7 - y) + 1, x] != 'X') {
				transform.position = new Vector3 (x, y - 1, 0f);
				// if not stand on Double-Pass Path
				if (BoardManager.TileMap [7 - y, x] != 'M') {	
					Instantiate (wallTiles, new Vector3 (x, y, 0f), Quaternion.identity);
					BoardManager.TileMap [7 - y, x] = 'X';
				} else {
					BoardManager.TileMap [7 - y, x] = 'O';
					Destroy (BoardManager.ObjectMap [7 - y, x]);
					Debug.Log ("Destroy: " + BoardManager.ObjectMap [7 - y, x]);
				}
				y -= 1;
			}
			if (BoardManager.TileMap [7 - y, x] == 'E') {
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

	bool isMapAllClear(){
		for (int x = 0; x <= 7; x++) {
			for (int y = 0; y <= 7; y++) {
				if (BoardManager.TileMap [7 - y, x] == 'O') {
					return false;
				}
			}
		}
		return true;
	}
}
