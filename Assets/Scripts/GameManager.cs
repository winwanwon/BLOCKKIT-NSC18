using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.

	//Awake is always called before any Start functions
	void Awake()
	{
		boardScript = GetComponent<BoardManager>();
		InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		boardScript.SetupScene();
	}

	//Update is called every frame.
	void Update()
	{

	}
}
