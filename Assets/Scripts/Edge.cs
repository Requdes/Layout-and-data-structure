public struct Edge {
    public Vertex Start { get; private set; }
    public Vertex End { get; private set; }

    public Edge (Vertex start, Vertex end) {
        Start = start;
        End = end;
    }
}
