using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public int col;
    public int row;
    public Chessboard board;

    // Use this for initialization
    void Start() {
        transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        transform.position = board.GetFieldCenter(col, row);
    }

    // Update is called once per frame
    void Update() {

    }

    public void MoveLeft() {
        col--;
        transform.position = board.GetFieldCenter(col, row);
    }

    public void MoveRight() {
        col++;
        transform.position = board.GetFieldCenter(col, row);
    }

    public void MoveUp() {
        row++;
        transform.position = board.GetFieldCenter(col, row);
    }

    public void MoveDown() {
        row--;
        transform.position = board.GetFieldCenter(col, row);
    }
}
