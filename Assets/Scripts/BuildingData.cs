using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public struct BuildingData {
    private readonly Vertex[] _vertices;
    private readonly Edge[] _edges;

    private readonly ReadOnlyDictionary<Vertex, Vertex[]> _connectionMap;

    public BuildingData (Vertex[] vertices, Edge[] edges) {
        _vertices = vertices;
        _edges = edges;
        
        var connectionMap = new Dictionary<Vertex, Vertex[]>();

        foreach (var vertex in _vertices) {
            var connectedVertices = new List<Vertex>();

            foreach (var edge in _edges) {
                if (edge.Start == vertex || edge.End == vertex) {
                    var connectedVertice = edge.Start == vertex ? edge.End : edge.Start;
                    
                    connectedVertices.Add(connectedVertice);
                }
            }
            
            connectionMap.Add(vertex, connectedVertices.ToArray());
        }

        _connectionMap = new ReadOnlyDictionary<Vertex, Vertex[]>(connectionMap);
    }

    public IEnumerable<Vertex> GetConnections (Vertex vertex) {
        if (_connectionMap.ContainsKey(vertex)) {
            return _connectionMap[vertex];
        }

        return Enumerable.Empty<Vertex>();
    }
}
