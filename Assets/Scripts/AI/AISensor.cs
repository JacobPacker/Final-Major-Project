using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensor : MonoBehaviour
{
    public float distance = 10;
    public float angle = 180;
    public float height = 1.0f;
    public Color meshColor = Color.yellow;
    Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Mesh CreateWedgeMesh()
    {
        Mesh mesh = new Mesh();
        int numTriangles = 8;
        int numVerticies = numTriangles * 3;
        Vector3[] vertices = new Vector3[numVerticies];
        int[] triangles = new int[numVerticies];

        Vector3 bottomCenter = Vector3.zero;
        Vector3 bottomLeft = Vector3.zero;
        return mesh;
    }
}
