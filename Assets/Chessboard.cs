using UnityEngine;
using System.Collections;

public class Chessboard : MonoBehaviour {

    public int size = 10;
    public GameObject[,] grid;

    // Use this for initialization
    void Start() {
        grid = new GameObject[size, size];
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                grid[i, j] = GameObject.CreatePrimitive(PrimitiveType.Quad);
                grid[i, j].transform.position = new Vector3(i + 0.5f, j + 0.5f, 0);
                grid[i, j].transform.parent = this.transform;
                grid[i, j].name = string.Format("Kachel({0},{1})", i, j);
                if (Random.Range(0.0f, 1.0f) <= 0.5f) {
                    grid[i, j].GetComponent<Renderer>().material.color = Color.blue;
                }
            }
        }
        Camera.main.transform.position = new Vector3(size / 2, size / 2, -10);
        Camera.main.orthographicSize = size / 2;
    }

    // Update is called once per frame
    void Update() {
        int[,] numAliveNeighs = new int[size, size];
        
        for (int col = 0; col < size; col++) {
            for (int row = 0; row < size; row++) {
                numAliveNeighs[col, row] = GetNumAliveNeighbours(col, row);
            }
        }

        for (int col = 0; col < size; col++) {
            for (int row = 0; row < size; row++) {
                int numAliveNeighbours = numAliveNeighs[col, row];
                // alive
                if (grid[col, row].GetComponent<Renderer>().material.color == Color.blue) {
                    if (numAliveNeighbours < 2 || numAliveNeighbours > 3) {
                        grid[col, row].GetComponent<Renderer>().material.color = Color.white;
                    }
                }
                // dead
                else {
                    if (numAliveNeighbours == 3) {
                        grid[col, row].GetComponent<Renderer>().material.color = Color.blue;
                    }
                }
            }
        }
    }

    int GetNumAliveNeighbours(int col, int row) {
        int numAliveNeighbours = 0;
        for (int neighCol = col - 1; neighCol <= col + 1; neighCol++) {
            for (int neighRow = row - 1; neighRow <= row + 1; neighRow++) {
                if (neighCol == col && neighRow == row) { // don’t check yourself
                    continue; // skips one loop execution
                }
                if (neighCol >= 0 && neighCol < size &&
                     neighRow >= 0 && neighRow < size &&
                     grid[neighCol, neighRow].GetComponent<Renderer>().material.color == Color.blue) {
                    numAliveNeighbours++;
                }
            }
        }
        return numAliveNeighbours;
    }

    int GetNumAliveNeighbours_OLD(int col, int row) {
        int numAliveNeighbours = 0;
        // left
        if (col - 1 >= 0 && grid[col - 1, row].GetComponent<Renderer>().material.color == Color.blue) {
            numAliveNeighbours++;
        }
        // down left
        if (col - 1 >= 0 && row - 1 >= 0 && grid[col - 1, row - 1].GetComponent<Renderer>().material.color == Color.blue) {
            numAliveNeighbours++;
        }
        // down
        if (row - 1 >= 0 && grid[col, row - 1].GetComponent<Renderer>().material.color == Color.blue) {
            numAliveNeighbours++;
        }
        // down right
        if (col + 1 < size && row - 1 >= 0 && grid[col + 1, row - 1].GetComponent<Renderer>().material.color == Color.blue) {
            numAliveNeighbours++;
        }
        // right
        if (col + 1 < size && grid[col + 1, row].GetComponent<Renderer>().material.color == Color.blue) {
            numAliveNeighbours++;
        }
        // up right
        if (col + 1 < size && row + 1 < size && grid[col + 1, row + 1].GetComponent<Renderer>().material.color == Color.blue) {
            numAliveNeighbours++;
        }
        // up
        if (row + 1 < size && grid[col, row + 1].GetComponent<Renderer>().material.color == Color.blue) {
            numAliveNeighbours++;
        }
        // up left
        if (col - 1 >= 0 && row + 1 < size && grid[col - 1, row + 1].GetComponent<Renderer>().material.color == Color.blue) {
            numAliveNeighbours++;
        }

        return numAliveNeighbours;
    }
}
