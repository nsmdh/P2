using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGame : MonoBehaviour {

    public Chessboard board;
    public Character player;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.W)) {
            player.Move(Direction.up);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            player.Move(Direction.left);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            player.Move(Direction.down);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            player.Move(Direction.right);
        }
    }
}
