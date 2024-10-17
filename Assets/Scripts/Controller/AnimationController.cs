using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private static readonly int isWalking = Animator.StringToHash("IsRunning");
    private static readonly int isHit = Animator.StringToHash("IsHit");

    private readonly float magnituteThreshold = 0.5f;
    
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Move(Vector2 vector)
    {
        // 작으면 false 크면 true
        animator.SetBool(isWalking, vector.magnitude > magnituteThreshold);
    }

    public void Hit()
    {
        animator.SetBool(isHit, true);
    }

    private void CharacterFlipX(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}