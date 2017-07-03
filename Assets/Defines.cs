public enum Direction {left, right, up, down};

public struct IndexPaar {
    public int col;
    public int row;

    public IndexPaar GetNeighbour(Direction direction) {
        IndexPaar neighbour = this;
        switch (direction) {
            case Direction.left:
                neighbour.col -= 1;
                break;
            case Direction.right:
                neighbour.col += 1;
                break;
            case Direction.down:
                neighbour.row -= 1;
                break;
            case Direction.up:
                neighbour.row += 1;
                break;
        }
        return neighbour;
    }
}