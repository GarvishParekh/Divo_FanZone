using System.Collections.Generic;
using UnityEngine;

public class GetVertex : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private Vector3[] vertices;
    [SerializeField] private Vector3[] worldPosition;
    [SerializeField] private List<Transform> spheresList = new List<Transform>();

    [SerializeField] private GameObject spherePrefab;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        worldPosition = new Vector3[vertices.Length];

        for (int i = 0; i < vertices.Length; i++)
        {
            worldPosition[i] = transform.TransformPoint(vertices[i]);
        }

        for (int i = 0; i < worldPosition.Length; i++)
        {
            GameObject _spheres = Instantiate(spherePrefab, worldPosition[i], Quaternion.identity);
            spheresList.Add(_spheres.transform);
        }
    }

  
}
