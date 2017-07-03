using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallWalkerAI : MonoBehaviour {

    public Character character;
    float timer = 0.5f; // timer variable, used as a "countdown" to next move
    Direction currentDir = Direction.left;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime; // subtract time since last frame
        if (timer > 0f) { // if countdown not done, skip
            return;
        }
        timer = 0.5f; // if we get here, reset timer
        Move(); // and move
    }

    void Move() {
        IndexPaar checkPos = character.pos.GetNeighbour(currentDir);

        if (character.board.IsAlive(checkPos.col, checkPos.row)) {
            character.Move(currentDir);
        } else {
            TurnLeft();
        }
    }

    private void TurnLeft() {
        switch (currentDir) {
            case Direction.left:
                currentDir = Direction.down;
                break;
            case Direction.right:
                currentDir = Direction.up;
                break;
            case Direction.up:
                currentDir = Direction.left;
                break;
            case Direction.down:
                currentDir = Direction.right;
                break;
        }
    }
}
