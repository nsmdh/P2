using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandWalkerAI : MonoBehaviour {

    public Character character;
    float timer = 0.5f; // timer variable, used as a "countdown" to next move

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
        // create array out of enum
        System.Array values = Direction.GetValues(typeof(Direction));
        int randomIndex = Random.Range(0, values.Length); // select random index
                                                          // retrieve random enum value from array
        Direction randomDir = (Direction)values.GetValue(randomIndex);
        character.Move(randomDir);
    }
}
