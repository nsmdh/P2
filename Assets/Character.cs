using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public IndexPaar pos;
    public Chessboard board;

    // Use this for initialization
    void Start() {
        transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);
        transform.position = board.GetFieldCenter(pos.col, pos.row);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Move(Direction direction) {
        IndexPaar newPos = pos.GetNeighbour(direction);
        UpdatePos(newPos);
    }

    void UpdatePos(IndexPaar pos) {
        if (!board.IsAlive(pos.col, pos.row)) {
            return;
        }
        this.pos = pos;
        transform.position = board.GetFieldCenter(pos.col, pos.row);
    }
}
