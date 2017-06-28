using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : MonoBehaviour {

    public Chessboard board;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K)) {
            board.KillAll();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            board.pause = !board.pause;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            board.ToggleMouseField();
        }

        if (board.pause) {
            return;
        }

        int[,] numAliveNeighs = new int[board.size, board.size];

        for (int col = 0; col < board.size; col++) {
            for (int row = 0; row < board.size; row++) {
                numAliveNeighs[col, row] = board.GetNumAliveNeighbours(col, row);
            }
        }

        for (int col = 0; col < board.size; col++) {
            for (int row = 0; row < board.size; row++) {
                int numAliveNeighbours = numAliveNeighs[col, row];
                // alive
                if (board.IsAlive(col, row)) {
                    if (numAliveNeighbours < 2 || numAliveNeighbours > 3) {
                        board.SetAlive(col, row, false);
                    }
                }
                // dead
                else {
                    if (numAliveNeighbours == 3) {
                        board.SetAlive(col, row, true);
                    }
                }
            }
        }
    }
}
