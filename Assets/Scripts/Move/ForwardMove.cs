using UnityEngine;

public class ForwardMove : MonoBehaviour
{
    [SerializeField] private Transform[] MovedTransforms;
    [SerializeField] private GameObject FollowedObject;
    public Vector3 Zero = Vector3.zero;

    // Moves all objects attached to the array behind the leading
    private void LateUpdate()
    {
        for (int i = 0; i < MovedTransforms.Length; i++)
        {
            MovedTransforms[i].transform.position = Vector3.SmoothDamp(MovedTransforms[i].transform.position,
                new Vector3(MovedTransforms[i].position.x, MovedTransforms[i].position.y, FollowedObject.transform.position.z), ref Zero, 0.01f);
        }
    }
}
