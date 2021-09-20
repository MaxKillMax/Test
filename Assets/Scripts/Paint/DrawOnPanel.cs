using UnityEngine;

public class DrawOnPanel : MonoBehaviour
{
    [SerializeField] private ForwardMove forwardMove;
    [SerializeField] private MeshCreator meshCreator;
    [SerializeField] private Camera MainCamera;

    [SerializeField] private Transform BrushFolder;
    [SerializeField] private GameObject PrefabBrush;

    private GameObject CurrentBrush;
    private LineRenderer CurrentLineRenderer;

    private Vector3 LastPosition;
    private Vector3 MousePosition;

    private bool Paint = false;
    private bool Enter = false;
    private bool Down = false;

    private void OnMouseEnter()
    {
        Enter = true;
    }

    private void OnMouseDown()
    {
        Down = true;
    }

    private void OnMouseExit()
    {
        Enter = false;
    }

    private void OnMouseUp()
    {
        Down = false;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Enter)
        {
            RaycastHit hit;
            Ray ray = MainCamera.ScreenPointToRay(Input.GetTouch(0).position);

            if (Physics.Raycast(ray.origin, ray.direction, out hit, 2))
            {
                if (hit.collider.transform == transform)
                {
                    MousePosition = hit.point;

                    if (Paint)
                    {
                        PointToMousePosition();
                    }
                    else
                    {
                        CreateBrush();
                        Time.timeScale = 0.0f;
                        Paint = true;
                    }
                }
            }
        }
        else if (!Down)
        {
            DestroyBrush();
            Time.timeScale = 1f;
            Paint = false;
        }
    }

    // Initial brush generation
    private void CreateBrush()
    {
        CurrentBrush = Instantiate(PrefabBrush);
        CurrentBrush.transform.SetParent(BrushFolder);

        CurrentLineRenderer = CurrentBrush.GetComponent<LineRenderer>();
        CurrentLineRenderer.SetPosition(0, MousePosition);

    }

    // Draws if the position is not equal to the old point
    private void PointToMousePosition()
    {
        if (LastPosition != MousePosition)
        {
            LastPosition = MousePosition;

            CurrentLineRenderer.positionCount++;
            CurrentLineRenderer.SetPosition(CurrentLineRenderer.positionCount - 1, LastPosition);
        }
    }

    // When destroyed, a mesh is created
    private void DestroyBrush()
    {
        if (CurrentLineRenderer != null && CurrentLineRenderer.positionCount > 4)
        {
            meshCreator.CreateMesh(CurrentLineRenderer);
        }

        Destroy(CurrentBrush);
        CurrentLineRenderer = null;
    }
}