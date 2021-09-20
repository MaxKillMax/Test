using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody PlayerRigidBody;
    [SerializeField] private float Speed;

    private void Update()
    {
        PlayerRigidBody.velocity = new Vector3(PlayerRigidBody.velocity.x, PlayerRigidBody.velocity.y, Speed * Time.deltaTime);
    }
}
