using UnityEngine;

public struct Vertex {
    public Vector2Int Position { get; private set; }

    public Vertex (int x, int y) {
        Position = new Vector2Int(x, y);
    }

    public Vertex (Vector2Int position) {
        Position = position;
    }

    public override bool Equals (object obj) {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var vertex = (Vertex)obj;
        return Position.Equals(vertex.Position);
    }

    public override int GetHashCode () {
        return Position.GetHashCode();
    }

    public static bool operator == (Vertex left, Vertex right) {
        return left.Position == right.Position;
    }

    public static bool operator != (Vertex left, Vertex right) {
        return left.Position != right.Position;
    }
}