using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic; 

public class GameManager : MonoBehaviour {
	public Text clearMessage;
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
		clearMessage.text = "";
		boardScript.SetupScene();

	}

	//Update is called every frame.
	void Update()
	{
		if (PlayerControl.stageCleared && PlayerControl.exitActivated) {
			clearMessage.text = "STAGE CLEARED!";
		} else if (!PlayerControl.stageCleared && PlayerControl.exitActivated) {
			clearMessage.text = "STAGE FAILED!\nPress R to try again.";
		}

		//Reset Level
		if (Input.GetKeyDown (KeyCode.R)) {
			clearMessage.text = "";
			SceneManager.LoadScene("Prototype");
			PlayerControl.stageCleared = false;
			PlayerControl.exitActivated = false;
		}
	}
}
