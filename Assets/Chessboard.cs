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

    }
}
