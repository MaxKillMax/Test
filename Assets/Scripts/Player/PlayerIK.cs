using UnityEngine;

public class PlayerIK : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Transform RightFoot;
    [SerializeField] private Transform LeftFoot;

    private void OnAnimatorIK(int layerIndex)
    {
        if (LeftFoot != null)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
            animator.SetIKPosition(AvatarIKGoal.LeftFoot, LeftFoot.position);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot, LeftFoot.rotation);
        }
        if (RightFoot != null)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
            animator.SetIKPosition(AvatarIKGoal.RightFoot, RightFoot.position);
            animator.SetIKRotation(AvatarIKGoal.RightFoot, RightFoot.rotation);
        }
    }
}
