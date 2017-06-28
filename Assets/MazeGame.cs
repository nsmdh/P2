using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGame : MonoBehaviour {

    public Chessboard board;
    public Character player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W)) {
            player.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            player.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            player.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            player.MoveRight();
        }
    }
}
