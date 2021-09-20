using UnityEngine;

public class MeshCreator : MonoBehaviour
{
    [SerializeField] private Camera MainCamera;
    [SerializeField] private GameObject Player;

    private Mesh[] mesh;
    [SerializeField] private MeshFilter[] meshFilter;
    [SerializeField] private MeshCollider[] meshCollider;
    [SerializeField] private Transform[] Foots;

    public void CreateMesh(LineRenderer lineRenderer)
    {
        // Placing vectors in a single order
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 Point = lineRenderer.GetPosition(i);
            lineRenderer.SetPosition(i, new Vector3(0, (Point.y - 0.55f), (Point.z - transform.position.z)));
        }

        // The number of legs is unlimited. The main thing is to add everything from the new legs to the arrays
        mesh = new Mesh[meshFilter.Length];
        for (int i = 0; i < mesh.Length; i++)
        {
            mesh[i] = new Mesh();
            meshFilter[i].mesh = mesh[i];
            meshCollider[i].sharedMesh = mesh[i];
            lineRenderer.BakeMesh(meshFilter[i].mesh, MainCamera);

            Vector3 HighPoint = new Vector3(-10, -10, -10);
            for (int a = 0; a < mesh[i].vertices.Length; a++)
            {
                if (mesh[i].vertices[a].y > HighPoint.y)
                {
                    HighPoint = mesh[i].vertices[a];
                }
            }
            Foots[i].localPosition = new Vector3(HighPoint.z, -HighPoint.y, 0);
        }
    }
}
