using UnityEngine;

public class Test : MonoBehaviour {
    // Grid:
    // (0, 1)   (1, 1)   (2, 1)
    //   |   /         \   |
    // (0, 0) — (1, 0) — (2, 0)
    
    // test0 (0, 0)
    // test1 (1, 1)
    // test2 (0, 1)

    private void Awake () {
        var vertices = new Vertex[6];
        var edges = new Edge[6];
        
        for (int i = 0, y = 0; y < 2; y++) {
            for (int x = 0; x < 3; x++, i++) {
                vertices[i] = new Vertex(x, y);
            }
        }

        edges[0] = new Edge (vertices[0], vertices[3]);
        edges[1] = new Edge (vertices[0], vertices[1]);
        edges[2] = new Edge (vertices[0], vertices[4]);
        edges[3] = new Edge (vertices[2], vertices[5]);
        edges[4] = new Edge (vertices[2], vertices[1]);
        edges[5] = new Edge (vertices[2], vertices[4]);

        var buildingData = new BuildingData (vertices, edges);

        var test0 = buildingData.GetConnections(vertices[0]);
        var test1 = buildingData.GetConnections(vertices[4]);
        var test2 = buildingData.GetConnections(vertices[3]);

        foreach (var item in test0) Debug.Log("Test 0: " + item.Position);
        foreach (var item in test1) Debug.Log("Test 1: " + item.Position);
        foreach (var item in test2) Debug.Log("Test 2: " + item.Position);
    }
}
