using UnityEngine;
using System.Collections;

public class Chessboard : MonoBehaviour {

    public int size = 10;
    public GameObject[,] grid;
    public bool pause = false;

    void Start() {
        grid = new GameObject[size, size];
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                grid[i, j] = GameObject.CreatePrimitive(PrimitiveType.Quad);
                grid[i, j].transform.position = new Vector3(i + 0.5f, j + 0.5f, 0);
                grid[i, j].transform.parent = this.transform;
                grid[i, j].name = string.Format("Kachel({0},{1})", i, j);
                if (Random.Range(0.0f, 1.0f) <= 0.8f) {
                    SetAlive(i, j, true);
                }
            }
        }
        Camera.main.transform.position = new Vector3(size / 2, size / 2, -10);
        Camera.main.orthographicSize = size / 2;
    }

    void Update() {

    }

    public void ToggleMouseField() {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int indexX = (int)mouseWorldPos.x;
        int indexY = (int)mouseWorldPos.y;
        Toggle(indexX, indexY);
    }

    void Toggle(int col, int row) {
        SetAlive(col, row, !IsAlive(col, row));
    }

    public void KillAll() {
        for (int col = 0; col < size; col++) {
            for (int row = 0; row < size; row++) {
                SetAlive(col, row, false);
            }
        }
    }

    public int GetNumAliveNeighbours(int col, int row) {
        int numAliveNeighbours = 0;
        for (int neighCol = col - 1; neighCol <= col + 1; neighCol++) {
            for (int neighRow = row - 1; neighRow <= row + 1; neighRow++) {
                if (neighCol == col && neighRow == row) { // don’t check yourself
                    continue; // skips one loop execution
                }
                if (neighCol >= 0 && neighCol < size &&
                     neighRow >= 0 && neighRow < size &&
                     IsAlive(neighCol, neighRow)) {
                    numAliveNeighbours++;
                }
            }
        }
        return numAliveNeighbours;
    }

    public bool IsAlive(int col, int row) {
        if (col < 0 || row < 0 || col >= size || row >= size) {
            return false;
        }
        return grid[col, row].GetComponent<Renderer>().material.color == Color.blue;
    }

    public void SetAlive(int col, int row, bool alive) {
        if (alive) {
            grid[col, row].GetComponent<Renderer>().material.color = Color.blue;
        } else {
            grid[col, row].GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public Vector3 GetFieldCenter(int col, int row) {
        return new Vector3(col + 0.5f, row + 0.5f, 0.0f);
    }
}
