using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoveVertices : MonoBehaviour
{
    Mesh mesh;
    Vector3[] vertices;


    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        mesh.vertices = Randomize(vertices);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3[] Randomize(Vector3[] verts)
    {
        Dictionary<Vector3, List<int>> dictionary = new Dictionary<Vector3, List<int>>();

        for (int x = 0; x < verts.Length; x++)
        {
            if (!dictionary.ContainsKey(verts[x]))
            {
                dictionary.Add(verts[x], new List<int>());
            }

            dictionary[verts[x]].Add(x);
        }
        foreach (KeyValuePair<Vector3, List<int>> par in dictionary)
        {
            Vector3 newPos = par.Key * Random.Range(0.9f, 1.1f);
            foreach (int i in par.Value)
            {
                verts[i] = newPos;

            }
        }
        return verts;
    }
}
